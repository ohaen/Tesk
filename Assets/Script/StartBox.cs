using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : MonoBehaviour
{
    public GameObject ball;
    RaycastHit hitLayerMask;
    private bool _isClick = false;
    private bool _doStart = false;

    private void OnMouseDown()
    {
        _isClick = true;
    }
    private void OnMouseDrag()
    {
        if(_doStart == false && _isClick == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

            int layerMask = 1 << LayerMask.NameToLayer("StartBox"); /* 특정 layer 검출 */
            if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
            {
                float z = this.transform.position.z; /* 높이 저장 */

                float y = this.transform.position.y;
                this.transform.position = new Vector3(hitLayerMask.point.x, y, z);
            }
        }
    }
    private void OnMouseUp()
    {
        if(_doStart == false)
        {
            StartCoroutine(nameof(ReverseBox));
        }
        _doStart = true;
        _isClick = false;
    }
    IEnumerator ReverseBox()
    {
        PlayerController.isStartGame = true;
        float time = 0.0f;
        while(time < 1.0f)
        {
            time += (Time.deltaTime) * 4;
            float X = Mathf.Lerp(0.0f, 180f, time);
            transform.rotation = Quaternion.Euler(X, 0f, 0f);
            yield return null;
        }
        int count = 0;
        while (count < 5)
        {
            float X = Random.Range(-0.3f, 0.3f);
            float Y = Random.Range(-0.3f, 0.3f);
            Vector3 position = new Vector3(X, Y, 0f);
            ObjectPool.GetObject(transform.position + position);
            ++count;
            yield return new WaitForSeconds(0.05f);
        }
        StopAllCoroutines();
        yield return null;
    }
}
