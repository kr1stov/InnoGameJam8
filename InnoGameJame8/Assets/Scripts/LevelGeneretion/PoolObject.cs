using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour
{
    protected ObjectPool myPool;

    public virtual void Initialize(ObjectPool myPool)
    {
        this.myPool = myPool;
    }

    public virtual void Activate(Vector3 position, Quaternion rotation)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
    }

    public virtual void Deactivate()
    {
        myPool.DeactivateObj();
        this.gameObject.SetActive(false);
    }
}