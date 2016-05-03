using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Audio2Controller : MonoBehaviour {

	public Slider shootSlider;
	public Slider destroySlider;
	public Dropdown shootDropdown;
	public Dropdown destroyDropdown;
	public GameObject database;
	public GameObject backgroundQuad;

	// Use this for initialization
	void Start () {

		database = GameObject.Find ("database");
		shootSlider.value = database.GetComponent<Database> ().shootSoundVolume;
		destroySlider.value = database.GetComponent<Database> ().destroySoundVolume;
		shootSlider.onValueChanged.AddListener (delegate{shootSliderCalled();});
		destroySlider.onValueChanged.AddListener (delegate{destroySliderCalled();});
		shootDropdown.onValueChanged.AddListener (delegate{shootSoundChange();});
		destroyDropdown.onValueChanged.AddListener (delegate{destroySoundChange();});
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	}

	public void shootSliderCalled()
	{
		database.GetComponent<Database> ().shootSoundVolume = shootSlider.value;
	}

	public void destroySliderCalled()
	{
		database.GetComponent<Database> ().destroySoundVolume = destroySlider.value;
	}

	public void shootSoundChange()
	{
		if (shootDropdown.value == 0) {
			database.GetComponent<Database> ().shootSound = database.GetComponent<Database> ().shootSounds [0];
		}
		else if(shootDropdown.value == 1){
			database.GetComponent<Database> ().shootSound = database.GetComponent<Database> ().shootSounds [1];
		}
		else if(shootDropdown.value == 2){
			database.GetComponent<Database> ().shootSound = database.GetComponent<Database> ().shootSounds [2];
		}
	}

	public void destroySoundChange()
	{
		if (destroyDropdown.value == 0) {
			database.GetComponent<Database> ().destroySound = database.GetComponent<Database> ().destroySounds [0];
		}
		else if(destroyDropdown.value == 1){
			database.GetComponent<Database> ().destroySound = database.GetComponent<Database> ().destroySounds [1];
		}
		else if(destroyDropdown.value == 2){
			database.GetComponent<Database> ().destroySound = database.GetComponent<Database> ().destroySounds [2];
		}
	}

	public void BackBtn()
	{
		Application.LoadLevel ("Audio");
	}

	// Update is called once per frame
	void Update () {

	}
}
