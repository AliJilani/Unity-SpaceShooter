using UnityEngine;
using System.Collections;

public class SettingsController : MonoBehaviour {

	public GameObject database;
	public GameObject backgroundQuad;

	// Use this for initialization
	void Start () {
	
		backgroundQuad = GameObject.Find ("Background");
		database = GameObject.Find ("database");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BackBtn()
	{
		Application.LoadLevel ("Start");
	}

	public void BronzeSettingsBtn()
	{
		Application.LoadLevel ("BrnzSettings");
	}

	public void SilverSettingsBtn()
	{
		Application.LoadLevel ("SilvSettings");
	}

	public void GoldSettingsBtn()
	{
		Application.LoadLevel ("GoldSettings");
	}
}
