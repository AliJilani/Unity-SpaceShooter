using UnityEngine;
using System.Collections;

public class Database : MonoBehaviour {

	public static Database instance;
	public int goldMaxScore;
	public int silverMaxScore;
	public int bronzeMaxScore;
	public bool bronzeScreenChoice;
	public bool silverScreenChoice;
	public bool goldScreenChoice;
	public Material bronzeMaterial;
	public Material silverMaterial;
	public Material goldMaterial;
	public bool[] bronzeEnemies = new bool[5];
	public bool[] silverEnemies = new bool[5];
	public bool[] goldEnemies = new bool[5];
	public int[] bronzeMaxEnemies = new int[5];
	public int[] silverMaxEnemies = new int[5];
	public int[] goldMaxEnemies = new int[5];
	public int[] enemyScores = new int[5];
	//public AudioClip btnClickSound;
	//public AudioSource btnClick;
	public AudioClip[] backgroundSongs = new AudioClip[3];
	public AudioClip ingameMusic;
	public AudioSource background;
	public AudioClip backgroundSong;
	public AudioClip[] promoteSongs = new AudioClip[3];
	public AudioClip promoteSong;
	public float promoteVolume = 1f;
	static bool firstStart = true;
	public Material[] backgroundImages = new Material[3];
	public Material backgroundImage;
	public GameObject backgroundQuad;
	static bool created = false;
	public AudioClip[] shootSounds = new AudioClip[3];
	public AudioClip shootSound;
	public float shootSoundVolume;
	public AudioClip[] destroySounds = new AudioClip[3];
	public AudioClip destroySound;
	public float destroySoundVolume;
	public Color enemy0Colour;
	public Color enemy1Colour;
	public Color enemy2Colour;
	public Color enemy3Colour;
	public Color enemy4Colour;

	/*
	void Awake()
	{
		if (!created)
		{
			DontDestroyOnLoad(transform.gameObject);
			created = true;
		}

		else
		{
			Destroy(transform.gameObject);
		}
		//DontDestroyOnLoad (transform.gameObject);
	}*/

	void Awake()
	{
		if (instance) {
			DestroyImmediate (gameObject);
		}
		else {
			DontDestroyOnLoad (transform.gameObject);
			instance = this;
		}
	}

	// Use this for initialization
	void Start () 
	{
		if (firstStart) {
			backgroundImage = backgroundImages [0];
			background = this.GetComponent<AudioSource> ();
			backgroundSong = backgroundSongs [0];
			this.menuMusic ();
			firstStart = false;
		}

		backgroundQuad = GameObject.Find ("Background");
		backgroundQuad.GetComponent<MeshRenderer> ().material = backgroundImage;

		for (int i=0;i<5;i++)
		{
			bronzeEnemies[i]=true;
			silverEnemies[i]=true;
			goldEnemies[i]=true;
		}

		for (int j=0;j<4;j++)
		{
			bronzeMaxEnemies[j]=1;
			silverMaxEnemies[j]=3;
			goldMaxEnemies[j]=5;
		}

		bronzeMaxEnemies [4] = 1;
		silverMaxEnemies [4] = 2;
		goldMaxEnemies [4] = 3;

		goldMaxScore=3000;
		silverMaxScore=1500;
		bronzeMaxScore=750;
		bronzeScreenChoice=false;
		silverScreenChoice=false;
		goldScreenChoice=false;
		enemyScores [0] = 100;
		enemyScores [1] = 100;
		enemyScores [2] = 100;
		enemyScores [3] = 100;
		enemyScores [4] = 400;

		shootSoundVolume = 0.6f;
		destroySoundVolume = 1f;
		promoteSong = promoteSongs [0];
		shootSound = shootSounds [0];
		destroySound = destroySounds [0];

		enemy0Colour = Color.white;
		enemy1Colour = Color.white;
		enemy2Colour = Color.white;
		enemy3Colour = Color.white;
		enemy4Colour = Color.white;

	}

	/*
	public void clickSound()
	{
		btnClick.clip = btnClickSound;
		btnClick.Play ();
	}*/

	public void gameMusic()
	{
		background.clip = ingameMusic;
		background.loop = true;
		background.Play ();
	}

	public void menuMusic()
	{
			background.clip = backgroundSong;
			background.loop = true;
			background.Play ();
	}

	// Update is called once per frame
	void Update () {
	}

}
