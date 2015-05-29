using UnityEngine;
using System.Collections;

public class ObjectGenerator : MonoBehaviour
{
    [SerializeField]
    private int spawnIntervalMin, spawnIntervalMax;
    [SerializeField]
    private float minXPos, maxXPos;
    [SerializeField]
    private float minYPos, maxYPos;

    private float timer;
    private float interval;
    private ObjectPool pool;

    void Start()
    {
        interval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > interval)
        {
            Vector3 spawnPosition = GetRandomPos();
            pool.ActivateObj(spawnPosition, Quaternion.identity);
            interval = Random.Range(spawnIntervalMin, spawnIntervalMax);

            timer = 0;
        }
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), this.transform.position.z);
    }

}