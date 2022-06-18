using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBox : MonoBehaviour
{
    private int _score;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(ObjectPool.activeBallCount);
        if(other.CompareTag("Ball"))
        {
            ++_score;
            if(_score < 150)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            }
        }
        if(false == PlayerController.isEndGame)
        {
            PlayerController.isEndGame = true;
        }
    }
}
