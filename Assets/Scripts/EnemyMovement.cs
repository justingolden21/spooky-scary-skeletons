using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private const float _movementIncrement = .04f;
    public GameObject projectile;

    private int _health = 3;
    public Color[] EnemyColor;
    private SpriteRenderer _renderer;

    private void Start()
    {
        StartCoroutine(Timer());
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = EnemyColor[_health];
    }

    // Update is called once per frame
    void Update() {
        //scene entry: The sprite flies into the screen from the right until it reaches a point
        if (transform.root.position.x > 6f)
        {
            flyLeft();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            
            _health -= 1;



            if (_health == 0)
            {
                Destroy(gameObject);
            }
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = EnemyColor[_health];
            


        }
    }


    //coroutine for enemies shooting
    IEnumerator Timer()
    {
        while (true) { 
            yield return new WaitForSeconds(3.0f); //argument of WaitForSeconds is the number of seconds the thing waits
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(transform.forward * 10);
        }
    }


    private void flyLeft()
    {
        transform.root.position -= new Vector3(_movementIncrement,0f,0f);
    }
}

