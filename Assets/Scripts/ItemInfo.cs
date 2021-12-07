using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
   public ItemSO itemSO;
   private bool _canClick = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        _canClick = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _canClick = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && _canClick)
        {

            UImanager.instance.OnPlayerClick(itemSO.Description);
        }
    }
}
