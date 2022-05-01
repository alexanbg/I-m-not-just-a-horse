using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePullToGround : MonoBehaviour
{
    [SerializeField]
    Vector2 vector2;

    [SerializeField]
    string  sTag;

    [SerializeField]
    Rigidbody2D Horse;

    void OnTriggerEnter2D(Collider2D collision){
        //Debug.Log("enter");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);
        if(collision.tag == sTag){
            Horse.velocity += vector2;
        }
    }
}