﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuVariables : MonoBehaviour {
    public static bool _atMainMenu;
    public GameObject _deadBaronTitle;
	// Use this for initialization
	void Start () {
        _atMainMenu = true;
	}

    void Update()
    {
        if (_atMainMenu)
        {
            _deadBaronTitle.GetComponent<SpriteRenderer>().enabled = true;
            if (!GetComponent<AudioSource>().isPlaying) {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            _deadBaronTitle.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioSource>().Stop();
        }
    }
}
