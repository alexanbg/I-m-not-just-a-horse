using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ObstacleCources;
    private int timer = 0;
    private GameObject lastObstacle;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float scaler;
    [SerializeField]
    private float endYCoord;

    void Start(){
        SpawnObstacle();
    }


    void Update(){
        if(Vector2.Distance(transform.position, lastObstacle.transform.position)>lastObstacle.GetComponent<ObstacleCourse>().length+lastObstacle.GetComponent<ObstacleCourse>().speed*2){
            SpawnObstacle();
        }
    }

    private void SpawnObstacle(){
        lastObstacle = Instantiate(ObstacleCources[Random.Range(0,ObstacleCources.Length-1)],transform.position,Quaternion.identity);
        lastObstacle.GetComponent<ObstacleCourse>().speed = speed;
        lastObstacle.GetComponent<ObstacleCourse>().scaler = scaler;
        lastObstacle.GetComponent<ObstacleCourse>().endYCoord = endYCoord;
    }
    
}



