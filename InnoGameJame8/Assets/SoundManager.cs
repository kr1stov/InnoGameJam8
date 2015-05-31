using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

[System.Serializable]
public class SoundCollection {
	public AudioClip[] stepSounds;
	public AudioClip[] jumpSounds;
	public AudioClip[] cloudPopSounds;
	public AudioClip[] melonSmushSounds;
	public AudioClip[] melonHitSounds;
	public AudioClip[] airborneSounds;
	public AudioClip[] landingSounds;
	public AudioClip[] shrimpCollectSounds;
}

public class SoundManager : MonoBehaviour {
	[HideInInspector]
	public static SoundManager Instance {
		get {
			return instance;
		}
	}

	public SoundCollection sounds;

	[Range(0.05f, 0.5f)] public float stepInterval = 0.2f;

	static SoundManager instance;

	void Start () {
		instance = this;

		EventSystem.PlayerJump += delegate(){
			PlayRand(sounds.jumpSounds);
			CancelInvoke("Airborn");
			InvokeRepeating("Airborn", 0f, 0.092f);
		};

		EventSystem.PlayerLand += delegate(){
			PlayRand(sounds.landingSounds);
			CancelInvoke("Airborn");
		};

		EventSystem.MelonHitEvent += delegate(){ PlayRand(sounds.melonHitSounds); };
		EventSystem.CloudDestroyEvent += delegate(){ PlayRand(sounds.cloudPopSounds); };
		EventSystem.ShrimpCollectEvent += delegate(){ PlayRand(sounds.shrimpCollectSounds); };

		EventSystem.PlayerStartRunning += delegate() {
			InvokeRepeating("Step", 0f, stepInterval);
		};

		EventSystem.PlayerStopRunning += delegate() {
			CancelInvoke("Step");
		};
	}

	void PlayRand(AudioClip[] clips) {
		if(clips.Length > 0) {
			AudioSource.PlayClipAtPoint(clips[Random.Range(0,clips.Length-1)], Vector3.zero, 1.0F);
		}
	}

	void Step() {
		PlayRand(sounds.stepSounds);
	}

	void Airborn() {
		PlayRand(sounds.airborneSounds);
	}
}
