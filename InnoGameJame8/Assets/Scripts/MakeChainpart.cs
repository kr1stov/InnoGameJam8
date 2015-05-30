using UnityEngine;
using System.Collections;

public class MakeChainpart : MonoBehaviour {

    public Transform partPrefab;
   

    [SerializeField]
    private Transform currentParent;

    [SerializeField]
    private GameObject temp;

    // Use this for initialization  
	void Start () {
        currentParent = transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(partPrefab, currentParent.position + new Vector3(0.06f, 0f, 0f), Quaternion.identity) as GameObject;
            //temp.transform.parent = currentParent;
           // temp.transform.position += new Vector3(0.6f, 0f, 0f);
            temp.GetComponent<Joint>().connectedBody = currentParent.GetComponent<Rigidbody>();
            
            currentParent = temp.transform;
        }
	}

    void AttachPart()
    {

    }
}
