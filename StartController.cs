using UnityEngine;
using System.Collections;

public class StartController : MonoBehaviour {

	GameObject backgroundQuad;
	GameObject database;

	// Use this for initialization
	void Start () {
	
		backgroundQuad = GameObject.Find ("Background");
		database = GameObject.Find ("database");
		backgroundQuad.GetComponent<MeshRenderer>().material = database.GetComponent<Database> ().backgroundImage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayBtn()
	{
		Application.LoadLevel ("__Scene_0");
	}

	public void GLBtn() //GameLevelsButton
	{
		Application.LoadLevel ("Settings");
	}

	public void ConfigBtn()
	{
		Application.LoadLevel ("Config");
	}

	public void HistoryBtn()
	{
	}

	public void ExitBtn()
	{
		Application.LoadLevel ("Menu");
	}
}
