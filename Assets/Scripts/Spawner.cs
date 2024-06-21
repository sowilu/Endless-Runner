using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public float obstacleSpeed = 10;
    public float spawnRate = 1;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Obstacle.speed = obstacleSpeed;
            var obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(obstacle);
            yield return new WaitForSeconds(spawnRate);
        }
    }
    
}
