using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HotSpots : MonoBehaviour
{
    protected GameObject Player;
    public HotSpotSO HotSpot;
    public virtual void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public abstract void OnTriggerEnter(Collider other);

    private void OnMouseOver()
    {
        UImanager.instance.LableHotSpotText.GetComponent<Text>().text = HotSpot.HoverText;
        UImanager.instance.IsHovered = true;
    }

    private void OnMouseExit()
    {
        UImanager.instance.LableHotSpotText.SetActive(false);
        UImanager.instance.IsHovered = false;
    }
}
