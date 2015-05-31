using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
    public delegate void CloudEvent();
    public event CloudEvent CloudHit;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Melon")
        {
            if (CloudHit != null)
            {
                CloudHit();
            }

            gameObject.GetComponent<PoolObject>().Deactivate();
        }
    }
}
