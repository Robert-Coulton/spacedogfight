using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPoint : MonoBehaviour
{
    public float diameter;
    public float RotateSpeed;
    public Transform player;

    void Update()
    {
        if (player == null)
        {
            // Find the player's ship!
            GameObject go = GameObject.FindWithTag("Player");

            if (go != null)
            {
                player = go.transform;
            }
        }

        // At this point, we've either found the player,
        // or he/she doesn't exist right now.

        if (player == null)
            return; // Try again next frame!

        // HERE -- we know for sure we have a player. Turn to face it!

        transform.position = player.position;
        transform.Translate(diameter, 0, 0);
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
    }
}
