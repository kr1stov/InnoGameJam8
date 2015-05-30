using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField]
    private float spawnDistanceMin, spawnDistanceMax;

    [SerializeField]
    private bool fixedDistance;

    [SerializeField]
    private float minYPos, maxYPos;

    [SerializeField]
    private bool fixedyPos;

    private float timer;
    private ObjectPool pool;
    private Vector3 spawnPosition;

    void Start()
    {
        pool = GetComponent<ObjectPool>();
        pool.objGen = this;
        if (!fixedDistance)
        {
            pool.SpawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax);
        }
        else
	    {
            pool.SpawnDistance = spawnDistanceMin;
	    }

        spawnPosition = new Vector3(this.transform.position.x, pool.GetPrefabPosition().y, pool.GetPrefabPosition().z);

        SpawnObject();
    }

    public void SpawnObject()
    {
        if (!fixedyPos)
        {
            spawnPosition = GetRandomPos();
        }

        pool.ActivateObj(spawnPosition, Quaternion.identity);

        if (!fixedDistance)
        {
            pool.SpawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax);
        }
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(this.transform.position.x, Random.Range(minYPos, maxYPos), spawnPosition.z);
    }

}