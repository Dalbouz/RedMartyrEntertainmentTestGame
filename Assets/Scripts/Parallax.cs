using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float _length, _startPos;
    public GameObject Cam;
    public float ParallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
        _startPos = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x; //vraca duzinu spritea po X-u
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (Cam.transform.position.x * (1 - ParallaxEffect));
        float distance = (Cam.transform.position.x * ParallaxEffect);//provjerava koliko daleko smo se pomaknuli od pocetne pozicije(koliko smo se pomaknuli u world space)
        transform.position = new Vector3(_startPos + distance, transform.position.y, transform.position.z);

        if(temp > _startPos+_length)
        {
            _startPos += _length;
        }
        else if (temp < _startPos - _length)
        {
            _startPos -= _length;
        }
    }
}
