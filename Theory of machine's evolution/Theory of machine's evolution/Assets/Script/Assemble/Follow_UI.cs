﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<RectTransform>().position = Input.mousePosition;
	}
}