    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {


    //_XIncrement is the speed of the bullet flying left
    private const float _XbulletIncrement = -3f;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update () {
		FlyLeft();

        if (transform.root.position.x < -10)
        {
            Destroy(gameObject);
        }
	}

    //method for making the bullet fly
    void FlyLeft()
    {        
        rb.velocity = new Vector3(_XbulletIncrement, Random.Range(-1.0f, 1.0f), 0f);
    }

}
