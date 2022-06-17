using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplyColliderText : MonoBehaviour
{
    private Text _text;
    private int _count;

    void Start()
    {
        _count = transform.parent.parent.GetComponent<MultiplyCollider>().multiplyCount;
        _text = GetComponent<Text>();
        _text.text = $"X {_count}";
    }
}
