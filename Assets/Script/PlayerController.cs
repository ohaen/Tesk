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
    public static bool isStartGame = false;
    public static bool isEndGame = false;
    public ColorEvent colorEvent = new ColorEvent();



    private void Awake()
    {
        ResetStage();
        Time.timeScale = 0.7f;
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


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && true == isStartGame)
        {
            colorType = (colorType == ColorType.BLUE) ? ColorType.RED : ColorType.BLUE;
            colorEvent.Invoke(colorType);
            Debug.Log(colorType);
        }
    }

        public void ResetStage()
    {
        colorType = ColorType.RED;
        isStartGame = false;
        isEndGame = false;
        StageManager.instance.ChangeCamPosition();
        //ObjectPool._balls.Clear();
    }

}