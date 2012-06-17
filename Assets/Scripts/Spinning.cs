using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	public GameObject MerryGoRound;
	public GameObject Character;
	public GameObject Acorn;
	public int CurrentLane;
	public float Boost;
	public GameObject AcornPrefab;
	Vector3 lastMousePos;
	bool usedMouse;
	float Stamina;
	float Speed;
	float minSeconds = 2.0f;
	float maxSeconds = 6.5f;

	void Start () {
		Speed=10;
		Boost=2.5f;	
		Invoke("AcornSpawn",Random.Range(minSeconds,maxSeconds));
		usedMouse = false;
		//StartCoroutine("AcornSpawn");
	}
	

	void Update () 
	{
		iTween.RotateBy(MerryGoRound,iTween.Hash("speed", Speed, "y", 30));
		
		/*
		// For iPad use only
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
	        Touch primaryTouch = Input.GetTouch(0);
	        float direction = -primaryTouch.deltaPosition.x ;
			float moveDistance = 50;
			if(direction < 0) {
				//Swipe Left
				iTween.MoveBy(Character,iTween.Hash("x", -moveDistance));
				Debug.Log("MoveLeft");
			} else {
				//Swipe Right
				iTween.MoveBy(Character,iTween.Hash("x", moveDistance));
				Debug.Log("MoveRight");
	
			}
		}
		*/
		
		// The mouse control is for testing only
		if (Input.GetMouseButtonDown(0)) {
			//Debug.Log("Left mouse button down");
			//Debug.Log("Setting used mouse to true");
			lastMousePos = Input.mousePosition;
			usedMouse = true;
		}
		
		if (Input.GetMouseButtonUp(0)) {
			//Debug.Log("Left mouse button up");
			usedMouse = false;
		}
		
		if(usedMouse)
		{
			//Debug.Log("Swiping");
			Vector3 currentMousePosition = Input.mousePosition;
	        float direction = lastMousePos.x - currentMousePosition.x;
			float moveDistance = 50;
			if(direction < 0) {
				//Swipe Left
				iTween.MoveBy(Character,iTween.Hash("x", -moveDistance));
				//Debug.Log("MoveLeft");
			} else if(direction > 0) {
				//Swipe Right
				iTween.MoveBy(Character,iTween.Hash("x", moveDistance));
				//Debug.Log("MoveRight");
	
			}
		}
	}
	
	
	
	/*
	void SpeedCalc()
	{
		switch(currentLane)
		{
		case 1:
			Debug.Log("Lane 1");
			Speed = 10;
			break;
		case 2:
			Debug.Log("Lane 2");
			Speed = 15;
			break;
		case 3:
			Debug.Log("Lane 3");
			Speed = 20;
			break;
		case 4:
			Debug.Log("Lane 4");
			Speed = 25;
			break;
		case 5:
			Debug.Log("Lane 5");
			Speed = 30;
			break;
		default:
			Debug.Log("Unknown lane");
			break;
		}
	}*/
	
	Vector3 getRandomPosition(int track) {
		
		float radius = 0.0f;
		switch(track) {
		case 0:
			radius = 65.0f;
			break;
		case 1:
			radius = 125.0f;
			break;
		case 2:
			radius = 170.0f;
			break;
		case 3:
			radius = 218.0f;
			break;
		case 4:
			radius = 272.0f;
			break;
		}
		Vector2 newPosition = Random.insideUnitCircle;
		//Debug.LogError("Track: " + track + " Pos: " + newPosition);
		return new Vector3((newPosition.x + MerryGoRound.transform.position.x) + radius,
			(newPosition.y + MerryGoRound.transform.position.y),80.0f);
	}
	
	void AcornSpawn() {
		StartCoroutine("AcornSpawnCoRoutine");
	}
	
 	IEnumerator AcornSpawnCoRoutine() 
	{
		int track = Random.Range(1,5);
		GameObject obj = (GameObject)Instantiate(AcornPrefab,getRandomPosition(track),Quaternion.identity);
		obj.transform.parent = MerryGoRound.transform;
		
		Invoke("AcornSpawn",Random.Range(minSeconds,maxSeconds));
		Vector3 originalPos =  obj.transform.position;
		float waitTime = 0.0f;
		
		switch(track) {
		case 1:
			waitTime = 6.0f;
			break;
		case 2:
			waitTime = 6.2f;
			break;
		case 3:
			waitTime = 6.4f;
			break;
		case 4:
			waitTime = 6.5f;
			break;
			
		}
		yield return new WaitForSeconds(waitTime);
		
		DestroyObject(obj);
		
		
	}
}

