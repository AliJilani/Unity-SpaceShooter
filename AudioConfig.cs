using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AudioConfig : MonoBehaviour {

	public Slider backgroundSlider;
	public Slider victorySlider;
	public Dropdown backgroundDropdown;
	public Dropdown victoryDropdown;
	public GameObject database;
	public GameObject backgroundQuad;

	// Use this for initialization
	void Start () {

		database = GameObject.Find ("database");
		backgroundSlider.value = database.GetComponent<AudioSource> ().volume;
		victorySlider.value = database.GetComponent<Database> ().promoteVolume;
		backgroundSlider.onValueChanged.AddListener (delegate{backgroundSliderCalled();});
		victorySlider.onValueChanged.AddListener (delegate{victorySliderCalled();});
		backgroundDropdown.onValueChanged.AddListener (delegate{backgroundSongChange();});
		victoryDropdown.onValueChanged.AddListener (delegate{victorySongChange();});
		backgroundQuad = GameObject.Find ("Background");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	}

	public void backgroundSliderCalled()
	{
		database.GetComponent<AudioSource> ().volume = backgroundSlider.value;
	}

	public void victorySliderCalled()
	{
		database.GetComponent<Database> ().promoteVolume = victorySlider.value;
	}

	public void backgroundSongChange()
	{
		if (backgroundDropdown.value == 0) {
			database.GetComponent<Database> ().backgroundSong = database.GetComponent<Database> ().backgroundSongs [0];
		}
		else if(backgroundDropdown.value == 1){
			database.GetComponent<Database> ().backgroundSong = database.GetComponent<Database> ().backgroundSongs [1];
		}
		else if(backgroundDropdown.value == 2){
			database.GetComponent<Database> ().backgroundSong = database.GetComponent<Database> ().backgroundSongs [2];
		}
		database.GetComponent<Database> ().menuMusic ();
	}

	public void victorySongChange()
	{
		if (backgroundDropdown.value == 0) {
			database.GetComponent<Database> ().promoteSong = database.GetComponent<Database> ().promoteSongs [0];
		}
		else if(backgroundDropdown.value == 1){
			database.GetComponent<Database> ().promoteSong = database.GetComponent<Database> ().promoteSongs [1];
		}
		else if(backgroundDropdown.value == 2){
			database.GetComponent<Database> ().promoteSong = database.GetComponent<Database> ().promoteSongs [2];
		}
	}

	public void BackBtn()
	{
		Application.LoadLevel ("Config");
	}

	public void Audio2Btn()
	{
		Application.LoadLevel ("Audio2");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
