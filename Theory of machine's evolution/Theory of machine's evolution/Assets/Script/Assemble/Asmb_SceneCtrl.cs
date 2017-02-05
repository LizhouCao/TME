using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_SceneCtrl : MonoBehaviour {
    public static Asmb_SceneCtrl context;
    public Asmb_Builder m_builder;
    public Asmb_UI m_ui;

    public enum Asmb_State {
        WAIT = 0,
        SELECTED_ONE_TYPE = 1
    }

    private Asmb_State m_state;
    public Asmb_State Current_State {
        get {
            return m_state;
        }
    }


    void Awake () {
        context = this;
        m_state = Asmb_State.WAIT;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectOneType() {
        m_state = Asmb_State.SELECTED_ONE_TYPE;
    }

    public void BuildOneDone() {

    }
}
