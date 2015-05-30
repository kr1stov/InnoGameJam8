using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour
{
    [SerializeField]
    protected float speed;

    private ObjectPool myPool;

    protected float spawnDistance;

    protected float distance;

    private bool spawnedNew;

    void Update()
    {
        if (distance > spawnDistance & !spawnedNew)
        {
            myPool.SpawnNew();
            spawnedNew = true;
        }
    }

    void FixedUpdate()
    {
        float fixedSpeed = speed * Time.deltaTime;

        if (GameController.GameLoading)
        {
            fixedSpeed *= GameController.LoadSpeed;
        }

        this.transform.Translate(new Vector3(-fixedSpeed, 0, 0));

        distance += fixedSpeed;
    }

    public void Initialize(ObjectPool myPool)
    {
        this.myPool = myPool;
    }

    public virtual void Activate(Vector3 position, Quaternion rotation, float distance)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
        this.spawnDistance = distance + (this.transform.lossyScale.x);
    }

    public virtual void Deactivate()
    {
        myPool.DeactivateObj();

        if (!spawnedNew)
        {
            myPool.SpawnNew();
            spawnedNew = true;
        }

        distance = 0;
        spawnedNew = false;
        this.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        Deactivate();
    }
}