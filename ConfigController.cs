using UnityEngine;
using System.Collections;

public class ConfigController : MonoBehaviour {

	public GameObject backgroundQuad;
	public GameObject database;
	// Use this for initialization
	void Start () {
	
		backgroundQuad = GameObject.Find ("Background");
		database = GameObject.Find ("database");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnemiesBtn()
	{
		Application.LoadLevel ("Enemies");
	}

	public void AudioBtn()
	{
		Application.LoadLevel ("Audio");
	}

	public void BackgroundBtn()
	{
		Application.LoadLevel ("Backgroud");
	}

	public void BackBtn()
	{
		Application.LoadLevel ("Start");
	}
}
