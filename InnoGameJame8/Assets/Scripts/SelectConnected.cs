using UnityEngine;
using System.Collections;

public class SelectConnected : MonoBehaviour {

	// Use this for initialization
	void Start () {
        HingeJoint hj = GetComponent<HingeJoint>();
        hj.connectedBody = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
