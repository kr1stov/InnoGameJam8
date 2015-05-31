using UnityEngine;
using System.Collections;

public class Shrimp : MonoBehaviour {
    public delegate void ShrimpDelegate();
    public event ShrimpDelegate OnCollect;

    private PoolObject poolObj;

    void Start()
    {
        poolObj = GetComponent<PoolObject>();
        GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<EventSystem>().InitializeShrimp(this);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
	    {
            if (OnCollect != null)
            {
                OnCollect();
            }

            GetComponent<PoolObject>().Deactivate();
	    }
    }
}
