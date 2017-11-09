using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDestroyer : MonoBehaviour {
    private Vector3 _motion; 

	void Start () {
        _motion = GetComponent<Rigidbody2D>().velocity;
        if (SpawnManager._miniBossSpawned)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

	void Update () {
        if (!PlaneController._gameIsActive)
                Destroy(gameObject);

        GetComponent<Rigidbody2D>().velocity = _motion;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Baron")
            Destroy(gameObject);
    }
}
