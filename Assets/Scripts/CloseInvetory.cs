using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseInvetory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Inventory inventory;
    public bool CanClosePanel = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        CanClosePanel = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CanClosePanel = true;
    }
}
