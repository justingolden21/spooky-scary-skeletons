using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool isCreatingEnemies = false;
    public GameObject Enemy;
    public GameObject player;
    public Transform[] spawnPoints;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isCreatingEnemies)
        {
            var character = player.GetComponent<CharController>();
            if (character != null)
            {
                if (character.Health() > 0)
                {

                    Vector3 spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position;

                    // Find a random index between zero and one less than the number of spawn points.
                    int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                    // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation
                    Instantiate(Enemy, spawnLocation, Quaternion.identity);

                    //GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                }
            }
        }
    }
}
