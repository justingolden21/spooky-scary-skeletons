using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    private const float _movementIncrement = .15f;
    private const float _playerUpperMovementLimit = 4.25f;
    private const float _playerLowerMovementLimit = -4.25f;
    private const float _playerRightMovementLimit = 1.25f;
    private const float _playerLeftMovementLimit = -5.25f;

    private int _playerHealth = 3;

    public GameObject _candyCorn, _firingPoint;

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.W))
            moveUp();
        if (Input.GetKey(KeyCode.S))
            moveDown();
        if (Input.GetKey(KeyCode.A))
            moveLeft();
        if (Input.GetKey(KeyCode.D))
            moveRight();
        if (Input.GetKeyDown(KeyCode.Space))
            fireStandard();

    }

    private void moveUp()
    {
        if (transform.position.y < _playerUpperMovementLimit)
            transform.position += new Vector3(0, _movementIncrement, 0);
    }

    private void moveDown()
    {
        if (transform.position.y > _playerLowerMovementLimit)
            transform.position -= new Vector3(0, _movementIncrement, 0);
    }

    private void moveRight()
    {
        if (transform.position.x < _playerRightMovementLimit)
            transform.position += new Vector3(_movementIncrement, 0, 0);
    }

    private void moveLeft()
    {
        if (transform.position.x > _playerLeftMovementLimit)
            transform.position -= new Vector3(_movementIncrement, 0, 0);
    }

    private void fireStandard()
    {
        GameObject _candyCornBulletClone = Instantiate(_candyCorn, _firingPoint.transform.position, Quaternion.identity);
        _candyCornBulletClone.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 0, 0);
        StartCoroutine(timedBulletDestruction(_candyCornBulletClone));
    }

    private IEnumerator timedBulletDestruction(GameObject _projectile) {
        yield return new WaitForSeconds(3);
        Destroy(_projectile);
    }

    void OnCollisionEnter2D(Collision2D col) {
        //If player was hit by an enemy or attack, grant temporary invincibility
        if (col.gameObject.tag != "CandyCorn")
        {
            _playerHealth -= 1;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            Debug.Log("Warning, player damaged!  Health: "+_playerHealth);

            if (_playerHealth <= 0) {
                Destroy(gameObject);
            }

            StartCoroutine(reApplyVulnerability());
        }
    }

    private IEnumerator reApplyVulnerability() {
        yield return new WaitForSeconds(3);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
