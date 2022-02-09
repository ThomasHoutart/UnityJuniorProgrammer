using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float minTimeBetweenSpawn = 0.5f;
    private float timeFromLastSpawn = 200f;

    // Update is called once per frame
    void Update()
    {
        timeFromLastSpawn += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeFromLastSpawn < minTimeBetweenSpawn)
                return;
            
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timeFromLastSpawn = 0;
        }
    }
}
