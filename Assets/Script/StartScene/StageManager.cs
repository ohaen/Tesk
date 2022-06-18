using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;
    public GameObject gameOver;
    public GameObject nextStage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
        else
        {
            Destroy(this);
        }
    }
    public void OnGameOver()
    {
        gameOver.SetActive(true);
    }
    public void OnNextStage()
    {
        nextStage.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
