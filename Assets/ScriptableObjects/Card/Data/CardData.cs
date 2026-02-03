using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/Cards/Card")]
public class CardData : ScriptableObject
{
    [Header("Visual")]
    public string title;
    public Sprite icon;

    [Header("Gameplay")]
    public GameObject structurePrefab;
}
