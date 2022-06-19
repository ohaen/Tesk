using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] _stageTransform;
    public static StageManager instance;
    public GameObject gameOver;
    public GameObject nextStage;
    public GameObject followCam;
    public float cameraOffsetX;
    public float cameraOffsetY;
    public float cameraOffsetZ;

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
        ChangeCamPosition();
    }
    public void OnGameOver()
    {
        PlayerController.isEndGame = true;
        gameOver.SetActive(true);
    }
    public void OffGameOver()
    {
        gameOver.SetActive(false);
    }

    public void OnNextStage()
    {
        nextStage.SetActive(true);
    }
    public void OffNextStage()
    {
        nextStage.SetActive(false);
    }
    public void ChangeCamPosition()
    {
        Vector3 offset = new Vector3(cameraOffsetX, cameraOffsetY, cameraOffsetZ);
        Camera.main.transform.position = _stageTransform[StartScene.stage].position + offset;
    }

}
