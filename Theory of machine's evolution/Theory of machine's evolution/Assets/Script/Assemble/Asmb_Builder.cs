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

    public GameObject[] ComponentPrefab;
    private GameObject m_prefabCurrent;

    // Use this for initialization
    void Start() {
        componentList = new List<GameObject>();
        componentMap = new GameObject[x_length, y_length, z_length];

        SetCurrentPrefab(ComponentPrefab[0]);

        AddComponents(heart, 0, 0, 0);
    }

    private void SetCurrentPrefab(GameObject _obj) {
        m_prefabCurrent = _obj;
    }

    public void BuildOn(int _x, int _y, int _z) {
        GameObject obj = Instantiate(m_prefabCurrent) as GameObject;        
        AddComponents(obj, _x, _y, _z);
    }

    private void AddComponents(GameObject _obj, int _x, int _y, int _z) {
        _obj.GetComponent<Asmb_Component>().SetPosition(_x, _y, _z);
        componentMap[_x + x_length / 2, _y + y_length / 2, _z + z_length / 2] = _obj;
    }
	
    public void 

	// Update is called once per frame
	void Update () {
		
	}
}
