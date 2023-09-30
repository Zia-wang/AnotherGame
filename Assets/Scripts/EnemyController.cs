using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform playerCheck;
    public LayerMask WhatIsPlayer;

    private bool isAttacked;
    private float circleRadius = 0.05f;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacked = Physics2D.OverlapCircle(playerCheck.position, circleRadius, WhatIsPlayer);

        if (isAttacked)
        {
            GameController.instance.PlayerScoredEnemy();
            spriteRenderer.enabled = false;
            Destroy(rb2d.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameController.instance.PlayerDied();
        }
    }
}
