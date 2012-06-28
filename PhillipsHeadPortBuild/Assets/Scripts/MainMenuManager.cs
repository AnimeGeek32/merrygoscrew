using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
	public GameObject IntroMovie;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0))
		{
			Debug.Log("Touched");
			if(guiTexture.HitTest(Input.mousePosition) && guiTexture.name == "PlayButton")
			{
				Debug.Log("PlayButton touched");
				IntroMovie.active=true;
				Invoke("LoadLevel", 19.5f);
			}
		}
		
	}
    void LoadLevel()
	{
		Application.LoadLevel("Main");
	}

}
