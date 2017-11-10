using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {

    void Update()
    {
        if (GameMenuVariables._atMainMenu)
        {
            GetComponent<Image>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Image>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "CandyCorn")
        {
            GameMenuVariables._atMainMenu = false;
            PlaneController._gameIsActive = true;
        }
    }
}
