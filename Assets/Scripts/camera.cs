using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public int targetFramesPerSecond = 60;

    //Follow player
    private GameObject player;
    public float smoothSpeed = 0.625F;
    private Vector3 offset = new Vector3(0, 0, -10); // -10 to see the screen

    //Lock on
    public GameObject target;

    // Start is called before the first frame update
    void Awake()
    {
        // Find player object
        player = GameObject.FindGameObjectWithTag("Player");

        // Set target fps
        Application.targetFrameRate = targetFramesPerSecond;
    }

    // Update is called once per frame
    void LateUpdate()
    {
       FollowPlayer();
    }

    //Follow the player
    void FollowPlayer()
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public int GetTargetFPS()
    {
        return this.targetFramesPerSecond;
    }
}