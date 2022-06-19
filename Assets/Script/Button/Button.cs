using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void GameOverButton()
    {
        AllReturnBall();
    }
    public void NextStageButton()
    {
        AllReturnBall();
    }
    public void AllReturnBall()
    {
        for (int i = 0; i < GoalBox._balls.Count; ++i)
        {
            ObjectPool.ReturnObject(GoalBox._balls[i].gameObject);
        }
    }
}
