using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ObstacleCources;
    private int timer = 0;
    private GameObject lastObstacle;

    void Start(){
        lastObstacle = Instantiate(ObstacleCources[Random.Range(0,ObstacleCources.Length-1)],transform.position,Quaternion.identity);
    }


    void Update(){
        if(Vector2.Distance(transform.position, lastObstacle.transform.position)>60){
            lastObstacle = Instantiate(ObstacleCources[Random.Range(0,ObstacleCources.Length-1)],transform.position,Quaternion.identity);
        }
    }
    
}



