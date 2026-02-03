using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    [SerializeField] private DragDrop drag;
    [SerializeField] public CardData data;

    public HandViewScript ownerHand;
    public RectTransform Rect { get; private set; }

    private Image cardImage;

    void Awake()
    {
        Rect = GetComponent<RectTransform>();
        /*if (data != null && data.icon != null) { cardImage.sprite = data.icon; }*/
    }
    
}