using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity=new Vector3(-4, 0, 0);
        StartCoroutine(despawnHealthUp());
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Baron")
        {
            if (PlaneController._playerHealth < 3)
                PlaneController._playerHealth += 1;
            Destroy(gameObject);
        }
    }

    private IEnumerator despawnHealthUp()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
	
	
	
}
