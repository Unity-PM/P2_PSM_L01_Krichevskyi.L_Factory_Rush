using UnityEngine;

public class CardScript : MonoBehaviour
{
    [SerializeField] private DragDrop drag;
    [SerializeField] public CardData data;

    public HandViewScript ownerHand;
    public RectTransform Rect { get; private set; }

    void Awake()
    {
        Rect = GetComponent<RectTransform>();
    }
    
}