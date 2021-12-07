using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    public AudioClipsSo AudioClips;
    public Camera Cam;
    public NavMeshAgent Agent;
    public Animator Anim = null;  
    public AudioSource Audio= null;
    public string PlayerText;
    private string _helloText = "Hello new player!";
    [SerializeField]
    private float _minDistanceBetweenNPC;

    private void Start()
    {
        if (!Audio)
        {
            Audio = GetComponent<AudioSource>();
        }
        if(!Anim)
        {
            Anim = GetComponent<Animator>();
        }
        Anim.SetBool("Grounded", true);

        PlayerText = _helloText;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    PlayerText = _helloText;
                    UImanager.instance.OnPlayerClick(PlayerText);
                }
                else if (hit.collider.gameObject.CompareTag("NPC"))
                {
                    DialogManager.Instance.WantToStartDialog = true;
                    Agent.SetDestination(hit.point);
                }
                else
                {
                   //if(DialogManager.Instance.WantToStartDialog)
                   // {
                   //     DialogManager.Instance.WantToStartDialog = false;
                   // }
                    Agent.SetDestination(hit.point);
                }
            }
        }
        if (Agent.velocity.magnitude > 0.1f)
        {
            NavMeshHit hitNav;
            NavMesh.SamplePosition(Agent.transform.position, out hitNav, 0.1f, NavMesh.AllAreas);
            int index = IndexFromMask(hitNav.mask);
            if (index == 0)
            {
                PlayMudFootSteps();
            }
            else if (index == 3)
            {
                PlayWoodFootSteps();
            }
            Anim.SetFloat("MoveSpeed", Agent.speed);
        }
        else if(Agent.velocity.magnitude < 0.1f)
        {
            if (Audio.clip != AudioClips.PlayerClips[0] && Audio.clip != AudioClips.PlayerClips[1]) return;
            else
                Audio.Stop();
            Anim.SetFloat("MoveSpeed", 0.0f);
        }
    }

    private int IndexFromMask(int mask)
    {
        for (int i = 0; i < 4; i++)
        {
            if((1<<i)== mask)
                return i;
        }
        return -1;
    }

    private void PlayMudFootSteps()
    {
        if (Audio.isPlaying && Audio.clip != AudioClips.PlayerClips[0])
        {
            Audio.clip = AudioClips.PlayerClips[0];
            Audio.Play();       
        }
        else if(!Audio.isPlaying)
        {
            Audio.clip = AudioClips.PlayerClips[0];
            Audio.Play();
        }
        else
        {
            return;
        }
       
    }

    private void PlayWoodFootSteps()
    {
        if (Audio.isPlaying && Audio.clip != AudioClips.PlayerClips[1])
        {
            Audio.clip = AudioClips.PlayerClips[1];
            Audio.Play();
        }
        else if (!Audio.isPlaying)
        {
            Audio.clip = AudioClips.PlayerClips[1];
            Audio.Play();
        }
        else
        {

            return;
        }
    }
    public void SetHelloText()
    {
        PlayerText = _helloText;
    }
}

