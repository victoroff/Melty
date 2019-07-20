using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
           // Debug.Log("we hit an obstacle");
            movement.enabled = false;

            FindObjectOfType<GameManager>().EndGame();
        }

    }
}
