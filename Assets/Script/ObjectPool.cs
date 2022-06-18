using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public static int activeBallCount = 0;

    [SerializeField]
    private GameObject _ball;
    Queue<GameObject> ballQueue = new Queue<GameObject>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Initialized(int initCount)
    {
        for(int i = 0; i < initCount; ++i)
        {
            ballQueue.Enqueue(CreateNewObject());
        }
    }

    private GameObject CreateNewObject()
    {
        var newObj = Instantiate(_ball);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }
    public static GameObject GetObject(Vector3 position)
    {
        ++activeBallCount;
        if (Instance.ballQueue.Count > 0)
        {
            var obj = Instance.ballQueue.Dequeue();
            obj.transform.position = position;
            //obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.position = position;
            newObj.gameObject.SetActive(true);
            return newObj;
        }
        
    }

    public static void ReturnObject(GameObject obj)
    {
        --activeBallCount;
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.ballQueue.Enqueue(obj);
    }
}
