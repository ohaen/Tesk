using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject _owner { set; get; }
    private SphereCollider _collider;
    private Rigidbody _rigidbody;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = PlayerController.colorType == ColorType.RED ? Color.red : Color.blue;
        PlayerController.Instance().colorEvent.AddListener(ChangeColor);
        StartCoroutine(nameof(ChangeSizeCollider));
    }

    private void Update()
    {
    }
    
    void ChangeColor(ColorType colorType)
    {
        Color ballColor;
        if(colorType == ColorType.RED)
        {
            ballColor = Color.red;
        }
        else
        {
            ballColor = Color.blue;
        }
        _meshRenderer.material.color = ballColor;
    }

    IEnumerator ChangeSizeCollider()
    {
        float time = 0.0f;
        while(time<1.0f)
        {
            time += Time.deltaTime * 2;
            _collider.radius = Mathf.Lerp(0.1f, 0.5f, time);
            yield return null;
        }
        StopAllCoroutines();
        yield return null;
    }
}
