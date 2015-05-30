using UnityEngine;
using System.Collections;


[ExecuteInEditMode]

public class GizmoHelper : MonoBehaviour {

    public float size = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one*size);
    }
}
