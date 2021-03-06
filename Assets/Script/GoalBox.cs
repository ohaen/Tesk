using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBox : MonoBehaviour
{
    private int _score;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            other.gameObject.layer = 8;
            ++_score;
            if(_score < 150)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            }
        }
        if(false == PlayerController.isEndGame)
        {
            PlayerController.isEndGame = true;
        }
        if(ObjectPool.activeBallCount == _score)
        {
            ++StartScene.stage;
            PlayerController.isStartGame = false;
            BoomEffect();
            if (StartScene.stage > StageManager.instance.LastStageCount())
            {
                StageManager.instance.OnClearGame();
            }
            else
            {
                StageManager.instance.OnNextStage();
            }
        }
    }

    public void BoomEffect()
    {
        for (int i = 0; i < ObjectPool._balls.Count; ++i)
        {
            Vector3 velocity = new Vector3(Random.Range(-10.0f, 10.0f)
                , 10.0f
                , Random.Range(-10.0f, 10.0f));
            ObjectPool._balls[i].gameObject.GetComponent<Rigidbody>().velocity = velocity;
        }
    }
}
