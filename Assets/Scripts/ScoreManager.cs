using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int _score=0;
	
	// Update is called once per frame
	void Update () {
        GetComponent<UnityEngine.UI.Text>().text = "Score: "+_score;
	}
}
