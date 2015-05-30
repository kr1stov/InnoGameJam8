using UnityEngine;
using System.Collections;

public class LineRendererManager : MonoBehaviour {

    [SerializeField]
    private GameObject slot; 

    private LineRenderer lr;

    // Use this for initialization
	void Start () {
        this.lr = GetComponent<LineRenderer>();
        //i = 0;
        //lr.SetVertexCount(2);
        //lr.SetPosition(0, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        //lr.SetVertexCount(i + 1);
        this.lr.SetPosition(0, this.slot.transform.position);
        this.lr.SetPosition(1, transform.position);
	}

    /*public Transform GetSlot()
    {
        return slot;
    }*/

    public void SetSlot(GameObject slot)
    {
        this.slot = slot;
    }
}
