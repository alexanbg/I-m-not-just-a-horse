using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseFlip : MonoBehaviour
{
    [SerializeField]
    private float midPoint;

    private SpriteRenderer spriteRenderer;
    void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(transform.position.y>midPoint){
            spriteRenderer.flipY = true;
        }
        else{
            spriteRenderer.flipY = false;
        }
    }
}
