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

    public static float LoadSpeed = 20f;

    public static bool GameLoading = true;

    void Start()
    {
        GameLoading = true;
    }

    void Update()
    {
        distance += levelSpeed * Time.deltaTime;
        int dis = (int)distance;
        distanceText.text = dis.ToString();
    }
}
