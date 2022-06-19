using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplyColliderText : MonoBehaviour
{
    private Text _text;
    private int _count;
    public MultiplyCollider multiplyCollider;

    //private void Awake()
    //{
        
    //}
    void Start()
    {
        //multiplyCollider = GetComponent<MultiplyCollider>();
        _count = multiplyCollider.multiplyCount;
        _text = GetComponent<Text>();
        _text.text = $"X {_count}";
    }
}
