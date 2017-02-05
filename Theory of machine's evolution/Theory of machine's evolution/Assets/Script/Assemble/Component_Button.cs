using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        print("hahahah");
        if (Asmb_SceneCtrl.context.UI.IsWorking)
            Asmb_SceneCtrl.context.UI.ComponentSelected(id);
    }
}
