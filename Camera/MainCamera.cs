﻿using UnityEngine;

public class MainCamera : MonoBehaviour {
    public float xMargin = 1f;        // Distance in the x axis the player can move before the camera follows.
    public float yMargin = 1f;

    //public float xSmooth = 1.5f;		// How smoothly the camera catches up with it's target movement in the x axis.

    public Vector2 maxXAndY;        // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY;        // The minimum x and y coordinates the camera can have.

    private Transform player;        // Reference to the player's transform.

    void Awake () {
        // Setting up the reference.
        player = GameObject.FindGameObjectWithTag("Avater").transform;
    }

    bool CheckXMargin() {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin() {
        // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    void FixedUpdate () {
        TrackPlayer();
    }

    void TrackPlayer () {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        // If the player has moved beyond the x margin...
        if (CheckXMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetX = Mathf.Lerp(transform.position.x, player.position.x, 2f * Time.deltaTime);
        if (CheckYMargin())
            // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
            targetY = Mathf.Lerp(transform.position.y, player.position.y, 2f * Time.deltaTime);

        // The target x and y coordinates should not be larger than the maximum or smaller than the minimum.
        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
        targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);
        //Debug.Log ("Camera shoud be at:" + targetX);
        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
