using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	private const float _movementIncrement = .12f;

	private float playerVerticalPosition=0f;
	private float playerHorizontalPosition=0f;
    private float counter = 0;
    private bool hasFired = false;

    public GameObject projectile;

    public GameObject healthBar;
    private int healthBarSize = 3;

    public int _health = 3;
    private int _maxHealth = 3;
    public Color[] PlayerColor;
    private SpriteRenderer _renderer;

    // Use this for initialization
    void Start () {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        //UpdateHealthBar();
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = PlayerColor[_health];
    }

    // Update is called once per frame
    void Update () {
        
		if (Input.GetKey(KeyCode.W))
			FlyUp();
		if (Input.GetKey(KeyCode.S))
			FlyDown();
		if (Input.GetKey(KeyCode.A))
			FlyLeft();
		if (Input.GetKey(KeyCode.D))
			FlyRight();
        if (Input.GetKey(KeyCode.Space) && (!hasFired)) {
            //Debug.Log("Firing");
            hasFired = true;
            counter = 20;
            fire();
        }
        //Debug.Log(counter);
        if (hasFired) {
            counter--;
            if (counter <= 0) hasFired = false;
        }
	}

    public int Health()
    {
        return _health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "EBullet")
        {
            Debug.Log("Hit");

            UpdateHealthBar();

            _health -= 1;



            if (_health == 0)
            {
                Destroy(gameObject);
            }
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = PlayerColor[_health];
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale -= new Vector3(1, 0, 0);
        if (_health == 0)
        {
            healthBar.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    private void FlyUp() {
		if (playerVerticalPosition < 4) {
			playerVerticalPosition += _movementIncrement;
			transform.root.position += new Vector3(0, _movementIncrement, 0);
		}
	}

	private void FlyDown() {
		if (playerVerticalPosition>-4) {
			playerVerticalPosition-=_movementIncrement;
			transform.root.position -= new Vector3(0, _movementIncrement, 0);
		}
	}

	private void FlyRight() {	
		if (playerHorizontalPosition<7) {
			playerHorizontalPosition+=_movementIncrement;
			transform.root.position += new Vector3(_movementIncrement, 0, 0);
		}
	}

	private void FlyLeft() {
		if (playerHorizontalPosition>0) {
			playerHorizontalPosition-=_movementIncrement;
			transform.root.position -= new Vector3(_movementIncrement, 0, 0);
		}
	}

	private void fire() {
		
        
        GameObject bullet = Instantiate(projectile, transform.position + new Vector3(1,0,0), Quaternion.identity) as GameObject;
        Debug.Log("Boom!  :D");
	}
}
