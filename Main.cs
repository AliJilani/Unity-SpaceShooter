using UnityEngine;
using System.Collections;
using System.Collections.Generic;	// Required to use Lists or Dictionaries
using UnityEngine.UI;
using System;

public class Main : MonoBehaviour {
	static public Main S;
	static public Dictionary<WeaponType, WeaponDefinition> W_DEFS;

	public GameObject []		prefabEnemies;
	public float				enemySpawnPerSecond = 0.5f;		// Number of enemies/second
	public float				enemySpawnPadding = 1.5f;		// Padding for position
	public WeaponDefinition[]	weaponDefinitions;
	public GameObject			prefabPowerUp;
	public WeaponType[]			powerUpFrequency = new WeaponType[] {
		WeaponType.blaster, WeaponType.blaster,
		WeaponType.spread, WeaponType.shield };

	public bool			___________________________________;

	public WeaponType[]			activeWeaponTypes;
	public float				enemySpawnRate;					// Delay between enemy spawns

	public GUIText scoreGT; //Score

	public GUIText timerGT; // Time

	bool isPaused = false;

	public GameObject database;

	public Text CapitalShipCounter;
	public Text StarshipCounter;
	int csc = 0;
	int ssc = 0;
	public int[] enemyCounter = new int[5];

	public Text gameLevelDisplay;
	public string gameLevel = "bronze";

	public AudioSource promote;

	void Awake () {
		S = this;

		// Set Utils.camBounds
		Utils.SetCameraBounds (this.GetComponent<Camera>());

		// 0.5 enemies/second = enemySpawnRate of 2
		enemySpawnRate = 1f / enemySpawnPerSecond;

		// Invole call SpawnEnemy once after a 2 second delay
		Invoke ("SpawnEnemy", enemySpawnRate);

		// A generic Dictionary with WeaponType as the key
		W_DEFS = new Dictionary<WeaponType, WeaponDefinition>();
		foreach (WeaponDefinition def in weaponDefinitions) {
			W_DEFS [def.type] = def;
		}
	}

	static public WeaponDefinition GetWeaponDefinition (WeaponType wt) {
		// Check to make sure that the key exists in the Dictionaty
		// Attempting to retriece a key that didn't exist, would throw an error,
		// so the following if statement is important
		if (W_DEFS.ContainsKey (wt)) {
			return (W_DEFS [wt]);
		}

		// This will return a definintion for WeaponType.none
		// Which means it ahs failed to find the WeaponDefinition
		return (new WeaponDefinition ());
	}


	void Start () {

		database = GameObject.Find ("database");
		database.GetComponent<Database> ().gameMusic ();
		promote = this.GetComponent<AudioSource> ();
		promote.clip = database.GetComponent<Database> ().promoteSong;
		promote.volume = database.GetComponent<Database> ().promoteVolume;
		CapitalShipCounter.GetComponent<Text> ().text = "" + csc;
		StarshipCounter.GetComponent<Text> ().text = "" + ssc;
		gameLevelDisplay.text = gameLevel;

		for(int i = 0; i<5; i++)
		{
			enemyCounter [i] = 0;
		}
		// Set Utils.camBounds
		Utils.SetCameraBounds (this.GetComponent<Camera>());

		activeWeaponTypes = new WeaponType[weaponDefinitions.Length];
		for (int i = 0; i < weaponDefinitions.Length; i++) {
			activeWeaponTypes[i] = weaponDefinitions[i].type;
		}

		//Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		//Get the GUIText Component of that GameObject
		scoreGT = scoreGO.GetComponent<GUIText>();
		//Set the starting number of points to 0
		scoreGT.text = "0";

		//Find a reference to the ScoreCounter GameObject
		GameObject timerGO = GameObject.Find("Timer");
		//Get the GUIText Component of that GameObject
		timerGT = timerGO.GetComponent<GUIText>();
		//Set the starting number of points to 0
		timerGT.text = "0";
	}

