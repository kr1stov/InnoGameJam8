using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float levelSpeed;

    private float distance; 

    void Update()
    {
        distance += levelSpeed * Time.deltaTime;
    }
}
