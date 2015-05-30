using UnityEngine;
using System.Collections;

public class ConnectToParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    GetComponent<SpringJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
