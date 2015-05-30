using UnityEngine;
using System.Collections;

public class ParalaxPoolObject : PoolObject {
    private Quaternion rotation;

    void Awake()
    {
        rotation = this.transform.rotation;
    }

    public override void Activate(Vector3 position, Quaternion rotation, float distance)
    {
        base.Activate(position, rotation, distance);

        this.transform.rotation = this.rotation;
        this.spawnDistance = distance + (this.transform.lossyScale.x*10);
    }

    void FixedUpdate()
    {
        float fixedSpeed = speed * Time.deltaTime;
        this.transform.Translate(new Vector3(fixedSpeed, 0, 0));

        distance += fixedSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        Deactivate();
    }
}
