using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    protected CharacterControl Player= null;
    [SerializeField]
    protected NPCSO Npcso;
    private Animator _anim;
    protected float Timer;
    protected float GoToIdleTime = 8f;
    [SerializeField]
    protected Transform HeadPosition;

    private void Awake()
    {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        }
        _anim = GetComponent<Animator>();
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && DialogManager.Instance.WantToStartDialog)
        {
            Player.Agent.velocity = Vector3.zero;
            Player.Agent.isStopped = true;
            _anim.SetTrigger("dead");
            int rand = Random.Range(0, Npcso.PlayerAnsers.Length);
            Player.PlayerText = Npcso.PlayerAnsers[rand];
            UImanager.instance.NpcHeadPosition = HeadPosition;
            UImanager.instance.OnNpcClick(Npcso.DialogTextNPC, Npcso.OffsetTextFrame);
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _anim.SetTrigger("normal");
        }
    }
}
