using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public static int stage = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
