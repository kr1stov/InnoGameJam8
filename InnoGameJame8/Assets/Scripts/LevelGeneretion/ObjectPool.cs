﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
    [SerializeField]
    private GameObject[] ObjectPrefab;

    [SerializeField]
    private int numOfObjectsToLoadOnStart;

    private Queue<GameObject> activeObjects, inactiveObjects;

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

            GameObject newObj = (GameObject)Instantiate(ObjectPrefab[arrIndex], Vector3.zero, Quaternion.identity);
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
            GameObject objToActivate = (GameObject)Instantiate(ObjectPrefab[Random.Range(0, ObjectPrefab.Length - 1)], Vector3.zero, Quaternion.identity);
            objToActivate.GetComponent<PoolObject>().Initialize(this);
            objToActivate.SetActive(false);
            inactiveObjects.Enqueue(objToActivate);
        }

        inactiveObjects.Peek().SetActive(true);
        inactiveObjects.Peek().GetComponent<PoolObject>().Activate(position, rotation);
        activeObjects.Enqueue(inactiveObjects.Peek());

        inactiveObjects.Dequeue();
    }

    public void DeactivateObj()
    {
        inactiveObjects.Enqueue(activeObjects.Peek());
        activeObjects.Dequeue();
    }
}