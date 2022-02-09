using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool isAnimal = true;
    public GameObject player;
    
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (isAnimal)
            {
                ScoreManager.instance.loseLife();
                Destroy(gameObject);
            }
            
            
            return;
        }
        
        if (isAnimal)
            ScoreManager.instance.incrementScore();
        Destroy(gameObject);
        Destroy(collider.gameObject);
    }
}
