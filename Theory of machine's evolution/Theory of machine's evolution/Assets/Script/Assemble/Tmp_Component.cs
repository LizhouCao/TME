using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tmp_Component : MonoBehaviour {
    private bool m_buildAble = false;
    private string m_direct;

    public string Direct {
        get {
            return m_direct;
        }
    }
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

    public void SetDirection(string _direct) {
        m_direct = _direct;
        Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);
        switch (_direct) {
            case "Up":
                rotation = new Vector3(180.0f, 0.0f, 0.0f); break;
            case "Bottom":
                rotation = new Vector3(0.0f, 0.0f, 0.0f); break;
            case "Left":
                rotation = new Vector3(0.0f, 0.0f, -90.0f); break;
            case "Right":
                rotation = new Vector3(0.0f, 0.0f, 90.0f); break;
            case "Front":
                rotation = new Vector3(-90.0f, 0.0f, 0.0f); break;
            case "Back":
                rotation = new Vector3(90.0f, 0.0f, 0.0f); break;
        }
        this.transform.FindChild("Model").rotation = Quaternion.Euler(rotation);
    }

    // Update is called once per frame
    void Update() {

    }
}
