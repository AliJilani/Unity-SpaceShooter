using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GoldSettings : MonoBehaviour {

	public GameObject database;
	public Slider e0slider;
	public Slider e1slider;
	public Slider e2slider;
	public Slider e3slider;
	public Slider e4slider;
	public GameObject background;
	public InputField inputText;
	public int slidersActive=5;
	public Text errorText;
	public bool first = true;
	public Text sliderValText;
	public GameObject backgroundQuad;

	// Use this for initialization
	void Start () {
		database = GameObject.Find ("database");

		e0slider.minValue = (float)(database.GetComponent<Database> ().silverMaxEnemies [0])/5f;
		e1slider.minValue = (float)(database.GetComponent<Database> ().silverMaxEnemies [1])/5f;
		e2slider.minValue = (float)(database.GetComponent<Database> ().silverMaxEnemies [2])/5f;
		e3slider.minValue = (float)(database.GetComponent<Database> ().silverMaxEnemies [3])/5f;
		e4slider.minValue = (float)(database.GetComponent<Database> ().silverMaxEnemies [4])/5f;
		e0slider.value = (float)(database.GetComponent<Database> ().goldMaxEnemies [0])/5f;
		e1slider.value = (float)(database.GetComponent<Database> ().goldMaxEnemies [1])/5f;
		e2slider.value = (float)(database.GetComponent<Database> ().goldMaxEnemies [2])/5f;
		e3slider.value = (float)(database.GetComponent<Database> ().goldMaxEnemies [3])/5f;
		e4slider.value = (float)(database.GetComponent<Database> ().goldMaxEnemies [4])/5f;

		first = false;

		e0slider.onValueChanged.AddListener (delegate{sliderCalled();});
		e1slider.onValueChanged.AddListener (delegate{sliderCalled();});
		e2slider.onValueChanged.AddListener (delegate{sliderCalled();});
		e3slider.onValueChanged.AddListener (delegate{sliderCalled();});
		e4slider.onValueChanged.AddListener (delegate{sliderCalled();});

		inputText.characterValidation = InputField.CharacterValidation.Integer;
		inputText.characterLimit = 5;

		int[] vals = new int[5];
		for (int i = 0; i < 5; i++) {
			Debug.Log ("TEXT");
			vals [i] = database.GetComponent<Database> ().goldMaxEnemies [i];
		}
		sliderValText.GetComponent<Text> ().text = vals [0] + "\n\n\n" + vals [1] + "\n\n\n" +vals[2] + "\n\n\n" + vals [3] + "\n\n\n" + vals [4] + "";

		backgroundQuad = GameObject.Find ("Background");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sliderCalled()
	{
		float sum = e0slider.value + e1slider.value + e2slider.value + e3slider.value + e4slider.value;
		if (sum == 0) {
			return;
		}
		database.GetComponent<Database> ().goldMaxEnemies [0] = (int)(e0slider.value*5);
		database.GetComponent<Database> ().goldMaxEnemies [1] = (int)(e1slider.value*5);
		database.GetComponent<Database> ().goldMaxEnemies [2] = (int)(e2slider.value*5);
		database.GetComponent<Database> ().goldMaxEnemies [3] = (int)(e3slider.value*5);
		database.GetComponent<Database> ().goldMaxEnemies [4] = (int)(e4slider.value*5);
		updateValues ();
	}

	public void updateValues()
	{
		int[] vals = new int[5];
		for (int i = 0; i < 5; i++) {
			vals [i] = database.GetComponent<Database> ().goldMaxEnemies [i];
		}
		sliderValText.GetComponent<Text> ().text = vals [0] + "\n\n\n" + vals [1] + "\n\n\n" +vals[2] + "\n\n\n" + vals [3] + "\n\n\n" + vals [4] + "";
	}

	public void onEnteredText()
	{
		if (Convert.ToInt32 (inputText.GetComponent<InputField> ().text) < 500) {
			//errorText.enabled = true;
		} else {
			//errorText.enabled = false;
			database.GetComponent<Database> ().goldMaxScore = Convert.ToInt32 (inputText.GetComponent<InputField> ().text);
		}
	}

	public void BackBtn()
	{
		Application.LoadLevel ("Settings");
	}
}
