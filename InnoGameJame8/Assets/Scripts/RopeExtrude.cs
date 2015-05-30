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
        this.myVertices = this.myMesh.vertices;

        MakeGizmoGameObjects();
	}
	
	// Update is called once per frame
	void Update () {
        //Reshape();
	}

    void OnDrawGizmos()
    {
        if (this.gizmoGameObjects == null)
        {
            MakeGizmoGameObjects();
        }

        Gizmos.color = Color.yellow;

        for (int i = 0; i < this.gizmoGameObjects.Length; i++)
        {
            Gizmos.DrawWireCube(/*transform.position + */this.gizmoGameObjects[i].transform.position, new Vector3(gizmoSize, gizmoSize, gizmoSize));
        }
    }

    void MakeGizmoGameObjects()
    {
        this.gizmoGameObjects = new GameObject[this.myVertices.Length];

        for (int i = 0; i < this.gizmoGameObjects.Length; i++)
        {
            GameObject temp = new GameObject(gameObject.name + "_Vertex_" + i);
            temp.transform.parent = transform;
            temp.transform.position = this.myVertices[i]+transform.position;

            this.gizmoGameObjects[i] = temp;
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
