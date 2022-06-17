using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBox : MonoBehaviour
{
    private int _score;
    private float _weight = 0.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            ++_score;
            _weight = Mathf.Lerp(0f, 3f, _score / 50);
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
