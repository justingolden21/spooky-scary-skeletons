using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAI : MonoBehaviour
{

    private const float _movementIncrement = .1f;
    private const float _stopPoint = 3f;

    private int _witchHealth = 3;

    public GameObject _spiritFlame, _firingPoint;

    void Start()
    {
        StartCoroutine(fire());
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
    }

    private void moveLeft()
    {
        //Cancel out reverse momentum, which would have occurred when bullet makes impact with witch
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

        if (transform.position.x > _stopPoint)
            transform.position -= new Vector3(_movementIncrement, 0, 0);
    }

    private IEnumerator fire()
    {
        yield return new WaitForSeconds(3);
        GameObject _spiritFlameLeftClone = Instantiate(_spiritFlame, _firingPoint.transform.position, Quaternion.identity);
        _spiritFlameLeftClone.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);

        yield return new WaitForSeconds(.5f);
        GameObject _spiritFlameDiagDownClone = Instantiate(_spiritFlame, _firingPoint.transform.position, Quaternion.identity);
        _spiritFlameDiagDownClone.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, -1, 0);

        yield return new WaitForSeconds(.5f);
        GameObject _spiritFlameDiagUpClone = Instantiate(_spiritFlame, _firingPoint.transform.position, Quaternion.identity);
        _spiritFlameDiagUpClone.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 1, 0);

        yield return new WaitForSeconds(3);
        Destroy(_spiritFlameLeftClone);
        Destroy(_spiritFlameDiagUpClone);
        Destroy(_spiritFlameDiagDownClone);

        StartCoroutine(fire());
    }

void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CandyCorn")
        {
            _witchHealth -= 1;
            if (_witchHealth <= 0)
                Destroy(gameObject);
        }
    }
}