	public void SpawnEnemy () {

		if (gameLevel == "bronze") 
		{
			// Pick a random Enemy prefab to instantiate
			int ndx = UnityEngine.Random.Range (0, prefabEnemies.Length);
			GameObject go;
			if (enemyCounter [ndx] != database.GetComponent<Database> ().bronzeMaxEnemies [ndx]) 
			{
				go = Instantiate (prefabEnemies [ndx]) as GameObject;

				if (go.GetComponent<Enemy>().eType == "e0") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy0Colour;
				} else if (go.GetComponent<Enemy>().eType == "e1") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy1Colour;
				} else if (go.GetComponent<Enemy>().eType == "e2") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy2Colour;
					go.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy2Colour;
				} else if (go.GetComponent<Enemy>().eType == "e3") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy3Colour;
					go.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy3Colour;
				} else if (go.GetComponent<Enemy>().eType == "e4") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
					go.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
					go.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
				}

				// Position the Enemy above the screen with a random x position
				Vector3 pos = Vector3.zero;
				float xMin = Utils.camBounds.min.x + enemySpawnPadding;
				float xMax = Utils.camBounds.max.x - enemySpawnPadding;
				pos.x = UnityEngine.Random.Range (xMin, xMax);
				pos.y = Utils.camBounds.max.y + enemySpawnPadding;
				go.transform.position = pos;

				enemyCounter [ndx]++;
			}
		}

		if (gameLevel == "silver") 
		{
			// Pick a random Enemy prefab to instantiate
			int ndx = UnityEngine.Random.Range (0, prefabEnemies.Length);
			GameObject go;
			if (enemyCounter [ndx] != database.GetComponent<Database> ().silverMaxEnemies [ndx]) 
			{
				go = Instantiate (prefabEnemies [ndx]) as GameObject;

				if (go.GetComponent<Enemy>().eType == "e0") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy0Colour;
				} else if (go.GetComponent<Enemy>().eType == "e1") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy1Colour;
				} else if (go.GetComponent<Enemy>().eType == "e2") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy2Colour;
					go.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy2Colour;
				} else if (go.GetComponent<Enemy>().eType == "e3") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy3Colour;
					go.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy3Colour;
				} else if (go.GetComponent<Enemy>().eType == "e4") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
					go.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
					go.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
				}

				// Position the Enemy above the screen with a random x position
				Vector3 pos = Vector3.zero;
				float xMin = Utils.camBounds.min.x + enemySpawnPadding;
				float xMax = Utils.camBounds.max.x - enemySpawnPadding;
				pos.x = UnityEngine.Random.Range (xMin, xMax);
				pos.y = Utils.camBounds.max.y + enemySpawnPadding;
				go.transform.position = pos;

				enemyCounter [ndx]++;
			}
		}

		if (gameLevel == "gold") 
		{
			// Pick a random Enemy prefab to instantiate
			int ndx = UnityEngine.Random.Range (0, prefabEnemies.Length);
			GameObject go;
			if (enemyCounter [ndx] != database.GetComponent<Database> ().goldMaxEnemies [ndx]) 
			{
				go = Instantiate (prefabEnemies [ndx]) as GameObject;

				if (go.GetComponent<Enemy>().eType == "e0") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy0Colour;
				} else if (go.GetComponent<Enemy>().eType == "e1") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy1Colour;
				} else if (go.GetComponent<Enemy>().eType == "e2") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy2Colour;
					go.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy2Colour;
				} else if (go.GetComponent<Enemy>().eType == "e3") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy3Colour;
					go.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy3Colour;
				} else if (go.GetComponent<Enemy>().eType == "e4") {
					go.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
					go.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
					go.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = database.GetComponent<Database> ().enemy4Colour;
				}

				// Position the Enemy above the screen with a random x position
				Vector3 pos = Vector3.zero;
				float xMin = Utils.camBounds.min.x + enemySpawnPadding;
				float xMax = Utils.camBounds.max.x - enemySpawnPadding;
				pos.x = UnityEngine.Random.Range (xMin, xMax);
				pos.y = Utils.camBounds.max.y + enemySpawnPadding;
				go.transform.position = pos;

				enemyCounter [ndx]++;
			}
		}

		// Call SpawnEnemy() again in a couple of seconds
		Invoke ("SpawnEnemy", enemySpawnRate);
	}

	/*
	public void SpawnEnemy () {

		// Pick a random Enemy prefab to instantiate
		int ndx = Random.Range (0, prefabEnemies.Length);
		GameObject go = Instantiate (prefabEnemies [ndx]) as GameObject;

		// Position the Enemy above the screen with a random x position
		Vector3 pos = Vector3.zero;
		float xMin = Utils.camBounds.min.x + enemySpawnPadding;
		float xMax = Utils.camBounds.max.x - enemySpawnPadding;
		pos.x = Random.Range (xMin, xMax);
		pos.y = Utils.camBounds.max.y + enemySpawnPadding;
		go.transform.position = pos;

		// Call SpawnEnemy() again in a couple of seconds
		Invoke ("SpawnEnemy", enemySpawnRate);
	}*/

	public void DelayedRestart (float delay) {
		// Invoke the restart() method in delay seconds
		Invoke ("Restart", delay);
	}

	public void Restart() {
		// Reload _scene_0 to restart the game
		Manager.instance.user.logsSS.Add (new Entry(DateTime.Now,Time.time,int.Parse(scoreGT.text),gameLevel));
		Application.LoadLevel ("__Scene_0");
	}

	public void ShipDestroyed (Enemy e) {

		destroySoundPlay ();
		// Potentially generate a PowerUp
		if (UnityEngine.Random.value <= e.powerUpDropChance) {
			// Random value generates a value between 0 1nd 1 although never == 1
			// If the e.powerUpDropChance is 0.50f, a powerUp will be generated
			// 50% og the time. For Testing, its now set to 1f

			// Choose which PowerUp to pick
			// Pick one from the possibilities in powerUpFrequency
			int ndx = UnityEngine.Random.Range (0, powerUpFrequency.Length);
			WeaponType puType = powerUpFrequency [ndx];

			// Spaw a PowerUp
			GameObject go = Instantiate (prefabPowerUp) as GameObject;
			PowerUp pu = go.GetComponent<PowerUp> ();

			// Set it to the proper WeaponType
			pu.SetType (puType);

			// Set it to the position of the destroyed ship
			pu.transform.position = e.transform.position;
		}

		//Parse the text of the scoreGT into an int
		int score = int.Parse(scoreGT.text);
		//Add points for catching the apple
		score += e.getScore();
		//Convert the score back to a string and display it
		scoreGT.text = score.ToString();

		if (gameLevel == "bronze") {
			if (score > database.GetComponent<Database> ().bronzeMaxScore) {
				//promote.Play ();
				PromoteSound();
				gameLevel = "silver";
				gameLevelDisplay.text = gameLevel;
			}
		}

		if (gameLevel == "silver") {
			if (score > database.GetComponent<Database> ().silverMaxScore) {
				//promote.Play ();
				PromoteSound ();
				gameLevel = "gold";
				gameLevelDisplay.text = gameLevel;
			}
		}

		if (gameLevel == "gold") {
			if (score > database.GetComponent<Database> ().goldMaxScore) {
				//promote.Play ();
				PromoteSound ();
			}
		}

		if (e.eType == "e4") {
			csc++;
			enemyCounter [4]--;
		} else if (e.eType == "e3") {
			ssc++;
			enemyCounter [3]--;
		} else if (e.eType == "e2") {
			ssc++;
			enemyCounter [2]--;
		} else if (e.eType == "e1") {
			ssc++;
			enemyCounter [1]--;
		} else {
			ssc++;
			enemyCounter [0]--;
		}

		CapitalShipCounter.GetComponent<Text> ().text = "" + csc;
		StarshipCounter.GetComponent<Text> ().text = "" + ssc;

	}

	void Update () 
	{
		//Parse the text of the scoreGT into an int
		int time = (int)Time.time;
		//Convert the score back to a string and display it
		timerGT.text = time.ToString();
	}

	public void ExitBtn()
	{
		Manager.instance.user.logsSS.Add (new Entry(DateTime.Now,Time.time,int.Parse(scoreGT.text),gameLevel));
		database.GetComponent<Database> ().menuMusic ();
		Application.LoadLevel ("Start");
	}

	public void PauseBtn()
	{
		if (isPaused == false) 
		{
			database.GetComponent<Database> ().background.Pause ();
			Debug.Log ("Paused");
			Time.timeScale = 0.0f;
			isPaused = true;
		} 

		else if (isPaused) 
		{
			database.GetComponent<Database> ().background.Play ();
			Debug.Log ("Unpaused");
			Time.timeScale = 1.0f;
			isPaused = false;
		}
	}

	public void RestartBtn()
	{
		Application.LoadLevel ("__Scene_0");
	}

	public void destroySoundPlay()
	{
		Debug.Log ("ENEMY DIE SOUND SHOULD PLAY");
		promote.clip = database.GetComponent<Database> ().destroySound;
		promote.volume = database.GetComponent<Database> ().destroySoundVolume;
		promote.Play ();
		//promote.clip = database.GetComponent<Database> ().promoteSong;
		//promote.volume = database.GetComponent<Database> ().promoteVolume;
	}

	public void PromoteSound ()
	{
		promote.clip = database.GetComponent<Database> ().promoteSong;
		promote.volume = database.GetComponent<Database> ().promoteVolume;
		promote.Play ();
	}
}
