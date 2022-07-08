using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell_Events : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;
    void OnTriggerExit2D(Collider2D other)
    {
        player.transform.position = pos; // new Vector2(0, player.transform.position.y);
    }
}
