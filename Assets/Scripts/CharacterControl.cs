using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    public Camera Cam;
    public NavMeshAgent Agent;
    public Animator Anim = null;
    public AudioClip[] AudioClips;
    [SerializeField]
    private AudioSource _audio= null;
    private bool _isPlaying = false;
    private void Start()
    {
        if (!_audio)
        {
            _audio = GetComponent<AudioSource>();
        }
        if(!Anim)
        {
            Anim = GetComponent<Animator>();
        }
        Anim.SetBool("Grounded", true);
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
                    Debug.Log("Player hit");
                }
                else
                {
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
            _audio.Stop();
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
        if (_audio.isPlaying && _audio.clip != AudioClips[0])
        {
            _audio.clip = AudioClips[0];
            _audio.Play();       
        }
        else if(!_audio.isPlaying)
        {
            _audio.clip = AudioClips[0];
            _audio.Play();
        }
        else
        {
            return;
        }
       
    }

    private void PlayWoodFootSteps()
    {
        if (_audio.isPlaying && _audio.clip != AudioClips[1])
        {
            _audio.clip = AudioClips[1];
            _audio.Play();
        }
        else if (!_audio.isPlaying)
        {
            _audio.clip = AudioClips[1];
            _audio.Play();
        }
        else
        {

            return;
        }
    }
}

