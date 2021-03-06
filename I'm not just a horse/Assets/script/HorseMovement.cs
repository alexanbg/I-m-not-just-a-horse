using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    
    [SerializeField]
    KeyCode myKey;

    [SerializeField]
    int MaxCharge;

    private Rigidbody2D rb;
    private int dashCharge = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(myKey))
        {
            Debug.Log("Space");
            if(dashCharge<MaxCharge)
                dashCharge++;
        }
        else if(dashCharge > 5){
            Dash(dashCharge, rb.velocity.y);
            dashCharge = 5;
        }
    }

    private void Dash(int _dashCharge, float _velocity){
        double  v  = Math.Round(_velocity,2);
        if(v == 0.4){
            rb.velocity = new Vector2(0, -_dashCharge);
        }
        if(v == -0.4){
            rb.velocity = new Vector2(0, _dashCharge);
        }
        if(v != 0.4 && v != -0.4 ){
            // FLip
        }
    }
}