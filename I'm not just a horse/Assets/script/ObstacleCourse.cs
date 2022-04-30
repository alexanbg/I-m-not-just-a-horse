using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourse : MonoBehaviour
{
    [HideInInspector]
    public float speed = 1f;
    [HideInInspector]
    public float scaler;
    [HideInInspector]
    public float endYCoord;
    
    void Update()
    {
        transform.position-=new Vector3((speed+(Time.time*scaler))*Time.deltaTime,0f,0f);
        if(transform.position.y<endYCoord){
            Destroy(gameObject);
        }
    }
}
