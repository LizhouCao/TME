using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tmp_Component : MonoBehaviour {
    private bool m_buildAble = false;
    public bool BuildAble {
        get {
            return m_buildAble;
        }
    }

    public void SetPosition(int _x, int _y, int _z) {
        this.transform.localPosition = new Vector3(_x, _y, _z);
    }

    public void SetAble(bool _ableBuild) {
        m_buildAble = _ableBuild;
        if (_ableBuild) {
            this.transform.FindChild("BoundingBox").GetComponent<Renderer>().material.color = BoundingBox_Plane.color_Yes;
        }
        else {
            this.transform.FindChild("BoundingBox").GetComponent<Renderer>().material.color = BoundingBox_Plane.color_No;
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
