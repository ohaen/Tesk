using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyCollider : MonoBehaviour
{
    public int multiplyCount;
    private void Start()
    {
        PlayerController.Instance().colorEvent.AddListener(ChangeColor);
    }

    void ChangeColor(ColorType colorType)
    {
        if (colorType == ColorType.RED)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(PlayerController.colorType==ColorType.BLUE)
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        for (int i = 0; i < multiplyCount; ++i)
        {
            Instantiate(other.gameObject);
        }
    }
}
