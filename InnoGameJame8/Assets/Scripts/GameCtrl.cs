using UnityEngine;
using System.Collections;

public class GameCtrl : MonoBehaviour
{
    [SerializeField]
    private float levelSpeed;

    private float distance; 

    void Update()
    {
        distance += levelSpeed * Time.deltaTime;
    }
}
