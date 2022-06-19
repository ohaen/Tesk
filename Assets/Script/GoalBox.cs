using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBox : MonoBehaviour
{
    public static List<GameObject> _balls = new List<GameObject>();
    private int _score;

    public BallBomeEffect effect;

    private void OnTriggerEnter(Collider other)
    {
        _balls.Add(other.gameObject);
        Debug.Log(ObjectPool.activeBallCount);
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
            Debug.Log("VictoryGame");
            StageManager.instance.OnNextStage();
            BoomEffect();
            //effect.BoomEffect();
        }
    }

    public void BoomEffect()
    {
        for (int i = 0; i < _balls.Count; ++i)
        {
            Vector3 velocity = new Vector3(Random.Range(5.0f, 15.0f)
                , Random.Range(5.0f, 15.0f)
                , Random.Range(5.0f, 15.0f));
            _balls[i].gameObject.GetComponent<Rigidbody>().velocity = velocity;
        }
    }
}
