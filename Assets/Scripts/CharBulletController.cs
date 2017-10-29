using UnityEngine;
using System.Collections;

public class CharBulletController : MonoBehaviour {
	
    private const float _XBulletIncrement = 5f; //bullet speed
	public Rigidbody2D RB;

	// Use this for initialization
	void Start () {
		 RB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		FlyRight();

        if (transform.root.position.x > 10)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    //method for making bullets fly right
    void FlyRight()
    {
        RB.velocity = new Vector3(_XBulletIncrement,0f,0f);
    }
}
