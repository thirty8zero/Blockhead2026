using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera


    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        //Null check for player getting destroyed and losing reference
        if (player == null)
        {
            //Debug.Log("PLAYER IS NULL NOW");
            return;
        }

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

    }
}
