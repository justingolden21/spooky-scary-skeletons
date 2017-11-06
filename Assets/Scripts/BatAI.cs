using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAI : MonoBehaviour
{

    private const float _movementIncrement = .1f;
    private const float _despawnPoint = -8f;

    private int _batHealth = 3;

    // Update is called once per frame
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
        else
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CandyCorn")
        {
            _batHealth -= 1;
            if (_batHealth <= 0)
                Destroy(gameObject);
        }
    }
}