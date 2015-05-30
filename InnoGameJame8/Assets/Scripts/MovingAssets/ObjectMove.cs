using UnityEngine;
using System.Collections;

public class ObjectMove : MonoBehaviour {
    [SerializeField]
    private float speed;

    public float Distance { get; set; }

    void FixedUpdate()
    {
        float fixedSpeed = speed*Time.deltaTime;
        this.transform.Translate(new Vector3(-speed, 0, 0));

        Distance += fixedSpeed;
    }
}
