using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public float spawnTimer = 3f;
    public int[] isSpawned = new int[] { 0, 0, 0, 0 };
    System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 1f, spawnTimer);
	}
	
    void Spawn()
    {
        int spawnPointIndex = rnd.Next(spawnPoints.Length);
        int spawnEnemyIndex = rnd.Next(enemies.Length);

        Debug.Log(isSpawned[2]);

        if (isSpawned[spawnPointIndex] == 0)
        {
            LaneSpawn(spawnPointIndex, spawnEnemyIndex);
        }
      
        else
            return;
    }

    public void LaneSpawn(int point, int monster)
    {
        GameObject enemySpawn = Instantiate(enemies[monster], spawnPoints[point].position, spawnPoints[point].rotation);
        isSpawned[point] += 1;
        enemySpawn.GetComponent<EnemyMovement>().lane = point;
    }
	

}
