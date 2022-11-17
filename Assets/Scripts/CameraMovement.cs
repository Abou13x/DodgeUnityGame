
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;


    // Update is called once per frame

    void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
     
        transform.LookAt(player);
        
    }
}
