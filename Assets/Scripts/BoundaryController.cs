using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    public Rigidbody2D rb2dPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() == rb2dPlayer)
        {
            GameController.instance.PlayerDied();
        }
    }
}
