using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType
{
    RED,
    BLUE,
}
[System.Serializable]
public class ColorEvent : UnityEngine.Events.UnityEvent<ColorType> { }
public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;
    public static ColorType colorType = ColorType.RED;
    public ColorEvent colorEvent = new ColorEvent();


    private void Awake()
    {
        Time.timeScale = 0.5f;
        if(null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PlayerController Instance()
    {
        if(null == instance)
        {
            return null;
        }
        return instance;
    }

    private void Start()
    {
        
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            colorType = (colorType == ColorType.BLUE) ? ColorType.RED : ColorType.BLUE;
            colorEvent.Invoke(colorType);
            Debug.Log(colorType);
        }
    }

}