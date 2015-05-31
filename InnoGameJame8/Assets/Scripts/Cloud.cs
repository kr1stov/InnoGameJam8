using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
    public delegate void CloudEvent();
    public event CloudEvent CloudHit;

    private PoolObject poolObj;

    void Start()
    {
        poolObj = GetComponent<PoolObject>();
        GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<EventSystem>().InitializeCloud(this);
    }

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
