using UnityEngine;
using System.Collections;


[ExecuteInEditMode]

public class GizmoHelper : MonoBehaviour {

    public float size = 0.1f;
    public Color gizmoColor;

	// Use this for initialization
	void Start () {
        gizmoColor.a = 255.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, Vector3.one*size);
    }
}
