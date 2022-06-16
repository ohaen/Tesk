using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject _owner { set; get; }
    private SphereCollider _collider;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine("ChangeSizeCollider");
    }

    private void Update()
    {

    }

    IEnumerator ChangeSizeCollider()
    {
        float time = 0.0f;
        while(time<1.0f)
        {
            time += Time.deltaTime;
            _collider.radius = Mathf.Lerp(0.0f, 0.5f, time);
            yield return null;
        }
        StopAllCoroutines();
        time = 0.0f;
        yield return null;
    }
}
