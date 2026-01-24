using System.Collections.Generic;
using UnityEngine;

public class HandViewScript : MonoBehaviour
{
    [SerializeField] float cardSpacing = 70f;
    [SerializeField] float fanAngle = 10f;
    [SerializeField] float radius = 400f;

    private float coeff = 0.7f;


    private List<CardScript> cards = new List<CardScript>();
    private CardScript pickedCard;

    private void Start()
    {
        pickedCard = null;
    }

    public void AddCard(CardScript card)
    {
        cards.Add(card);
        card.Rect.SetParent(transform, false);
        UpdateLayout();
    }

    public void TakeCard(CardScript card)
    {
        pickedCard = card;
        RemoveCard(card);
    }
    public void PutCard(CardScript card)
    {
        AddCard(card);
        pickedCard = null;
    }
    public void RemoveCard(CardScript card)
    {
        cards.Remove(card);
        UpdateLayout();
    }

    public void UpdateLayout()
    {
        int count = cards.Count;

        // Вычисляем общую ширину ряда (количество промежутков * размер отступа)
        float totalWidth = (count - 1) * cardSpacing * coeff;
        // Находим левый край, чтобы ряд был центрирован
        float startX = -totalWidth / 2f;

        for (int i = 0; i < count; i++)
        {
            // Каждая карта смещается вправо от старта на i шагов
            float xPos = startX + (i * cardSpacing * coeff);

            // Опционально: добавляем небольшой изгиб по Y, чтобы не было совсем плоско
            float yPos = 0;

            cards[i].Rect.localPosition = new Vector2(xPos, yPos);
            cards[i].Rect.localRotation = Quaternion.identity; // Сбрасываем вращение для ровного ряда
        }

        Canvas.ForceUpdateCanvases();
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

