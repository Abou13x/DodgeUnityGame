
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    //void OnTriggerEnter()
    //{
    //    Debug.Log("end trigger");
    //    gameManager.CompleteLevel();
    //}

    void OnControllerColliderHit(ControllerColliderHit collisionInfo)
    {
        //video 5
        if (collisionInfo.collider.gameObject.tag == "End")
        {
            gameManager.CompleteLevel();
        }

    }
}
