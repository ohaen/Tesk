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
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 velo = other.GetComponent<Rigidbody>().velocity;
        for (int i = 0; i < multiplyCount; ++i)
        {
            Instantiate(other.gameObject).GetComponent<Rigidbody>().velocity = velo;
        }
    }
}
