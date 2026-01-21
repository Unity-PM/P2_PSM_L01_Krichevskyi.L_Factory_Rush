using System.Collections.Generic;
using UnityEngine;

public class HandViewScript : MonoBehaviour
{
    [SerializeField] float cardSpacing = 70f;
    [SerializeField] float fanAngle = 10f;
    [SerializeField] float radius = 400f;

    private List<RectTransform> cards = new();

    public void AddCard(RectTransform card)
    {
        cards.Add(card);
        card.SetParent(transform, false);
        UpdateLayout();
    }

    public void RemoveCard(RectTransform card)
    {
        cards.Remove(card);
        UpdateLayout();
    }

    public void UpdateLayout()
    {
        int count = cards.Count;
        for (int i = 0; i < count; i++)
        {
            float t = i - (count - 1) / 2f;
            float angle = t * fanAngle;
            Vector2 pos = Quaternion.Euler(0, 0, angle) * Vector2.up * radius;

            RectTransform card = cards[i];
            card.localPosition = pos;
            card.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }
}

