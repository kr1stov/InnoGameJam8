using UnityEngine;
using System.Collections;

public class ChainCommander : MonoBehaviour {

    public GameObject chainStart;
    public Transform partPrefab;

    // Use this for initialization
	void Start () {
        MakeChainpart mcp = chainStart.AddComponent<MakeChainpart>();
        mcp.partPrefab = partPrefab;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
