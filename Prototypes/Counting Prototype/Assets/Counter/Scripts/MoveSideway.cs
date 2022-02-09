using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSideway : MonoBehaviour
{
    [SerializeField] float zRange = 9;
    [SerializeField] float speed = 1;
    
    private Vector3 currentPosition;
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);
        if (transform.position.z > zRange || transform.position.z < -zRange)
        {
            direction *= -1;
            transform.Translate(Vector3.forward * speed * direction * Time.deltaTime);
        }
    }
}
