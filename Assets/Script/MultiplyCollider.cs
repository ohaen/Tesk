using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyCollider : MonoBehaviour
{
    public int multiplyCount;



    private void OnTriggerEnter(Collider other)
    {
        if(PlayerController.colorType==PlayerController.ColorType.BLUE)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < multiplyCount; ++i)
        {
            Instantiate(other.gameObject);
        }
    }
}
