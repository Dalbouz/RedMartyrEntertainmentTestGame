using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HotSpots : MonoBehaviour
{
    protected GameObject Player;
    public HotSpotSO HotSpot;
    public virtual void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public abstract void OnTriggerEnter(Collider other);
    
}
