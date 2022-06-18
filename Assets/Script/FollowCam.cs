using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float offsetY = 0.0f;
    private bool _isFollow = false;
    private Transform followObject = null;

    void Update()
    {
        if(null != followObject)
        {
            Vector3 followY = new Vector3(transform.position.x, followObject.position.y + offsetY, transform.position.z);
            Vector3 smooth = Vector3.Lerp(transform.position, followY, 0.01f);
            this.transform.position = smooth;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            if(false == _isFollow)
            {
                followObject = other.transform;
                _isFollow = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ball") && false == PlayerController.isEndGame)
        {
            followObject = other.transform;
        }
    }
}
