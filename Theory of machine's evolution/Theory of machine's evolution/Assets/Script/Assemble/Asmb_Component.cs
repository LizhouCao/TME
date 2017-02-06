using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asmb_Component : MonoBehaviour {
    private int x, y, z;

    public bool IsAllAble = true;
    public string firstAble = "Up";
    public bool[] AbleList = { true, true, true, true, true, true };
    string[] directArray = { "Up", "Bottom", "Left", "Right", "Front", "Back" };

	// Use this for initialization
	void Start () {
        
    }

    public void SetPosition(int _x, int _y, int _z) {
        x = _x;
        y = _y;
        z = _z;
        this.transform.localPosition = new Vector3(x, y, z);
    }

    public void SetDirection(string _direct) {
        Dictionary<string, int[]> m_ableRotate;
        m_ableRotate = new Dictionary<string, int[]>();
        m_ableRotate.Add("Up", new int[] { 1, 0, 2, 3, 5, 4 });
        m_ableRotate.Add("Bottom", new int[] { 0, 1, 2, 3, 4, 5 });
        m_ableRotate.Add("Left", new int[] { 2, 3, 1, 0, 4, 5 });
        m_ableRotate.Add("Right", new int[] { 3, 2, 0, 1, 4, 5 });
        m_ableRotate.Add("Front", new int[] { 4, 5, 2, 3, 1, 0 });
        m_ableRotate.Add("Back", new int[] { 5, 4, 2, 3, 0, 1 });

        // m_direct = _direct;
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
        for (int i = 0; i < 5; i++) {
            this.transform.FindChild("BoundingBox/" + directArray[i]).GetComponent<BoundingBox_Plane>().buildAble = AbleList[(m_ableRotate[_direct])[i]];
        }
        this.transform.FindChild("Model").rotation = Quaternion.Euler(rotation);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ShowTmpObj(string _planeName, bool _buildAble) {
        int b_x = x;
        int b_y = y;
        int b_z = z;

        switch (_planeName) {
            case "Up":
                b_y += 1; break;
            case "Bottom":
                b_y -= 1; break;
            case "Left":
                b_x -= 1; break;
            case "Right":
                b_x += 1; break;
            case "Front":
                b_z += 1; break;
            case "Back":
                b_z -= 1; break;
        }

        // ask builder to build on b_x, b_y, b_z;
        Asmb_SceneCtrl.context.Builder.ShowTmpObj(b_x, b_y, b_z, _buildAble, _planeName);
    }

    public void HideTmpObj() {
        Asmb_SceneCtrl.context.Builder.HideTmpObj();
    }
}
