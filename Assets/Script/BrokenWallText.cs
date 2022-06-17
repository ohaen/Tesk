using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenWallText : MonoBehaviour
{
    private Text _text;
    private int _count;

    void Start()
    {
        _count = transform.parent.parent.GetComponent<BrokenWall>().needBall;
        _text = GetComponent<Text>();
        _text.text = $"{_count}";
    }
}
