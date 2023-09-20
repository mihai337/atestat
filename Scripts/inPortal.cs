using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inPortal : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool hit = false;
    public static inPortal instance;
    public Vector2 coord;
    public float gravity;

    void Update()
    {
        coord = new Vector2(228.47f, 7.76f);
        Debug.DrawLine(transform.position, transform.TransformDirection(coord), Color.red);

        RaycastHit2D ok = Physics2D.Raycast(transform.position, transform.TransformDirection(coord), 6f);

        if (ok)
            hit = true;
    }

    private void Start()
    {
        hit = false;
        instance = this;
    }

}
