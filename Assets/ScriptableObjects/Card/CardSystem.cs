using System;
using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    public static CardSystem Instance;

    [SerializeField] private HandViewScript handView;

    private List<CardScript> handCards = new List<CardScript>(); // текущие карты в руке

    /*public static event Action CardSystemLoaded;*/

    void Start()
    {
        Instance = this;

        /*CardSystemLoaded?.Invoke();*/
    }

    // Спавним новую карту в руку
    public void SpawnCard(GameObject cardPrefab)
    {
        GameObject cardObj = Instantiate(cardPrefab, handView.transform);
        CardScript cardScript = cardObj.GetComponent<CardScript>();
        if (cardScript == null) return;

        cardScript.ownerHand = handView;
        int cardsCount = handCards.Count;

        cardScript.Rect.localPosition = handView.GetCardPosition(cardsCount, true);

        if (cardsCount == 0) { handCards.Add(cardScript); }
        else { handCards.Insert(cardsCount, cardScript); }
            


        handView.AddCard(cardScript, cardsCount);
    }

    public void RemoveCardFromHand(CardScript card)
    {
        if (handCards.Contains(card))
        {
            handCards.Remove(card);
            handView.RemoveCard(card);
            Destroy(card.gameObject);
        }
    }

    // Можно добавить метод, который спавнит несколько карт сразу
    public void SpawnMultipleCards(List<GameObject> prefabs)
    {
        foreach (var prefab in prefabs)
        {
            SpawnCard(prefab);
        }
    }
}
