using UnityEngine;
using System.Collections;

public class MakeChainpart : MonoBehaviour {

    public Transform partPrefab;
   

    [SerializeField]
    private Transform currentParent;

    [SerializeField]
    //private GameObject temp;

    // Use this for initialization  
	void Start () {
        currentParent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            currentParent.position += new Vector3(0.06f, 0f, 0f);
            GameObject temp = Instantiate<GameObject>(partPrefab.gameObject);
            temp.transform.parent = currentParent;
            temp.transform.localPosition = new Vector3(0.06f, 0f, 0f);
            
            temp.AddComponent<Rigidbody>();
            HingeJoint hj = temp.AddComponent<HingeJoint>();
            
            hj.axis = new Vector3(0, 0, 1);
            hj.connectedAnchor = new Vector3(0.03f, 0f, 0f);
            hj.anchor = new Vector3(-0.03f, 0f, 0f);

            hj.connectedBody = currentParent.GetComponent<Rigidbody>();
            
            currentParent = temp.transform;
        }
	}

    void AttachPart()
    {

    }
}
