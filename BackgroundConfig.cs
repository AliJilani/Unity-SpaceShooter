using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class BackgroundConfig : MonoBehaviour {

	public GameObject pallete;
	public GameObject database;
	public int menuSelected = 0;
	public Dropdown backgroundImg;
	public GameObject backgroundQuad;

	// Use this for initialization
	void Start () {
		backgroundQuad = GameObject.Find ("Background");
		database = GameObject.Find ("database");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
		backgroundImg.onValueChanged.AddListener (delegate{backgroundChange();});
	
	}

	public void backgroundChange()
	{
		if (backgroundImg.value == 0) {
			menuSelected = 0;
			pallete.GetComponent<MeshRenderer> ().material = database.GetComponent<Database> ().backgroundImages[0];
		}
		else if(backgroundImg.value == 1){
			menuSelected = 1;
			pallete.GetComponent<MeshRenderer> ().material = database.GetComponent<Database> ().backgroundImages[1];		
		}
		else if(backgroundImg.value == 2){
			menuSelected = 2;
			pallete.GetComponent<MeshRenderer> ().material = database.GetComponent<Database> ().backgroundImages[2];		
		}
	}

	public void BackBtn()
	{
		Application.LoadLevel ("Config");
	}

	public void confirmBtn()
	{
		database.GetComponent<Database> ().backgroundImage = database.GetComponent<Database> ().backgroundImages [menuSelected];
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
