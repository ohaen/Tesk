using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public static int stage = 0;
    private StartScene obj;

    private void Awake()
    {
        obj = FindObjectOfType<StartScene>();
        if (obj == null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
