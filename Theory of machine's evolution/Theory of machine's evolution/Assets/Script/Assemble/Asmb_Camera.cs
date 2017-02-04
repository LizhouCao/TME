using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_Camera : MonoBehaviour {
    // mouse position for last frame
    private float xl, yl;
    // mouse button is down
    private int type = 0;

    private float m_rotateSpeed = 0.5f;
    private float m_yDegree = 0.0f;
    // y degree range
    private float maxDegree = 60f;
    private float minDegree = -60f;

    // camera's scale
    private float m_scale = 1.0f;
    private float m_scaleSpeed = 0.5f;
    private float maxScale = 3.0f;
    private float minScale = 0.5f;

    // Use this for initialization
    void Start() {
        m_yDegree = this.transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(1)) {
            // first down
            if (type == 0) {
                type = 1;
                xl = Input.mousePosition.x;
                yl = Input.mousePosition.y;
            }
            else
                SphereRotate();
        }
        else {
            type = 0;
        }
        SphereScale();
    }

    void SphereScale() {
        float tmp = - m_scaleSpeed * Input.GetAxis("Mouse ScrollWheel");
        if (tmp != 0.0f) {
            if (m_scale + tmp > minScale && m_scale + tmp < maxScale) {
                m_scale += tmp;
                this.transform.localScale = m_scale * Vector3.one;
            }
        }
    }

    void SphereRotate() {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float dx = m_rotateSpeed * (xl - x);
        float dy = m_rotateSpeed * (yl - y);
        xl = x;
        yl = y;

        // rotate around Y
        this.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), -dx, Space.World);

        // rotate around X
        if (m_yDegree + dy >= minDegree && m_yDegree + dy < maxDegree) {
            m_yDegree += dy;
            this.transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f), dy);
        }
    }
}
