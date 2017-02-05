using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_UI : MonoBehaviour {
    private bool m_isWorking;
    public bool IsWorking {
        get {
            return m_isWorking;
        }
    }

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

    }

    public void ComponentSelected(int _id) {
        if (m_isWorking == true) {
            m_isWorking = false;
            Asmb_SceneCtrl.context.SelectOneType(_id);
        }
    }

    public void ResumeWorking() {
        m_isWorking = true;
    }
}
