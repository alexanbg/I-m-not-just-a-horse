using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Obstacle")){
            Destroy(gameObject);
            //PlayerManager.DeadRoutine();
        }
        
    }
}
