using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourse : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float scaler;
    
    void Update()
    {
        transform.position-=new Vector3((speed+(Time.time*scaler))*Time.deltaTime,0f,0f);
    }
}
