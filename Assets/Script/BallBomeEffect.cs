using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBomeEffect : MonoBehaviour
{
    
    private const int MAXCOUNT = 50;
    private Rigidbody[] _balls = new Rigidbody[50];
    private int _count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if(_count < MAXCOUNT)
        {
            _balls[_count] = other.GetComponent<Rigidbody>();
            ++_count;
        }
    }

    public void BoomEffect()
    {
        Vector3 velocity = new Vector3(0.0f, 45.0f, 0.0f);
        for(int i = 0; i < MAXCOUNT; ++i)
        {
            if (_balls[i] == null)
                break;
            _balls[i].velocity = _balls[i].velocity + velocity;
        }
    }
}
