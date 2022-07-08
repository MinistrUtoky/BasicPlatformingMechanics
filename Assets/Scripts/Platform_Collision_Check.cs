using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Collision_Check : MonoBehaviour
{
    Collider2D collider;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && other.GetType() == typeof(BoxCollider2D))
        {
            GameObject player = other.gameObject;
            if (player.transform.position.y > transform.position.y) {
                player.transform.position = new Vector2(player.transform.position.x, transform.position.y + collider.bounds.size.y / 2 + other.bounds.size.y / 2 + 1);
                Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
                if (prb.velocity.y > 0) { prb.velocity = new Vector2(prb.velocity.x, 0); }
                collider.isTrigger = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collider.isTrigger = true;
        }
    }
}
