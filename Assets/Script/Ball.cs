using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject _owner { set; get; }
    private SphereCollider _collider;
    private Rigidbody _rigidbody;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();
        PlayerController.Instance().colorEvent.AddListener(ChangeColor);
    }
    private void OnEnable()
    {
        _meshRenderer.material.color = PlayerController.colorType == ColorType.RED ? Color.red : Color.blue;
        StartCoroutine(nameof(ChangeSizeCollider));
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
            _collider.radius = Mathf.Lerp(0.0f, 0.5f, time);
            yield return null;
        }
        StopCoroutine(nameof(ChangeSizeCollider));
        yield return null;
    }
}
