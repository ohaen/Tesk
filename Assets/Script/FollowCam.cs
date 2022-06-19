using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float offsetY = 0.0f;
    private bool _isFollow = false;
    private Transform followObject = null;

    private void Awake()
    {
        _isFollow = false;
        followObject = null;
    }
    void Update()
    {
        if(null != followObject && false == PlayerController.isEndGame)
        {
            Vector3 followY = new Vector3(transform.position.x, followObject.position.y + offsetY, transform.position.z);
            Vector3 smooth = Vector3.Lerp(transform.position, followY, 0.1f);
            this.transform.position = smooth;
            Camera.main.transform.position = new Vector3(smooth.x + 4.7f, smooth.y+1.7f, smooth.z - 10f);
        }
        if(PlayerController.isEndGame)
        {
            followObject = null;
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
