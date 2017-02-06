using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Component_Button : MonoBehaviour {
    public int id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PointerEnter() {
        
    }

    public void PointerExit() {

    }

    public void PoinertDown() {
        if (Asmb_SceneCtrl.context.UI.IsWorking)
            Asmb_SceneCtrl.context.UI.ComponentSelected(id);
    }

    public void SetName(string _name) {
        this.transform.FindChild("Text").GetComponent<Text>().text = _name;
    }
}
