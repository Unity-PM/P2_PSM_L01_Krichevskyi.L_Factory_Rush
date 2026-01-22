using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;

public class CardSystem : MonoBehaviour
{
    public GridManager gridManager;
    private GridScript grid;

    private List<CardData> deckList = new List<CardData>();

    /*public static event Action CardSystemLoaded;*/

    private void Start()
    {
        grid = gridManager.GetGrid();
        /*CardSystemLoaded?.Invoke();*/
    }





}
