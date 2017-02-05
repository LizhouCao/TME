using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox_Plane : MonoBehaviour {
    public static Color color_Yes = new Color(0.1f, 0.5f, 0.1f, 0.3f);
    public static Color color_No = new Color(0.5f, 0.1f, 0.1f, 0.3f);
    private Color color_Normal;

    private bool isIn = false;

    private Asmb_Component m_parent;

    public bool buildAble = true;

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
        if (buildAble)
            this.GetComponent<Renderer>().material.color = color_Yes;
        else
            this.GetComponent<Renderer>().material.color = color_No;
        isIn = true;
        m_parent.ShowTmpObj(this.name, buildAble);
    }

    void PointerExit() {
        this.GetComponent<Renderer>().material.color = color_Normal;
        isIn = false;
        m_parent.HideTmpObj();
    }

    // Use this for initialization
    void Start () {
        color_Normal = this.GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
