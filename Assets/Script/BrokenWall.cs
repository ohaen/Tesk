using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    public int needBall;
    private int _ballCount = 0;
    private Animator _animator;

    private void Start()
    {
        _animator = transform.GetChild(1).GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            _animator.SetLayerWeight(1, ((float)_ballCount / 100.0f));
            ++_ballCount;
            if(_ballCount >= needBall)
            {
                Destroy(this.gameObject);
            }
        }
        if(ObjectPool.activeBallCount == _ballCount && ObjectPool.activeBallCount < needBall)
        {
            Debug.Log("gameOver");
            StageManager.instance.OnGameOver();
        }
    }
}
