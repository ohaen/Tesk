using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyCollider : MonoBehaviour
{
    public int multiplyCount;
    public ColorType colliderColor;
    private void Start()
    {
        PlayerController.Instance().colorEvent.AddListener(ChangeColor);
    }

    void ChangeColor(ColorType colorType)
    {
        if (colorType == colliderColor)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(PlayerController.colorType!= colliderColor)
        {
            ObjectPool.ReturnObject(other.gameObject);
            //Destroy(other.gameObject);
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
