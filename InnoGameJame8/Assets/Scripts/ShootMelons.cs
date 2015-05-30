using UnityEngine;
using System.Collections;

public class ShootMelons : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float power;

    [SerializeField]
    private float explosionPower;

    private Vector3 distanceVector;

    [SerializeField]
    private GameObject[] melons;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Target").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            melons = GameObject.FindGameObjectsWithTag("Melon");

            foreach(GameObject m in melons)
            {
                distanceVector = target.position - m.transform.position;
                distanceVector.Normalize();
                //m.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, transform.position, 1);
                m.GetComponent<Rigidbody>().AddForce(distanceVector * power, ForceMode.Impulse);
                //m.GetComponent<Rigidbody>().AddTorque(distanceVector * power, ForceMode.Impulse);
            }
            
            
        }
	}
}
