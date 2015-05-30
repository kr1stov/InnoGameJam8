using UnityEngine;
using System.Collections;

public class ChainCommander : MonoBehaviour {

    public Transform partPrefab;


    [SerializeField]
    private Transform currentParent;

    [SerializeField]
    private Transform globalParent;

    [SerializeField]
    GameObject temp;

    private int counter;

    // Use this for initialization
	void Start () {
        currentParent = transform;
        globalParent = transform;
        counter = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            temp = Instantiate<GameObject>(partPrefab.gameObject);
            
            //temp.transform.parent = globalParent;
            //temp.transform.localPosition = new Vector3(0.06f * counter, 0, 0);
            temp.transform.localRotation = Quaternion.EulerAngles(0, 0, 90);
            temp.transform.position = currentParent.transform.position - (currentParent.transform.right * 0.06f);


            temp.AddComponent<Rigidbody>();
            HingeJoint hj = temp.AddComponent<HingeJoint>();

            hj.axis = new Vector3(0, 0, 1);
            hj.connectedAnchor = new Vector3(0.03f, 0f, 0f);
            hj.anchor = new Vector3(-0.03f, 0f, 0f);

            hj.connectedBody = currentParent.GetComponent<Rigidbody>();

            currentParent = temp.transform;
        }
	}
}
