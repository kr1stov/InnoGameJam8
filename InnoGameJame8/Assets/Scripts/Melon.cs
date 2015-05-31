using UnityEngine;
using System.Collections;

public class Melon : MonoBehaviour {
    public delegate void MelonEvent();
    public event MelonEvent MelonHit;
    private ParticleSystem part;

    void Start()
    {
        GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<EventSystem>().InitializeMelon(this);
        part = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    void OnCollisionEnter(Collision other)
    {
        part.Emit(1);
            if (MelonHit != null)
            {
                MelonHit();
            }
    }
}
