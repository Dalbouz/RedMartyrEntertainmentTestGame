using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterControl : MonoBehaviour
{
    public Camera Cam;
    public NavMeshAgent Agent;
    public Animator Anim = null;

    private void Start()
    {
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
                
                Agent.SetDestination(hit.point);
                
            }
        }
        if (Agent.velocity.magnitude > 0.1f)
        {
            Anim.SetFloat("MoveSpeed", Agent.speed);
        }
        else if(Agent.velocity.magnitude < 0.1f)
        {
            Anim.SetFloat("MoveSpeed", 0.0f);
        }
    }
}

