﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinAI : MonoBehaviour
{

    private const float _movementIncrement = .1f;
    private const float _stopPoint = 3f;

    private int _healthDropChance;
    private int _pumpkinHealth = 3;

    public GameObject _Ember, _firingPoint, _healthUp;

    void Start()
    {
        if (SpawnManager._miniBossSpawned)
        {
            _pumpkinHealth = 20;
            transform.localScale = new Vector3(3, 3, 0);
            _healthDropChance = 25;
        }
        else
            _healthDropChance = Random.Range(1, 26);

        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    private void moveLeft()
    {
        //Cancel out reverse momentum, which would have occurred when bullet makes impact with pumpkin
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

        if (transform.position.x > _stopPoint)
            transform.position -= new Vector3(_movementIncrement, 0, 0);
    }

    private IEnumerator fire()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject _firstEmber = Instantiate(_Ember, _firingPoint.transform.position, Quaternion.identity);
        _firstEmber.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);

        yield return new WaitForSeconds(0.5f);

        GameObject _secondEmber = Instantiate(_Ember, _firingPoint.transform.position, Quaternion.identity);
        _secondEmber.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);

        yield return new WaitForSeconds(0.5f);

        GameObject _thirdEmber = Instantiate(_Ember, _firingPoint.transform.position, Quaternion.identity);
        _thirdEmber.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);

        yield return new WaitForSeconds(2.5f);

        if (PlaneController._gameIsActive)
            StartCoroutine(fire());
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CandyCorn")
        {
            _pumpkinHealth -= 1;
            if (_pumpkinHealth <= 0)
            {
                if (_healthDropChance == 25)
                {
                    Instantiate(_healthUp, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);

                if (SpawnManager._miniBossSpawned)
                {
                    ScoreManager._score += 500;
                    SpawnManager._miniBossSpawned = false;
                }
                else
                    ScoreManager._score += 100;
            }
        }
    }
}