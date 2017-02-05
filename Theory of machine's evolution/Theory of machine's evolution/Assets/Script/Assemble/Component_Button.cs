using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component_Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PointerEnter() {
        print("enter " + gameObject.name);
    }

    public void PointerExit() {

    }

    public void PoinertDown() {
        print("down ");
    }
}
