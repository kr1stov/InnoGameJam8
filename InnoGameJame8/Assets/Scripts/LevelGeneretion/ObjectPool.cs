using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
    [SerializeField]
    private GameObject[] ObjectPrefab;

    [SerializeField]
    private int numOfObjectsToLoadOnStart;

    private List<GameObject> activeObjects, inactiveObjects;

    public Vector3 GetPrefabPosition()
    {
        return ObjectPrefab[0].transform.position;
    }

    public ObjectGenerator objGen { get; set; }

    public EventSystem EventSys;

    public float SpawnDistance
    { get; set; }

	void Awake() {
        activeObjects = new List<GameObject>();
        inactiveObjects = new List<GameObject>();
        EventSys = GameObject.FindGameObjectWithTag("GameCtrl").GetComponent<EventSystem>();

        int arrIndex = 0;
        for (int i = 0; i < numOfObjectsToLoadOnStart; i++)
        {
            if (arrIndex >= ObjectPrefab.Length)
            {
                arrIndex = Random.Range(0, ObjectPrefab.Length - 1);
            }

            GameObject newObj = (GameObject)Instantiate(ObjectPrefab[arrIndex], Vector3.zero, ObjectPrefab[arrIndex].transform.rotation);
            GameObject parObj = (GameObject)Instantiate(newObj);

            Destroy(newObj.GetComponent<PoolObject>());
            Destroy(newObj.GetComponent<Rigidbody>());
            Destroy(newObj.GetComponent<BoxCollider>());

            parObj.GetComponent<PoolObject>().Initialize(this);
            parObj.GetComponent<PoolObject>().ScaleX = newObj.transform.lossyScale.x;
            parObj.transform.rotation = new Quaternion(0,0,0,0);
            newObj.transform.SetParent(parObj.transform);
            Destroy(parObj.GetComponent<MeshRenderer>());

            inactiveObjects.Add(parObj);
            parObj.SetActive(false); 
            arrIndex++;
        }
	}


    public void ActivateObj(Vector3 position, Quaternion rotation)
    {
        if (inactiveObjects.Count <= 0)
        {
            int rand = Random.Range(0, ObjectPrefab.Length - 1);
            GameObject newObj = (GameObject)Instantiate(ObjectPrefab[rand], Vector3.zero, ObjectPrefab[rand].transform.rotation);
            GameObject parObj = (GameObject)Instantiate(newObj);

            Destroy(newObj.GetComponent<PoolObject>());
            Destroy(newObj.GetComponent<Rigidbody>());
            Destroy(newObj.GetComponent<BoxCollider>());

            parObj.GetComponent<PoolObject>().Initialize(this);
            parObj.transform.rotation = new Quaternion(0, 0, 0, 0);
            newObj.transform.SetParent(parObj.transform);
            Destroy(parObj.GetComponent<MeshRenderer>());

            inactiveObjects.Add(parObj);
            parObj.SetActive(false); 
        }

        inactiveObjects[0].SetActive(true);
        inactiveObjects[0].GetComponent<PoolObject>().Activate(position, SpawnDistance);
        activeObjects.Add(inactiveObjects[0]);

        inactiveObjects.RemoveAt(0);
    }

    public void DeactivateObj(GameObject obj)
    {
        inactiveObjects.Add(obj);
        activeObjects.Remove(obj);
    }

    public void SpawnNew()
    {
        objGen.SpawnObject();
    }
}
