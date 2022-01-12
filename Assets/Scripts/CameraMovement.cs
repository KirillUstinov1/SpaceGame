using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public Transform player1;
    public Transform player2;
    Vector3 cameraOffset;
    public float cameraSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 pos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        int player1_height = (int)Player1.transform.position.y;
        int player2_height = (int)Player2.transform.position.y;

        if (player1_height > player2_height && player1_height - player2_height <= 10)
        {
            //transform.position = new Vector3(0, player1_height);
            cameraOffset = new Vector3(0, -(player1_height - player2_height)/2, 0);
            Vector2 finalPosition = player1.position + cameraOffset;
            Vector2 lerpPosition = Vector2.Lerp(transform.position, finalPosition, cameraSpeed);
            transform.position = lerpPosition;
        }
        
        if (player1_height < player2_height && player2_height - player1_height <=10)
        {
            //transform.position = new Vector3(0, player1_height);
            cameraOffset = new Vector3(0, -(player2_height - player1_height) / 2, 0);
            Vector2 finalPosition = player2.position + cameraOffset;
            Vector2 lerpPosition = Vector2.Lerp(transform.position, finalPosition, cameraSpeed);
            transform.position = lerpPosition;
        }

    }
}
