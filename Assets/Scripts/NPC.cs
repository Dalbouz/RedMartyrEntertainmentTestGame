using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    protected CharacterControl Player= null;
    [SerializeField]
    protected NPCSO Npcso;
    [SerializeField]
    protected float OffsetNpcFrame;

    private void Awake()
    {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"&& Player.IsClickedOnNPC)
        {
            Debug.Log("Player enter");
            Player.Agent.velocity = Vector3.zero;
            int rand = Random.Range(0, Npcso.PlayerAnsers.Length);
            Player.PlayerText = Npcso.PlayerAnsers[rand];
            UImanager.instance.OnNpcClick(Npcso.DialogTextNPC, OffsetNpcFrame);
        }
    }
}
