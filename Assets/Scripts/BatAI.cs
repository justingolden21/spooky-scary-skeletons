using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{

    private const float _movementIncrement = .1f;
    private const float _despawnPoint = -8f;

    private int _healthDropChance;
    private int _batHealth = 3;
    private float _startingPositionX;

    public GameObject _healthUp;

    void Start()
    {
        if (SpawnManager._miniBossSpawned)
        {
            _batHealth = 20;
            transform.localScale = new Vector3(1, 1, 0);
            _healthDropChance = 25;
            _startingPositionX = transform.position.x;
        }
        else
            _healthDropChance = Random.Range(1, 26);
    }

    void Update()
    {
        moveLeft();
    }

    private void moveLeft()
    {
        //Cancel out reverse momentum, which would have occurred when bullet makes impact with bat
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

        if (transform.position.x > _despawnPoint)
            transform.position -= new Vector3(_movementIncrement, 0, 0);
        else if (SpawnManager._miniBossSpawned)
            transform.position = new Vector3(_startingPositionX, Random.Range(-3,4), 0);
        else
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CandyCorn")
        {
            _batHealth -= 1;
            if (_batHealth <= 0) {
                if (_healthDropChance==25)
                {
                    Instantiate(_healthUp, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);

                if (SpawnManager._miniBossSpawned)
                {
                    ScoreManager._score += 800;
                    SpawnManager._miniBossSpawned = false;
                }
                else
                    ScoreManager._score += 200;
            }
        }
    }
}