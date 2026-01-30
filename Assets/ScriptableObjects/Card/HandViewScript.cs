using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class HandViewScript : MonoBehaviour
{
    [SerializeField] float cardSpacing = 70f;
    [SerializeField] float fanAngle = 10f;
    [SerializeField] float radius = 400f;
    [SerializeField] public float verticalThreshold = 100f;
    [SerializeField] public float verticalThresholdGhost = 70f;
    [SerializeField] public float ySpawn = -70f;

    [SerializeField] float layoutSpeed = 10f;
    private Coroutine layoutCoroutine;

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
        Vector3 worldPosBeforeParentChange = card.Rect.position;

        if (cards.Count == 0) { cards.Add(card); Debug.Log("Add first card to the deck"); }
        else if (index == -1) { cards.Insert(0, card); }
        else { cards.Insert(index, card); }

        if (card.Rect.parent != transform)
        {
            card.Rect.SetParent(transform, true);
            card.Rect.position = worldPosBeforeParentChange;
        }

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

        if (layoutCoroutine != null) StopCoroutine(layoutCoroutine);
        layoutCoroutine = StartCoroutine(AnimateLayout());
    }

    public int GetIndexByLocalX(float localX)
    {
        int count = cards.Count;
        if (count == 0) return 0;

        float step = cardSpacing * coeff;
        float totalWidth = (count - 1) * step;
        float startX = -totalWidth / 2f;

        float relativeX = localX - (startX - step / 2f);
        int cardUnderCursor = Mathf.FloorToInt(relativeX / step);

        int index = cardUnderCursor + 1;

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

    private IEnumerator AnimateLayout()
    {
        bool allAtTarget = false;

        while (!allAtTarget)
        {
            allAtTarget = true;
            int baseCount = cards.Count;
            // Считаем актуальное кол-во слотов с учетом превью
            int totalSlots = previewIndex.HasValue ? baseCount + 1 : baseCount;

            float step = cardSpacing * coeff;
            float startX = -((totalSlots - 1) * step) / 2f;

            int cardIdx = 0;
            for (int i = 0; i < totalSlots; i++)
            {
                // Пропускаем индекс превью (дырку)
                if (previewIndex.HasValue && i == previewIndex.Value) continue;
                if (cardIdx >= baseCount) break;

                // Целевая позиция для текущей карты
                Vector3 targetPos = new Vector3(startX + (i * step), 0, 0);
                RectTransform cardRect = cards[cardIdx].Rect;

                // Плавное движение
                cardRect.localPosition = Vector3.Lerp(cardRect.localPosition, targetPos, Time.deltaTime * layoutSpeed);
                cardRect.localRotation = Quaternion.Slerp(cardRect.localRotation, Quaternion.identity, Time.deltaTime * layoutSpeed);

                // Если хоть одна карта еще не долетела (порог 0.1 для Lerp лучше чем 0.01)
                if (Vector3.Distance(cardRect.localPosition, targetPos) > 0.1f)
                {
                    allAtTarget = false;
                }

                cardIdx++;
            }

            yield return null;
        }

        layoutCoroutine = null;
    }

    public Vector2 GetCardPosition(int index, bool toAddCard)
    {
        int count = cards.Count;
        if (count == 0)
        {
            if (toAddCard) { return new Vector2(0, ySpawn); }
            else { return new Vector2(0, ySpawn); }
        }

        if (toAddCard)
            count++;

        float totalWidth = (count - 1) * cardSpacing * coeff;
        float startX = -totalWidth / 2f;


        float xPos = startX + (index * cardSpacing * coeff);

        float yPos = ySpawn;

        /*cards[index].Rect.localPosition = new Vector2(xPos, yPos);*/
        /*cards[index].Rect.localRotation = Quaternion.identity;*/


        return new Vector2(xPos, yPos);
    }
}

