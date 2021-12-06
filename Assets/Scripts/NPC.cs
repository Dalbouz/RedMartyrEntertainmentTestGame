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
    private Animator _anim;
    protected float Timer;
    protected float GoToIdleTime = 8f;

    private void Awake()
    {
        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        }
        _anim = GetComponent<Animator>();
    }
    public virtual void Update()
    {
        
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && Player.IsClickedOnNPC)
        {
            DialogManager.Instance.NpcAnimator = _anim;
            Player.Agent.velocity = Vector3.zero;
            Player.Agent.isStopped = true;
            _anim.SetTrigger("dead");
            int rand = Random.Range(0, Npcso.PlayerAnsers.Length);
            Player.PlayerText = Npcso.PlayerAnsers[rand];
            UImanager.instance.OnNpcClick(Npcso.DialogTextNPC, OffsetNpcFrame);
        }
    }
}
