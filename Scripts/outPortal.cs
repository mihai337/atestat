using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outPortal : MonoBehaviour
{
    public Vector2 coord;
    private Vector3 offset;
    public LayerMask player;
    public bool lovit = false;
    void Update()
    {
        
        Debug.DrawLine(transform.position, transform.TransformDirection(Vector2.down*1300f), Color.red);

        RaycastHit2D ok = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down * 1300f), 6f , player);

        if (ok)
        {
           inPortal.instance.hit = false;
            lovit = true;
        }
    }
}
