using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject finishPanel;
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") ||  rb.velocity.x == 0f )
        {
            PlayerDied();
        }

        if (collision.gameObject.CompareTag("End"))
        {
            PlayerFinished();
        }
    }

    private void PlayerDied()
    {
        deathPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void PlayerFinished()
    {
        finishPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
