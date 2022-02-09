using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;
    private int lives = 3;

    // Update is called once per frame
    void Update()
    {
        // if an object goes past the player views it gets destroyed
        if (transform.position.z > topBound || transform.position.x > topBound || transform.position.z < -topBound)
            Destroy(gameObject);
        else if (transform.position.z < lowerBound)
        {
            ScoreManager.instance.loseLife();
            Destroy(gameObject);
        }
    }
}
