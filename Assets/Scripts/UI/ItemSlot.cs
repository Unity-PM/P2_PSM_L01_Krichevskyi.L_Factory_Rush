using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.GPUSort;

public class ItemSlot : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        RectTransform dragRT = eventData.pointerDrag.GetComponent<RectTransform>();

        dragRT.SetParent(transform, false);
        dragRT.anchoredPosition = Vector2.zero;
    }

    
}
