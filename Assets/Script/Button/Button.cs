using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void GameOverButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void NextStageButton()
    {
        AllReturnBall();
        ++StartScene.stage;
        PlayerController.Instance().ResetStage();
        StageManager.instance.OffNextStage();
    }

    public void ClearGameButton()
    {
        Application.Quit();
    }
    public void AllReturnBall()
    {
        for (int i = 0; i < ObjectPool._balls.Count; ++i)
        {
            if(true == ObjectPool._balls[i].active)
            {
                ObjectPool.ReturnObject(ObjectPool._balls[i].gameObject);
            }
        }
    }
}
