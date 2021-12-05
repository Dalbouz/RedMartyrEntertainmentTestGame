using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Target;
    [SerializeField]
    private float _leftEdge = -3f;
    [SerializeField]
    private float _rightEdge = 3.1f;
    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        var xPosition = Target.transform.position.x;

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        
        if(transform.position.x <= _leftEdge)
        {
            transform.position = new Vector3(_leftEdge, transform.position.y, transform.position.z);
        }
        else if(transform.position.x >= _rightEdge)
        {
            transform.position = new Vector3(_rightEdge, transform.position.y, transform.position.z);
        }
    }
}
