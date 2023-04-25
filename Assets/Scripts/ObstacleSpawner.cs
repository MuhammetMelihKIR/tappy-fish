using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float maxTime;
    float timer;
    public float minY;
    public float maxY;
    float randomY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameOver==false && GameManager.gameStarted ==true)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }   
       
    }
    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x,randomY);   
    }
}
