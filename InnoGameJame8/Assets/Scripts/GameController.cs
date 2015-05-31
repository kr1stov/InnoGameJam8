﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float distanceSpeed;

    [SerializeField]
    private Text distanceText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject LoadScreen, StartScreen, PlayerSpawnPoint, PlayerPrefab, GameOverScreen;

    private float distance;

    [SerializeField]
    private int score = 0;

    public static float LevelSpeed = 10f;

    static bool playerSpwaned;

    public static bool GameLoading = true;

    static bool GameOver = false;

    void Start()
    {
        GameLoading = true;
        EventSystem.ShrimpCollectEvent += OnShrimpCollect;
        EventSystem.PlayerLand += OnShrimpCollect;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!GameLoading)
        {
            if (!playerSpwaned)
            {
                SpawnPlayer();
                playerSpwaned = true;
            }
            if (LevelSpeed <= 3)
            {
                if (LoadScreen)
                {
                    LoadScreen.SetActive(false);
                }
                LevelSpeed = Mathf.Lerp(LevelSpeed, 1.2f, 0.02f);
            }

            distance += distanceSpeed * Time.deltaTime * LevelSpeed;
            int dis = (int)distance;
            distanceText.text = dis.ToString();
        }
        if (Time.timeScale == 0)
        {
            PlayerPrefs.SetInt("playerScore", score);
            GameOverScreen.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Application.LoadLevel("highscore");
            }
        }
    }

    public void OnStartButtonCLick()
    {
        StartScreen.SetActive(false);
    }

    public static void InitializeLevel()
    {
        LevelSpeed = 0f;
        GameLoading = false;
        playerSpwaned = false;
    }

    private void SpawnPlayer()
    {
        GameObject newObj = (GameObject)Instantiate(PlayerPrefab, PlayerSpawnPoint.transform.position, Quaternion.identity);
        this.GetComponent<EventSystem>().player = newObj.GetComponent<ThirdPersonCharacter>();
    }

    public void OnShrimpCollect()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
