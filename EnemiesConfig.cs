using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
//using UnityEditor;

public class EnemiesConfig : MonoBehaviour {

	public Slider e0slider;
	public Slider e1slider;
	public Slider e2slider;
	public Slider e3slider;
	public Slider e4slider;
	public Dropdown e0color;
	public Dropdown e1color;
	public Dropdown e2color;
	public Dropdown e3color;
	public Dropdown e4color;
	public Text e0score;
	public Text e1score;
	public Text e2score;
	public Text e3score;
	public Text e4score;
	//private GameObject enemy0;
	//private GameObject enemy1;
	//private GameObject enemy2;
	//private GameObject enemy3;
	//private GameObject enemy4;
	public GameObject enemy0Ins;
	public GameObject enemy1Ins;
	public GameObject enemy2Ins;
	public GameObject enemy3Ins;
	public GameObject enemy4Ins;
	public GameObject database;
	public GameObject backgroundQuad;

	// Use this for initialization
	void Start () {

		database = GameObject.Find ("database");
		e0slider.value = database.GetComponent<Database> ().enemyScores [0];
		e1slider.value = database.GetComponent<Database> ().enemyScores [1];
		e2slider.value = database.GetComponent<Database> ().enemyScores [2];
		e3slider.value = database.GetComponent<Database> ().enemyScores [3];
		e4slider.value = database.GetComponent<Database> ().enemyScores [4];
		e0slider.onValueChanged.AddListener (delegate{e0sliderCalled();});
		e1slider.onValueChanged.AddListener (delegate{e1sliderCalled();});
		e2slider.onValueChanged.AddListener (delegate{e2sliderCalled();});
		e3slider.onValueChanged.AddListener (delegate{e3sliderCalled();});
		e4slider.onValueChanged.AddListener (delegate{e4sliderCalled();});
		e0color.onValueChanged.AddListener (delegate {dropdown1Called();});
		e1color.onValueChanged.AddListener (delegate {dropdown2Called();});
		e2color.onValueChanged.AddListener (delegate {dropdown3Called();});
		e3color.onValueChanged.AddListener (delegate {dropdown4Called();});
		e4color.onValueChanged.AddListener (delegate {dropdown5Called();});
		enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy0Colour;
		enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy1Colour;
		enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy2Colour;
		enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy2Colour;
		enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy3Colour;
		enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy3Colour;
		enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy4Colour;
		enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy4Colour;
		enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color =database.GetComponent<Database> ().enemy4Colour;
		//enemy0 = AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Enemy_0.prefab", typeof(GameObject)) as GameObject;
		//enemy1 = AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Enemy_1.prefab", typeof(GameObject)) as GameObject;
		//enemy2 = AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Enemy_2.prefab", typeof(GameObject)) as GameObject;
		//enemy3 = AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Enemy_3.prefab", typeof(GameObject)) as GameObject;
		//enemy4 = AssetDatabase.LoadAssetAtPath("Assets/_Prefabs/Enemy_4.prefab", typeof(GameObject)) as GameObject;

		backgroundQuad = GameObject.Find ("Background");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void e0sliderCalled()
	{
		Debug.Log ("e0sliderCalled");
		e0score.GetComponent<Text> ().text = (int)e0slider.value+"";
		database.GetComponent<Database> ().enemyScores [0]=Convert.ToInt32(e0slider.value);
	}

	public void e1sliderCalled()
	{
		Debug.Log ("e1sliderCalled");
		e1score.GetComponent<Text> ().text = (int)e1slider.value+"";
		database.GetComponent<Database> ().enemyScores [1]=Convert.ToInt32(e1slider.value);
	}

	public void e2sliderCalled()
	{
		Debug.Log ("e2sliderCalled");
		e2score.GetComponent<Text> ().text = (int)e2slider.value+"";
		database.GetComponent<Database> ().enemyScores [2]=Convert.ToInt32(e2slider.value);
	}

	public void e3sliderCalled()
	{
		Debug.Log ("e3sliderCalled");
		e3score.GetComponent<Text> ().text = (int)e3slider.value+"";
		database.GetComponent<Database> ().enemyScores [3]=Convert.ToInt32(e3slider.value);
	}

	public void e4sliderCalled()
	{
		Debug.Log ("e4sliderCalled");
		e4score.GetComponent<Text> ().text = (int)e4slider.value+"";
		database.GetComponent<Database> ().enemyScores [4]=Convert.ToInt32(e4slider.value);
	}

	public void dropdown1Called()
	{
		Debug.Log ("dropdown1Called");
		if (e0color.value == 0) {
			database.GetComponent<Database> ().enemy0Colour = Color.white;
			//enemy0.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.white;
			enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.white;
		}
		else if (e0color.value == 1) {
			database.GetComponent<Database> ().enemy0Colour = Color.blue;
			//enemy0.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.blue;
			enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		else if (e0color.value == 2) {
			database.GetComponent<Database> ().enemy0Colour = Color.black;
			//enemy0.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.black;
			enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.black;
		}
		else if (e0color.value == 3) {
			database.GetComponent<Database> ().enemy0Colour = Color.cyan;
			//enemy0.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.cyan;
			enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.cyan;
		}
		else if (e0color.value == 4) {
			database.GetComponent<Database> ().enemy0Colour = Color.green;
			//enemy0.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.green;
			enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.green;
		}
		else if (e0color.value == 5) {
			database.GetComponent<Database> ().enemy0Colour = Color.red;
			//enemy0.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.red;
			enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.red;
		}
		else if (e0color.value == 6) {
			database.GetComponent<Database> ().enemy0Colour = Color.yellow;
			//enemy0.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.yellow;
			enemy0Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.yellow;
		}
	}

	public void dropdown2Called()
	{
		Debug.Log ("dropdown2Called");
		if (e1color.value == 0) {
			database.GetComponent<Database> ().enemy1Colour = Color.white;
			//enemy1.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.white;
			enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.white;
			//enemy1Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.white;
		}
		else if (e1color.value == 1) {
			database.GetComponent<Database> ().enemy1Colour = Color.blue;
			//enemy1.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.blue;
			enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.blue;
			//enemy1Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		else if (e1color.value == 2) {
			database.GetComponent<Database> ().enemy1Colour = Color.black;
			//enemy1.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.black;
			enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.black;
			//enemy1Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.black;
		}
		else if (e1color.value == 3) {
			database.GetComponent<Database> ().enemy1Colour = Color.cyan;
			//enemy1.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.cyan;
			enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.cyan;
			//enemy1Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.cyan;
		}
		else if (e1color.value == 4) {
			database.GetComponent<Database> ().enemy1Colour = Color.green;
			//enemy1.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.green;
			enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.green;
			//enemy1Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.green;
		}
		else if (e1color.value == 5) {
			database.GetComponent<Database> ().enemy1Colour = Color.red;
			//enemy1.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.red;
			enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.red;
			//enemy1Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.red;
		}
		else if (e1color.value == 6) {
			database.GetComponent<Database> ().enemy1Colour = Color.yellow;
			//enemy1.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.yellow;
			enemy1Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.yellow;
			//enemy1Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.yellow;
		}
	}

	public void dropdown3Called()
	{
		Debug.Log ("dropdown3Called");
		if (e2color.value == 0) {
			database.GetComponent<Database> ().enemy2Colour = Color.white;
			//enemy2.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.white;
			enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.white;
			enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.white;
		}
		else if (e2color.value == 1) {
			database.GetComponent<Database> ().enemy2Colour = Color.blue;
			//enemy2.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.blue;
			enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.blue;
			enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		else if (e2color.value == 2) {
			database.GetComponent<Database> ().enemy2Colour = Color.black;
			//enemy2.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.black;
			enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.black;
			enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.black;

		}
		else if (e2color.value == 3) {
			database.GetComponent<Database> ().enemy2Colour = Color.cyan;
			//enemy2.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.cyan;
			enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.cyan;
			enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.cyan;
		}
		else if (e2color.value == 4) {
			database.GetComponent<Database> ().enemy2Colour = Color.green;
			//enemy2.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.green;
			enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.green;
			enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.green;
		}
		else if (e2color.value == 5) {
			database.GetComponent<Database> ().enemy2Colour = Color.red;
			//enemy2.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.red;
			enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.red;
			enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.red;
		}
		else if (e2color.value == 6) {
			database.GetComponent<Database> ().enemy2Colour = Color.yellow;
			//enemy2.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.yellow;
			enemy2Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.yellow;
			enemy2Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.yellow;
		}
	}

	public void dropdown4Called()
	{
		Debug.Log ("dropdown4Called");
		if (e3color.value == 0) {
			database.GetComponent<Database> ().enemy3Colour = Color.white;
		//	enemy3.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.white;
			enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.white;
			enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.white;
		}
		else if (e3color.value == 1) {
			database.GetComponent<Database> ().enemy3Colour = Color.blue;
			//enemy3.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.blue;
			enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.blue;
			enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		else if (e3color.value == 2) {
			database.GetComponent<Database> ().enemy3Colour = Color.black;
			//enemy3.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.black;
			enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.black;
			enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.black;
		}
		else if (e3color.value == 3) {
			database.GetComponent<Database> ().enemy3Colour = Color.cyan;
			//enemy3.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.cyan;
			enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.cyan;
			enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.cyan;
		}
		else if (e3color.value == 4) {
			database.GetComponent<Database> ().enemy3Colour = Color.green;
			//enemy3.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.green;
			enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.green;
			enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.green;
		}
		else if (e3color.value == 5) {
			database.GetComponent<Database> ().enemy3Colour = Color.red;
			//enemy3.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.red;
			enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.red;
			enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.red;
		}
		else if (e3color.value == 6) {
			database.GetComponent<Database> ().enemy3Colour = Color.yellow;
			//enemy3.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.yellow;
			enemy3Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.yellow;
			enemy3Ins.transform.GetChild (1).GetComponent<MeshRenderer> ().material.color = Color.yellow;
		}
	}

	public void dropdown5Called()
	{
		Debug.Log ("dropdown5Called");
		if (e4color.value == 0) {
			database.GetComponent<Database> ().enemy4Colour = Color.white;
			//enemy4.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.white;
			enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.white;
			enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.white;
			enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = Color.white;
		}
		else if (e4color.value == 1) {
			database.GetComponent<Database> ().enemy4Colour = Color.blue;
			//enemy4.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.blue;
			enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.blue;
			enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.blue;
			enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
		else if (e4color.value == 2) {
			database.GetComponent<Database> ().enemy4Colour = Color.black;
			//enemy4.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.black;
			enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.black;
			enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.black;
			enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = Color.black;
		}
		else if (e4color.value == 3) {
			database.GetComponent<Database> ().enemy4Colour = Color.cyan;
			//enemy4.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.cyan;
			enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.cyan;
			enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.cyan;
			enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = Color.cyan;
		}
		else if (e4color.value == 4) {
			database.GetComponent<Database> ().enemy4Colour = Color.green;
			//enemy4.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.green;
			enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.green;
			enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.green;
			enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = Color.green;
		}
		else if (e4color.value == 5) {
			database.GetComponent<Database> ().enemy4Colour = Color.red;
			//enemy4.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.red;
			enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.red;
			enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.red;
			enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = Color.red;
		}
		else if (e4color.value == 6) {
			database.GetComponent<Database> ().enemy4Colour = Color.yellow;
			//enemy4.transform.GetChild (0).GetComponent<MeshRenderer> ().sharedMaterial.color = Color.yellow;
			enemy4Ins.transform.GetChild (0).GetComponent<MeshRenderer> ().material.color = Color.yellow;
			enemy4Ins.transform.GetChild (2).GetComponent<MeshRenderer> ().material.color = Color.yellow;
			enemy4Ins.transform.GetChild (3).GetComponent<MeshRenderer> ().material.color = Color.yellow;
		}
	}


	public void BackBtn()
	{
		Application.LoadLevel ("Config");
	}
}
