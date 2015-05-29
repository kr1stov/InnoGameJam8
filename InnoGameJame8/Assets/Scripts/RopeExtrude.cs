using UnityEngine;
using System.Collections;

public class RopeExtrude : MonoBehaviour {

    private Mesh myMesh;

    [SerializeField]
    private Vector3[] myVertices;
    
    
    private GameObject[] gizmoGameObjects;

    public float gizmoSize = 0.1f;

    
    // Use this for initialization
	void Start () {
        this.myMesh = gameObject.GetComponent<MeshFilter>().mesh;
        this.myVertices = myMesh.vertices;

        MakeGizmoGameObjects();
	}
	
	// Update is called once per frame
	void Update () {
        Reshape();
	}

    void OnDrawGizmos()
    {
        for (int i = 0; i < gizmoGameObjects.Length; i++)
        {
            Gizmos.DrawWireCube(gizmoGameObjects[i].transform.position, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        }
    }

    void MakeGizmoGameObjects()
    {
        gizmoGameObjects = new GameObject[this.myVertices.Length];

        for (int i = 0; i < gizmoGameObjects.Length; i++)
        {
            GameObject temp = new GameObject(gameObject.name + "_Vertex_" + i);
            //temp.transform.parent = gameObject.transform;
            temp.transform.position = myVertices[i];

            gizmoGameObjects[i] = temp;
        }
    }

    void Reshape()
    {
        for (int i = 0; i < gizmoGameObjects.Length; i++)
        {
            myVertices[i] = gizmoGameObjects[i].transform.position; 
        }

        myMesh.Clear();
        myMesh.vertices = myVertices;
        myMesh.Optimize();
    }
}
