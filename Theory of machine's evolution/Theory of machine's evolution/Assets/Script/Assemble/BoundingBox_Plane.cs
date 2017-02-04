using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox_Plane : MonoBehaviour {
    private Color color_Yes = new Color(0.1f, 0.5f, 0.1f, 0.3f);
    private Color color_No = new Color(0.5f, 0.1f, 0.1f, 0.3f);
    private Color color_Normal;

    private bool isIn = false;

    private Asmb_Component m_parent;

    private void Awake() {
        m_parent = this.transform.parent.parent.GetComponent<Asmb_Component>();
    }

    private void OnMouseEnter() {
        PointerEnter();
    }

    private void OnMouseExit() {
        PointerExit();
    }

    void PointerEnter() {
        this.GetComponent<Renderer>().material.color = color_Yes;
        isIn = true;
    }

    void PointerExit() {
        this.GetComponent<Renderer>().material.color = color_Normal;
        isIn = false;
    }

    // Use this for initialization
    void Start () {
        color_Normal = this.GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (isIn && Input.GetMouseButtonDown(0)) {
            m_parent.BuildOn(this.gameObject.name);
        }
	}
}
