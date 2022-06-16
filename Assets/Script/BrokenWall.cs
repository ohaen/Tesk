using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public int needBall;
    private int _ballCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            ++_ballCount;
            if(_ballCount >= needBall)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
