using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<Ball> balls;

    public enum ColorType
    {
        RED,
        BLUE,
    }

    public static ColorType colorType = ColorType.RED;

    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            colorType = (colorType == ColorType.BLUE) ? ColorType.RED : ColorType.BLUE;
            Debug.Log(colorType);
        }
    }

}