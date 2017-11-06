using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys bullets on collisions.  PlaneController.cs handles timed destructions :)
public class BulletDestroyer : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag!="Baron" && col.gameObject.tag!="CandyCorn")
            Destroy(gameObject);
    }
}
