using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys bullets on collisions.  PlaneController.cs handles timed destructions :)
public class SpiritFlameDestroyer : MonoBehaviour
{
    public int _direction;

    void Update() {
        
        //transform.position += new Vector3(-.2f, .2f, 0);
        //transform.GetComponent<Rigidbody2D>().velocity = new Vector3(-4f, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Baron")
            Destroy(gameObject);
        //else
            //Physics2D.IgnoreCollision(gameObject.collider2D,collider2D);
    }
}
