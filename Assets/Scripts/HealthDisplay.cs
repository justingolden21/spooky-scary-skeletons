using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    public Image _health3, _health2, _health1, _health0;

	// Update is called once per frame
	void Update () {
        hideAll();
        if (PlaneController._playerHealth == 3)
            _health3.enabled = true;
        else if (PlaneController._playerHealth == 2)
            _health2.enabled = true;
        else if (PlaneController._playerHealth == 1)
            _health1.enabled = true;
        else if (PlaneController._playerHealth == 0)
            _health0.enabled = true;
            
	}

    private void hideAll() {
        _health3.enabled = false;
        _health2.enabled = false;
        _health1.enabled = false;
        _health0.enabled = false;
    }
}
