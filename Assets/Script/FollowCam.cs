using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float offsetY = 0.0f;
    private bool _isFollow = false;
    private Transform followObject = null;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(null != followObject)
        {
            Vector3 followY = new Vector3(transform.position.x, followObject.position.y + offsetY, transform.position.z);
            this.transform.position = followY;
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
        if(other.CompareTag("Ball"))
        {
            followObject = other.transform;
        }
    }
}
