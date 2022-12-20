using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController movement;

    // Start is called before the first frame update
   void OnControllerColliderHit(ControllerColliderHit collisionInfo)
    {
        //video 5
       if(collisionInfo.collider.gameObject.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
   
    }
}
