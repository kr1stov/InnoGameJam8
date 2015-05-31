using UnityEngine;
using System.Collections.Generic;


public class EventSystem : MonoBehaviour {

    [SerializeField]
    public ThirdPersonCharacter player;

    public List<Cloud> clouds;

    [SerializeField]
    private Shrimp shrimp;
    
    [SerializeField]
    private GameObject melon1, melon2;

    public delegate void Jump();
    public static event Jump PlayerJump;

    public delegate void Land();
    public static event Land PlayerLand;

    public delegate void StartRunning();
    public static event StartRunning PlayerStartRunning;

    public delegate void StopRunning();
    public static event StopRunning PlayerStopRunning;

    public delegate void MelonHit();
    public static event MelonHit MelonHitEvent;

    public delegate void CloudDestroy();
    public static event CloudDestroy CloudDestroyEvent;

    public delegate void ShrimpCollect();
    public static event ShrimpCollect ShrimpCollectEvent;

    public void InitializePlayer(ThirdPersonCharacter player)
    {
        player.OnJump += OnPlayerJump;
        player.OnLand += OnPlayerLand;
        player.OnStartRunning += OnPlayerStartRunning;
        player.OnStopRunning += OnPlayerStopRunning;

        shrimp.OnCollect += OnShrimpCollect;
    }

    public void InitializeCloud(Cloud cloud)
    {
        cloud.CloudHit += OnCloudDestroy;
    }

    public void InitializeShrimp(Shrimp shrimp)
    {
        shrimp.OnCollect += OnShrimpCollect;
    }

    public void InitializeMelon(Melon melon)
    {
         melon.MelonHit += OnMelonHit;
    }

    public void OnPlayerJump()
    {
        if (PlayerJump != null)
        {
            PlayerJump(); 
        }
    }

    public void OnPlayerLand()
    {
        if (PlayerLand != null)
        {
            PlayerLand();
        }
    }

    public void OnPlayerStartRunning()
    {
        if (PlayerStartRunning != null)
        {
            PlayerStartRunning();
        }
    }

    public void OnPlayerStopRunning()
    {
        if (PlayerStopRunning != null)
        {
            PlayerStopRunning();
        }
    }

    public void OnMelonHit()
    {
        if (MelonHitEvent != null)
        {
            MelonHitEvent();
        }
    }

    public void OnShrimpCollect()
    {
        if (ShrimpCollectEvent != null)
        {
            ShrimpCollectEvent();
        }
    }

    public void OnCloudDestroy()
    {
        if (CloudDestroyEvent != null)
        {
            CloudDestroyEvent();
        }
    }
}
