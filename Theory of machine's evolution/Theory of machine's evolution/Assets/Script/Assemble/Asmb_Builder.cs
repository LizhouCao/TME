using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_Builder : MonoBehaviour {
    private List<GameObject> componentList;
    public GameObject heart;

    // x, y, z of maximum
    private int x_length = 15;
    private int z_length = 15;
    private int y_length = 10;

    private GameObject[,,] componentMap;

    public GameObject FollowUIObj;
    private Tmp_Component m_tmpComponent;
    private int m_tx, m_ty, m_tz;

    // the current Prefab
    private int m_currentId;

    // the builder is working
    private bool m_isWorking = false;
    public bool IsWorking {
        get {
            return m_isWorking;
        }
    }

    // Use this for initialization
    void Start() {
        componentList = new List<GameObject>();
        componentMap = new GameObject[x_length, y_length, z_length];
        AddComponents(heart, 0, 0, 0);
    }

    // build one component at position x, y, z
    public void BuildOn(int _x, int _y, int _z) {
        if (IsWorking) {
            GameObject obj = Instantiate(Asmb_SceneCtrl.context.GetPrefabFromID(m_currentId));
            this.AddComponents(obj, _x, _y, _z);
            this.StopBuilder();    
        }
    }

    public void ShowTmpObj(int _x, int _y, int _z, bool _buildAble) {
        if (IsWorking) {
            m_tmpComponent.SetPosition(_x, _y, _z);
            m_tmpComponent.SetAble(_buildAble);
            m_tx = _x; m_ty = _y; m_tz = _z;
            m_tmpComponent.gameObject.SetActive(true);
            FollowUIObj.SetActive(false);
        }
    }

    public void HideTmpObj() {
        if (IsWorking) {
            m_tmpComponent.gameObject.SetActive(false);
            FollowUIObj.SetActive(true);
        }
    }

    private void AddComponents(GameObject _obj, int _x, int _y, int _z) {
        _obj.GetComponent<Asmb_Component>().SetPosition(_x, _y, _z);
        componentMap[_x + x_length / 2, _y + y_length / 2, _z + z_length / 2] = _obj;
    }
	
    public void ResumeBuiler(int _id) {
        m_currentId = _id;
        m_isWorking = true;
        InitTmpObj();
    }

    public void StopBuilder() {
        m_isWorking = false;

        FollowUIObj.SetActive(false);
        Destroy(m_tmpComponent.gameObject);
        Asmb_SceneCtrl.context.BuildOneDone();
    }

	// Update is called once per frame
	void Update () {
		if (IsWorking == true && Input.GetMouseButtonUp(0)) {
            if (m_tmpComponent.gameObject.activeSelf == true && m_tmpComponent.BuildAble == true) {
                BuildOn(m_tx, m_ty, m_tz);           
            }
            StopBuilder();
        }
	}

    void InitTmpObj() {
        // transparency
        m_tmpComponent = Instantiate(Asmb_SceneCtrl.context.GetTmpPrefabFromID(m_currentId)).GetComponent<Tmp_Component>();
        foreach (Renderer rd in m_tmpComponent.transform.GetComponentsInChildren<Renderer>()) {
            foreach (Material m in rd.materials)
                m.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
        }
        HideTmpObj();
    }
}
