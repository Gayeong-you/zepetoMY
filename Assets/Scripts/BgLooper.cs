using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BgLooper : MonoBehaviour
{
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition  = Vector3.zero;
    public int numBgCount = 5;
    
    void Start()
    {
        Poop[] obstacles = GameObject.FindObjectsOfType<Poop>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;
        
        for(int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);
        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }
        
        Poop obstacle = collision.GetComponent<Poop>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}