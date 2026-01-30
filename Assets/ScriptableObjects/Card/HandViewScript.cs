using System.Collections.Generic;
using UnityEngine;

public class HandViewScript : MonoBehaviour
{
    [SerializeField] float cardSpacing = 70f;
    [SerializeField] float fanAngle = 10f;
    [SerializeField] float radius = 400f;
    [SerializeField] public float verticalThreshold = 100f;
    [SerializeField] public float verticalThresholdGhost = 70f;

    private int? previewIndex = null;
    private float coeff = 0.7f;

    private List<CardScript> cards = new List<CardScript>();
    private CardScript pickedCard;

    public int GetCardsCount() { return cards.Count; }

    private void Start()
    {
        pickedCard = null;
    }

    public void AddCard(CardScript card, int index)
    {
        if (cards.Count == 0) { cards.Add(card); Debug.Log("Add first card to the deck"); }
        else if (index == -1) { cards.Insert(0, card); }
        else { cards.Insert(index, card); }
            
        card.Rect.SetParent(transform, false);
        UpdateLayout();
    }

    public void TakeCard(CardScript card)
    {
        pickedCard = card;
        RemoveCard(card);
    }
    public void PutCard(CardScript card, int index)
    {
        AddCard(card, index);
        pickedCard = null;
    }
    public void RemoveCard(CardScript card)
    {
        cards.Remove(card);
        UpdateLayout();
    }

    public void UpdateLayout()
    {
        int baseCount = cards.Count;
        if (baseCount == 0 && previewIndex == null) return;

        // Считаем общее кол-во мест (карты + дырка)
        int totalSlots = previewIndex != null ? baseCount + 1 : baseCount;

        float totalWidth = (totalSlots - 1) * cardSpacing * coeff;
        float startX = -totalWidth / 2f;

        int cardIdx = 0; // Реальный индекс карты в списке List<CardScript>
        for (int i = 0; i < totalSlots; i++)
        {
            // Если текущее место занято превью-дыркой, просто идем дальше, 
            // не увеличивая индекс карты
            if (previewIndex != null && i == previewIndex) continue;

            // Если мы уже распределили все карты, а места еще остались (защита)
            if (cardIdx >= baseCount) break;

            float xPos = startX + (i * cardSpacing * coeff);

            cards[cardIdx].Rect.localPosition = new Vector2(xPos, 0);
            cards[cardIdx].Rect.localRotation = Quaternion.identity;

            cardIdx++; // Переходим к следующей физической карте
        }

        Canvas.ForceUpdateCanvases();
    }

    public int GetIndexByLocalX(float localX)
    {
        int count = cards.Count;
        // Если карт нет, единственная позиция — 0
        if (count == 0) return 0;

        float step = cardSpacing * coeff;
        float totalWidth = (count - 1) * step;
        float startX = -totalWidth / 2f;

        // RoundToInt находит ближайшее целое число. 
        // Если ты ближе к левому краю первой карты, он выдаст 0.
        // Если ближе к правому краю последней — выдаст count.
        float relativeX = localX - (startX - step / 2f);
        int cardUnderCursor = Mathf.FloorToInt(relativeX / step);

        // 2. Всегда возвращаем индекс этой карты + 1 (т.е. позицию справа).
        int index = cardUnderCursor + 1;

        // Ограничиваем строго от 0 до текущего количества карт
        return Mathf.Clamp(index, 0, count);
    }

    public bool IsPointerOverHand(Vector2 localPoint)
    {
        int count = cards.Count;
        // Если карт нет, разрешаем зону размером с одну карту в центре
        float currentWidth = count > 0 ? (count - 1) * cardSpacing * coeff : cardSpacing;

        // Границы по X (с небольшим запасом в пол-карты)
        float paddingX = (cardSpacing * coeff) * 2;
        bool overX = localPoint.x >= (-currentWidth / 2f - paddingX) &&
                     localPoint.x <= (currentWidth / 2f + paddingX);

        // Границы по Y (используем твою переменную)
        bool overY = Mathf.Abs(localPoint.y) <= verticalThresholdGhost;

        //
        return overX && overY;
    }

    public void SetPreviewIndex(int? index)
    {
        if (previewIndex == index) return;
        previewIndex = index;
        UpdateLayout();
    }

    public int GetCardPosition(int index, bool toAddCard)
    {
        int count = cards.Count;
        if (count == 0)
            return 0;

        if (toAddCard)
            count++;
        // Вычисляем общую ширину ряда (количество промежутков * размер отступа)
        float totalWidth = (count - 1) * cardSpacing * coeff;
        // Находим левый край, чтобы ряд был центрирован
        float startX = -totalWidth / 2f;


        // Каждая карта смещается вправо от старта на i шагов
        float xPos = startX + (index * cardSpacing * coeff);

        // Опционально: добавляем небольшой изгиб по Y, чтобы не было совсем плоско
        float yPos = 0;

        cards[index].Rect.localPosition = new Vector2(xPos, yPos);
        cards[index].Rect.localRotation = Quaternion.identity; // Сбрасываем вращение для ровного ряда


        return 1;
    }
}

