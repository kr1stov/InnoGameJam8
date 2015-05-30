using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
    [SerializeField]
    private GameObject[] ObjectPrefab;

    [SerializeField]
    private int numOfObjectsToLoadOnStart;

    private Queue<GameObject> activeObjects, inactiveObjects;

    public Vector3 GetPrefabPosition()
    {
        return ObjectPrefab[0].transform.position;
    }

    public ObjectGenerator objGen { get; set; }

    public float SpawnDistance
    { get; set; }

	void Awake() {
        activeObjects = new Queue<GameObject>();
        inactiveObjects = new Queue<GameObject>();

        int arrIndex = 0;
        for (int i = 0; i < numOfObjectsToLoadOnStart; i++)
        {
            if (arrIndex >= ObjectPrefab.Length)
            {
                arrIndex = Random.Range(0, ObjectPrefab.Length - 1);
            }

            GameObject newObj = (GameObject)Instantiate(ObjectPrefab[arrIndex], Vector3.zero, ObjectPrefab[arrIndex].transform.rotation);
            newObj.GetComponent<PoolObject>().Initialize(this);
            newObj.SetActive(false);
            inactiveObjects.Enqueue(newObj);

            arrIndex++;
        }
	}


    public void ActivateObj(Vector3 position, Quaternion rotation)
    {
        if (inactiveObjects.Count <= 0)
        {
            GameObject objToActivate = (GameObject)Instantiate(ObjectPrefab[Random.Range(0, ObjectPrefab.Length - 1)], Vector3.zero, ObjectPrefab[Random.Range(0, ObjectPrefab.Length - 1)].transform.rotation);
            objToActivate.GetComponent<PoolObject>().Initialize(this);
            objToActivate.SetActive(false);
            inactiveObjects.Enqueue(objToActivate);
        }

        inactiveObjects.Peek().SetActive(true);
        inactiveObjects.Peek().GetComponent<PoolObject>().Activate(position, rotation, SpawnDistance);
        activeObjects.Enqueue(inactiveObjects.Peek());

        inactiveObjects.Dequeue();
    }

    public void DeactivateObj()
    {
        inactiveObjects.Enqueue(activeObjects.Peek());
        activeObjects.Dequeue();
    }

    public void SpawnNew()
    {
        objGen.SpawnObject();
    }
}
