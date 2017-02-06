using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_UI : MonoBehaviour {
    // component's button
    public GameObject Button_Prefab;

    // if ui is working for user to select
    private bool m_isWorking;
    public bool IsWorking {
        get {
            return m_isWorking;
        }
    }

	// Use this for initialization
	void Start () {
        // init all componet's button
		foreach (Asmb_Component_Data data in Asmb_SceneCtrl.context.Data) {
            GameObject button = Instantiate(Button_Prefab);
            button.transform.SetParent(this.transform);
            button.GetComponent<Component_Button>().id = data.id;
            button.GetComponent<Component_Button>().SetName(data.c_name);
        }
	}

    // Update is called once per frame
    void Update() {

    }

    // select one component
    public void ComponentSelected(int _id) {
        if (m_isWorking == true) {
            m_isWorking = false;
            Asmb_SceneCtrl.context.SelectOneType(_id);
        }
    }

    // resume ui
    public void ResumeWorking() {
        m_isWorking = true;
    }
}
