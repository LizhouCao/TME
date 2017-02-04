using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_Component : MonoBehaviour {
    private int x, y, z;

	// Use this for initialization
	void Start () {
		
	}

    public void SetPosition(int _x, int _y, int _z) {
        x = _x;
        y = _y;
        z = _z;
        this.transform.localPosition = new Vector3(x, y, z);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuildOn(string _planeName) {
        int b_x = x;
        int b_y = y;
        int b_z = z;

        switch (_planeName){
            case "Up":
                b_y += 1;  break;
            case "Bottom":
                b_y -= 1;  break;
            case "Left":
                b_x -= 1;  break;
            case "Right":
                b_x += 1;  break;
            case "Front":
                b_z += 1;  break;
            case "Back":
                b_z -= 1;  break;
        }

        // ask builder to build on b_x, b_y, b_z;
        Asmb_SceneCtrl.context.m_builder.BuildOn(b_x, b_y, b_z);
    }
}
