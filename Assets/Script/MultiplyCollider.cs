using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyCollider : MonoBehaviour
{
    public int multiplyCount;
    public ColorType colliderColor;
    public GameObject neddle;
    private void Start()
    {
        PlayerController.Instance().colorEvent.AddListener(ChangeColor);
    }

    void ChangeColor(ColorType colorType)
    {
        if (colorType == colliderColor)
        {
            neddle.SetActive(false);
        }
        else
        {
            neddle.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(PlayerController.colorType!= colliderColor)
        {
            ObjectPool.ReturnObject(other.gameObject);
            if(ObjectPool.activeBallCount == 0)
            {
                Debug.Log("gameOver");
                StageManager.instance.OnGameOver();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 velo = other.GetComponent<Rigidbody>().velocity;
        Vector3 random;
        random.x = Random.Range(0.0f, velo.x);
        random.y = Random.Range(0.0f, velo.y);
        random.z = 0.0f;
        for (int i = 0; i < multiplyCount; ++i)
        {
            ObjectPool.GetObject(other.transform.position).GetComponent<Rigidbody>().velocity = random;
            //Instantiate(other.gameObject).GetComponent<Rigidbody>().velocity = random;
        }
    }
}
