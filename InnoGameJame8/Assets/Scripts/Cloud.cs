using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {
    public delegate void CloudEvent();
    public event CloudEvent CloudHit;
    private ParticleSystem part;
    private PoolObject poolObj;

    void Start()
    {
        poolObj = GetComponent<PoolObject>();
        part = gameObject.GetComponentInChildren<ParticleSystem>();
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
            part.Emit(1);
            gameObject.GetComponent<PoolObject>().Deactivate();
        }
    }
}
