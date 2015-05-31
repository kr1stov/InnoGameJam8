using UnityEngine;
using System.Collections;

public class Melon : MonoBehaviour {
    public delegate void MelonEvent();
    public event MelonEvent MelonHit;

    void Start()
    {
        GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<EventSystem>().InitializeMelon(this);
    }

    void OnCollisionEnter(Collision other)
    {
            if (MelonHit != null)
            {
                MelonHit();
            }
    }
}
