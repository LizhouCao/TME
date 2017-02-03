using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_Camera : MonoBehaviour {
    public GameObject body;
    public GameObject sphere;

    private float xl, yl;
    private int type = 0;

    private float ynum = 0.0f;
    private float maxDegree = 0.5f;
    private float minDegree = -1.2f;

    public float hua = 0.0f;
    private float maxDistance = 2.0f;
    private float minDistance = -0.4f;

    // Use this for initialization
    void Start() {
    }

    public void setBody(GameObject obj) {
        body = obj;
        transform.LookAt(body.transform.position);
    }

    // Update is called once per frame
    void Update() {
        if (body != null && Input.GetMouseButton(1)) {
            if (type == 0) {
                type = 1;
                xl = Input.mousePosition.x;
                yl = Input.mousePosition.y;
            }
            else
                mRotate();
        }
        else {
            type = 0;
        }
        mTransform();

    }

    void mTransform() {
        float tmp = Input.GetAxis("Mouse ScrollWheel");
        if (tmp != 0.0f) {
            if (hua + tmp > minDistance && hua + tmp < maxDistance) {
                hua += tmp;
                transform.Translate(new Vector3(0.0f, 0.0f, tmp * 3.0f));
            }
        }
    }

    void mRotate() {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float dx = xl - x;
        float dy = yl - y;
        xl = x;
        yl = y;

        sphere.transform.RotateAround(new Vector3(0.0f, 1.0f, 0.0f), -dx / 100.0f);

        if (ynum + dy / 100.0f >= minDegree && ynum + dy / 100.0f < maxDegree) {
            ynum += dy / 100.0f;
            sphere.transform.RotateAround(sphere.transform.right, dy / 100.0f);
        }
        transform.LookAt(body.transform.position);
    }
}
