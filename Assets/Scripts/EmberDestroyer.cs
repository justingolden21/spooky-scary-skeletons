using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberDestroyer : MonoBehaviour
{

    void Start()
    {
        if (SpawnManager._miniBossSpawned)
        {
            transform.localScale = new Vector3(2, 2, 0);
        }
        StartCoroutine(timedDestruction());
    }

    void Update()
    {
        if (!PlaneController._gameIsActive)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Baron")
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator timedDestruction()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
