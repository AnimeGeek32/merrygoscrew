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
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			if(Physics.Raycast(ray, out hit, 100.0f))
			{
				string gameObjectName = hit.collider.gameObject.name;
				
				if(gameObjectName == "PlayButton")
				{
					Application.LoadLevel("Main");
				}
			}
		}
	}
}
