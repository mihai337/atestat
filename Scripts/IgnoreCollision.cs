using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public Transform rb;

    void Start()
    {
        Physics2D.IgnoreCollision(rb.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
    }

    
}
