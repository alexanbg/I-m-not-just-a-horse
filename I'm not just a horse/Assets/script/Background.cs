using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float scaler;
    [SerializeField]
    private Vector3 endYCoord;
    [SerializeField]
    private Vector3 startYCoord;

    // Update is called once per frame
    void Update()
    {
        transform.position-=new Vector3((speed+(Time.time*scaler))*Time.deltaTime,0f,0f);
        if(transform.position.x<endYCoord.x){
            transform.position = startYCoord;
        }
    }
}
