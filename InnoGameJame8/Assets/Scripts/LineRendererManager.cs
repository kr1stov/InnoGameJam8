using UnityEngine;
using System.Collections;

public class LineRendererManager : MonoBehaviour {

    [SerializeField]
    private GameObject slot; 

    private LineRenderer lr;

    public int vCount;

    //[SerializeField]
    private Vector3[] lastPositions;

    private float range = 0.025f;
   

    // Use this for initialization
	void Start () {
        this.lr = GetComponent<LineRenderer>();
        //vCount = 4;
        lr.SetVertexCount(vCount);

        lastPositions = new Vector3[vCount-1];

        for (int i = 0; i < lastPositions.Length; i++ )
        {
            lastPositions[i] = this.slot.transform.position;
        }        
	}
	
	// Update is called once per frame
	void Update () {
        //lr.SetVertexCount(i + 1);

        UpdateLastPositions(transform.position);

        //this.lr.SetPosition(0, this.slot.transform.position);
        //this.lr.SetPosition(vCount-1, transform.position);
	}

    /*public Transform GetSlot()
    {
        return slot;
    }*/

    public void SetSlot(GameObject slot)
    {
        this.slot = slot;
    }

    public void UpdateLastPositions(Vector3 newPos)
    {
        Vector3 distanceVector =  transform.position -this.slot.transform.position;
        float length = distanceVector.magnitude;
        Vector3 normalizedVector = distanceVector.normalized;
        Vector3 tempVec = new Vector3(distanceVector.x / (float)vCount, distanceVector.y / (float)vCount, distanceVector.z / (float)vCount);
        
        for (int i = this.lastPositions.Length-1; i > 0; i--)
        {
            //this.lastPositions[i] = this.lastPositions[i - 1];
            this.lastPositions[i] = slot.transform.position + tempVec * i;
            this.lastPositions[i] += new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));


            
        }
        
        this.lastPositions[0] = newPos;


        this.lr.SetPosition(0, this.slot.transform.position);
        
        for (int i = 1; i < vCount; i++)
        {
            this.lr.SetPosition(i, lastPositions[lastPositions.Length - i]);
        }

        
        //this.lr.SetPosition(1, lastPositions[2]);
        //this.lr.SetPosition(2, lastPositions[1]);
        //this.lr.SetPosition(3, lastPositions[0]);

    }
}
