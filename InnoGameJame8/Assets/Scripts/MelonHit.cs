using UnityEngine;
using System.Collections;

public class MelonHit : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cloud")
	    {
            Destroy(other.gameObject);
	    }
    }
}
