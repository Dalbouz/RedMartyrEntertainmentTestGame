using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Target;
    [SerializeField]
    private float _leftEdge = -9.6f;
    [SerializeField]
    private float _rightEdge = 6f;
    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        var xPosition = Target.transform.position.x;

        transform.eulerAngles = new Vector3(0, xPosition, 0);
        
        if(transform.rotation.y <= _leftEdge)
        {
            transform.eulerAngles =new Vector3(0, _leftEdge, 0);
        }
        else if(transform.position.x >= _rightEdge)
        {
            transform.eulerAngles = new Vector3(0, _rightEdge, 0);
        }
    }
}
