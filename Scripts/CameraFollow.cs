using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;

    Vector3 offset;

    public bool goodPosition = false;
    float lastX = 0f;

    private void Start()
    {
        offset = new Vector3(11.6f , 1.9f , target.position.z);
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            goodPosition = false;
            transform.position = new Vector3(11.6f, 1.9f, -10f);
            target = FindPlayer();
            return;
        }

        offset.z = 0f;

        if (target.position.x >= 0f && target.position.x < 614f)
        {
            lastX = target.position.x;
            goodPosition = true;
        }
        else
        if (target.position.x >= 614f)
            goodPosition = false;

        if (goodPosition)
        {
            if (target.position.y >= 0.3f)
                offset.y = 1.9f + target.position.y;
            else
                offset.y = 1.9f;
            transform.position = new Vector3(target.position.x, 0f, -10f) + offset;
        }
        else
        {
            transform.position = new Vector3(lastX, 0f, -10f) + offset;
        }

    }

    private Transform FindPlayer()
    {
        Transform searchResult = GameObject.FindGameObjectWithTag("Player").transform;

        if (searchResult == null)
            return null;
        else
            return searchResult;
    }

}