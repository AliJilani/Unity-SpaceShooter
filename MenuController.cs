using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	GameObject backgroundQuad;
	GameObject database;
	// Use this for initialization
	void Start () {
		Screen.SetResolution (675,900,false);
		backgroundQuad = GameObject.Find ("Background");
		database = GameObject.Find ("database");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
		database.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartBtn()
	{
		Application.LoadLevel ("Start");
	}

	public void ExitBtn()
	{
		if (Manager.instance.userLoggedIn == "admin") {
			Application.LoadLevel ("MainMenu");
		} else {
			Application.LoadLevel ("MainMenuNonAdmin");
		}
		database.GetComponent<AudioSource> ().Pause ();
	}
}
