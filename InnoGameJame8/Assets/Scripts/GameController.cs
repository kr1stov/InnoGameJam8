using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float levelSpeed;

    [SerializeField]
    private Text distanceText;

    [SerializeField]
    private Text scoreText;

    private float distance; 

    void Update()
    {
        distance += levelSpeed * Time.deltaTime;
        int dis = (int)distance;
        distanceText.text = dis.ToString();
    }
}
