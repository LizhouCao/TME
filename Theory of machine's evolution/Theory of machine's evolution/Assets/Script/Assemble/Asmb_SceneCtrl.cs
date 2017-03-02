using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asmb_SceneCtrl : MonoBehaviour {
    // context
    public static Asmb_SceneCtrl context;

    // all component
    public Asmb_Component_Data[] Data;
    // component map
    private Dictionary<int, Asmb_Component_Data> DataMap;

    // 3d builder
    public Asmb_Builder m_builder;
    public Asmb_Builder Builder {
        get {
            return m_builder;
        }
        set {
            m_builder = value;
        }
    }

    // 2d ui
    public Asmb_UI m_ui;
    public Asmb_UI UI {
        get {
            return m_ui;
        }
        set {
            m_ui = value;
        }
    }

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

    public GameObject GetPrefabFromID (int _id) {
        return DataMap[_id].prefab.gameObject;
    }

    public GameObject GetTmpPrefabFromID (int _id) {
        return DataMap[_id].tmp_prefab.gameObject;
    }

    void Awake () {
        context = this;
        m_state = Asmb_State.WAIT;

        // build data map;
        DataMap = new Dictionary<int, Asmb_Component_Data>();
        foreach (Asmb_Component_Data data in Data) {
            DataMap.Add(data.id, data);
        }
    }

	// Use this for initialization
	void Start () {
        m_ui.ResumeWorking();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_state == Asmb_State.SELECTED_ONE_TYPE) {
            if (Input.GetMouseButtonUp(0)) {
                // Builder
            }
        }
	}

    public void SelectOneType(int _id) {
        if (m_state == Asmb_State.WAIT) {
            m_builder.ResumeBuiler(_id);
            m_state = Asmb_State.SELECTED_ONE_TYPE;
        }
    }

    public void BuildOneDone() {
        if (m_state == Asmb_State.SELECTED_ONE_TYPE) {
            m_ui.ResumeWorking();
            m_state = Asmb_State.WAIT;
        }
    }

    public void NextScene() {
        SceneManager.LoadScene("Game");
    }
}
