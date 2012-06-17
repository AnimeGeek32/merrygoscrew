using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			Debug.Log("Touched");
			if(guiTexture.HitTest(Input.GetTouch(0).position))
			{
				Debug.Log("PlayButton touched");
				iPhoneUtils.PlayMovie("intro.mov", Color.black, iPhoneMovieControlMode.CancelOnTouch);
				Application.LoadLevel("Main");
			}
		}
		
		/*
		if(Input.GetMouseButton(0))
		{
			Debug.Log("Touched");
			if(guiTexture.HitTest(Input.mousePosition) && guiTexture.name == "PlayButton")
			{
				Debug.Log("PlayButton touched");
				Application.LoadLevel("Main");
			}
		}
		*/
	}
}
