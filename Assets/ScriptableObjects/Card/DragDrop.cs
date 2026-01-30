using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    [SerializeField] private Canvas canvas;
    [SerializeField] private CardScript card; // карта, которую перетаскиваем

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    
    private void Start() {
        /*Image image = GetComponent<Image>();
        image.sprite = card.icon;*/

        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        originalParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        /*Debug.Log("OnBeginDrag");*/
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        originalParent = transform.parent;

        card.ownerHand.TakeCard(card);
        transform.SetParent(canvas.transform, true);
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        RectTransform handRect = card.ownerHand.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(handRect, Input.mousePosition, canvas.worldCamera, out localPoint);

        if (card.ownerHand.IsPointerOverHand(localPoint))
        {
            int hoveredIndex = card.ownerHand.GetIndexByLocalX(localPoint.x);
            card.ownerHand.SetPreviewIndex(hoveredIndex);
        }
        else
        {
            card.ownerHand.SetPreviewIndex(null);
        }

    }

    public void OnEndDrag(PointerEventData eventData) {
        /*Debug.Log("OnEndDrag");*/
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;



        // Попытка построить объект
        Vector3 worldPos = CursorManager.Instance.GetCursorWorldPosition(); // на уровне сетки
        Debug.Log($"Coordinates: {worldPos.x} and {worldPos.z}");

        bool built = BuildManager.Instance.PlaceObject(card.data, worldPos);
        if (!built)
        {
            rectTransform.SetParent(originalParent, false);
            rectTransform.anchoredPosition = Vector2.zero;

            int hoveredCardIndex = GetHoveredCardIndex();
            Debug.Log($"Card with {hoveredCardIndex} index is under cursor");

            card.ownerHand.PutCard(card, hoveredCardIndex);
        }
        else
        {
            CardSystem.Instance.RemoveCardFromHand(card);
        }

        card.ownerHand.SetPreviewIndex(null);

    }

    public void OnPointerDown(PointerEventData eventData) {
        /*Debug.Log("OnPointerDown");*/
    }

    private int GetHoveredCardIndex()
    {
        RectTransform handRect = card.ownerHand.GetComponent<RectTransform>();
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            handRect,
            Input.mousePosition,
            canvas.worldCamera,
            out localPoint
        );


        if (Mathf.Abs(localPoint.y) > card.ownerHand.verticalThreshold)
            return card.ownerHand.GetCardsCount();

        return card.ownerHand.GetIndexByLocalX(localPoint.x);
    }

}
