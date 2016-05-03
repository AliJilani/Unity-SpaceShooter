using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {
	public float	speed = 10f;		// The speed in m/s
	public float	fireRate = 0.3f;	// Seconds/shot (Unsused)
	public float	health = 10;		
	public int 		score = 100;		// Point earned for destroying this unit

	public int		showDamageForFrames = 2;	// # of frames to show damage
	public float	powerUpDropChance = 1f;		// Chance to drop a powerup

	public bool		________________________;

	public Color[]		originalColors;
	public Material[]	materials;	// All the materials in this and its children
	public int			remainingDamageFrames = 0;		// Damage frames left

	public Bounds		bounds; // The Bounds of this and its children
	public Vector3		boundsCenterOffset;	// Dist of bounds.center from position

	public string eType = "e0";

	public GameObject main;
	public bool mainOnline = true;
	public GameObject database;
	public GameObject EnemyProjectile;
	int shotTime = 0;
	AudioSource audio;
	//bool audioAttached = false;
	public AudioClip enemyShootSound;
	public AudioClip destructSound;

	void Awake() {
		main = GameObject.Find ("_MainCamera");
		database = GameObject.Find ("database");
		destructSound = database.GetComponent<Database> ().destroySound;
		materials = Utils.GetAllMaterials (gameObject);
		originalColors = new Color[materials.Length];

		for (int i = 0; i < materials.Length; i++) {
			originalColors [i] = materials [i].color;
		}

		InvokeRepeating ("CheckOffScreen", 0f, 2f);

		audio = this.GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {

		Move ();

		if (remainingDamageFrames > 0) {
			remainingDamageFrames--;
			if (remainingDamageFrames == 0) {
				UnShowDamage ();
			}
		}

		if(main.GetComponent<Main> ().gameLevel == "gold")
		{
			if (this.eType == "e0") {
				shotTime++;
				if (shotTime >= 100) {
					Fire ();
					shootSound();
					shotTime = 0;
				}
			}
		}

	}

	public virtual void Move() {
		Vector3 tempPos = pos;
		tempPos.y -= speed * Time.deltaTime;
		pos = tempPos;
	}

	// This is a Property: A mthod that acts like a field
	public Vector3 pos {
		get {
			return(this.transform.position);
		}
		set {
			this.transform.position = value;
		}
	}

	void CheckOffScreen() {
		// If bounds are still their default value ...
		if (bounds.size == Vector3.zero) {
			// Then set them
			bounds = Utils.CombineBoundsOfChildren (this.gameObject);

			// Also find the diff between bounds.center and transform.poisiotn
			boundsCenterOffset = bounds.center - transform.position;
		}

		// Every time, update the bounds to the current position
		bounds.center = transform.position + boundsCenterOffset;

		// Check to see whether the bounds are completely offscreen
		Vector3 off = Utils.ScreenBoundsCheck (bounds, BoundsTest.offScreen);
		try{
			if (off != Vector3.zero) {
				// If this enemy has gone off the bottom edge of the screen
				if (off.y < 0) {
					if (this.eType == "e0") {
						main.GetComponent<Main> ().enemyCounter [0]--;
					} else if (this.eType == "e1") {
						main.GetComponent<Main> ().enemyCounter [1]--;
					} else if (this.eType == "e2") {
						main.GetComponent<Main> ().enemyCounter [2]--;
					} else if (this.eType == "e3") {
						main.GetComponent<Main> ().enemyCounter [3]--;
					} else {
						main.GetComponent<Main> ().enemyCounter [4]--;
					}
					
					// Then destroy it
					Destroy (this.gameObject);
				}
			}
		}
		catch (Exception e) {
		}
	}

	void OnCollisionEnter (Collision coll) {
		GameObject other = coll.gameObject;
		switch (other.tag) {
		case "ProjectilePlayer":
			Projectile p = other.GetComponent<Projectile> ();

			// Enemies font take damage unless they are onscreen
			// This stops the player from shooting them before they are visible
			bounds.center = transform.position + boundsCenterOffset;

			if (bounds.extents == Vector3.zero || Utils.ScreenBoundsCheck (bounds, BoundsTest.offScreen) != Vector3.zero) {
				Destroy (other);
				break;
			}

			// Hurt this Enemy
			ShowDamage ();

			// Get the damage amount from the Projectile.type and Main.W_DEFS
			health -= Main.W_DEFS [p.type].damageOnHit;

			if (health <= 0) {
				
				// Tell the Main singleton that this ship has been destroyed
				destroySoundPlay ();
				Main.S.ShipDestroyed (this);
				// Destroy this Enemy
				Destroy (this.gameObject);
			}

			Destroy (other);
			break;
		}
	}

	void ShowDamage() {
		foreach (Material m in materials) {
			m.color = Color.red;
		}

		remainingDamageFrames = showDamageForFrames;
	}

	void UnShowDamage() {
		for (int i = 0; i < materials.Length; i++) {
			materials [i].color = originalColors [i];
		}
	}

	public int getScore()
	{
		if (this.eType == "e4") 
		{
			score = database.GetComponent<Database> ().enemyScores [4];
			Debug.Log ("Enemy 4 Killed");
		} 

		else if (this.eType == "e3") 
		{
			score = database.GetComponent<Database> ().enemyScores [3];
			Debug.Log ("Enemy 3 Killed");
		} 

		else if (this.eType == "e2") 
		{
			score = database.GetComponent<Database> ().enemyScores [2];
			Debug.Log ("Enemy 2 Killed");
		} 

		else if (this.eType == "e1") 
		{
			score = database.GetComponent<Database> ().enemyScores [1];
			Debug.Log ("Enemy 1 Killed");
		}

		else
		{
			score = database.GetComponent<Database> ().enemyScores [0];
			Debug.Log ("Enemy 0 Killed");
		}

		return score;
	}

	public void Fire() {//Allow the enemy to fire projectiles
		GameObject projectile = Instantiate (EnemyProjectile) as GameObject;
		projectile.transform.position = this.transform.position;
		projectile.GetComponent<Rigidbody> ().velocity = Vector3.down * 50;
	}

	public void shootSound()
	{
		audio.clip = enemyShootSound;
		audio.Play ();
	}

	public void destroySoundPlay()
	{
		Debug.Log ("ENEMY DIE SOUND SHOULD PLAY");
		audio.clip = destructSound;
		audio.Play ();
	}


}