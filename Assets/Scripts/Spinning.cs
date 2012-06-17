using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	public GameObject MerryGoRound;
	public GameObject Character;
	public GameObject Acorn;
	public int CurrentLane;
	public float Boost;
	public GameObject AcornPrefab;
	public GameObject ThornPrefab;
	public GameObject ThornSpurt;
	public GameObject GameOverText;
	public GameObject Screw;
	public GameObject Vines;
	
	public AudioClip swipeSound;
	
	Vector3 lastMousePos;
	bool usedMouse;
	float Stamina;
	public float Speed;
	float minSeconds = 1.0f;
	float maxSeconds = 1.0f;
	float thornMinSeconds = 6.0f;
	float thornMaxSeconds = 8.0f;
	float currentElevation = 0;
	float originalScrewPosition = 0;
	//float getElevation {
		//Elev = CurrentElev + (CurrentSpeed * (currentTime - lastTime))
		
			
	//}
	void Start () {
		Speed=15;
		Boost=2.5f;	
		Invoke("AcornSpawn",Random.Range(minSeconds,maxSeconds));
		//Invoke("ThornSpawn",Random.Range(thornMinSeconds,thornMaxSeconds));
		usedMouse = false;
		lastMousePos = Input.mousePosition;
		CurrentLane = 2;
		originalScrewPosition = Screw.transform.position.y;
		Invoke("startVineCrawl",3.0f);
		
			
		//StartCoroutine("AcornSpawn");
		//Invoke ("gameOver",2.0f);
	}
	
	void startVineCrawl() {
		
 		iTween.MoveBy(Vines,new Vector3(0.0f,Vines.renderer.bounds.size.y - 100.0f ,0f),6.0f * 60.0f);
	}
	void Update () 
	{
		iTween.RotateBy(MerryGoRound,iTween.Hash("speed", Speed, "y", 30));
		
		
		currentElevation = currentElevation + ((Speed*0.5f) * Time.deltaTime);
		iTween.MoveTo(Screw,iTween.Hash("y",Mathf.Round(currentElevation + originalScrewPosition)));
		
		//Debug.Log(Screw + " ==> Elevation: " + currentElevation);
		/*
		// For iPad use only
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
	        Touch primaryTouch = Input.GetTouch(0);
	        float direction = -primaryTouch.deltaPosition.x ;
			//float moveDistance = 50;
			if(direction < 0) {
				//Swipe Left
				//iTween.MoveBy(Character,iTween.Hash("x", -moveDistance));
				SquirrelSnap(CurrentLane--);
				if(!audio.isPlaying)
				{
					audio.clip = swipeSound;
					audio.Play();
				}
				SpeedCalc();
				Debug.Log("MoveLeft");
			} else {
				//Swipe Right
				//iTween.MoveBy(Character,iTween.Hash("x", moveDistance));
				SquirrelSnap(CurrentLane++);
				if(!audio.isPlaying)
				{
					audio.clip = swipeSound;
					audio.Play();
				}
				SpeedCalc();
				Debug.Log("MoveRight");
	
			}
		}
		*/
		
		// The mouse control is for testing only
		if (Input.GetMouseButtonDown(0) && !usedMouse) {
			//Debug.Log("Left mouse button down");
			//Debug.Log("Setting used mouse to true");
			lastMousePos = Input.mousePosition;
			usedMouse = true;
		}
		
		if (Input.GetMouseButtonUp(0)) {
			//Debug.Log("Left mouse button up");
			Vector3 currentMousePosition = Input.mousePosition;
	        float direction = currentMousePosition.x - lastMousePos.x;
			//float moveDistance = 50;
			if(direction < 0 && CurrentLane > 1) {
				//Swipe Left
				//iTween.MoveBy(Character,iTween.Hash("x", -moveDistance));
				CurrentLane--;
				SquirrelSnap(CurrentLane);
				if(!audio.isPlaying)
				{
					audio.clip = swipeSound;
					audio.Play();
				}
				SpeedCalc();
				//Debug.Log("MoveLeft");
			} else if(direction > 0 && CurrentLane < 5) {
				//Swipe Right
				//iTween.MoveBy(Character,iTween.Hash("x", moveDistance));
				CurrentLane++;
				SquirrelSnap(CurrentLane);
				if(!audio.isPlaying)
				{
					audio.clip = swipeSound;
					audio.Play();
				}
				SpeedCalc();
			}
			usedMouse = false;
		}
	}
	
	
	

	void SpeedCalc()
	{
		switch(CurrentLane)
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
	}
	
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
		return new Vector3((newPosition.x + MerryGoRound.transform.position.x - 100) + radius,
			(newPosition.y + MerryGoRound.transform.position.y- 50),80.0f);
	}
	
	void AcornSpawn() {
		//Debug.Log("SPAWN ACORN");
		StartCoroutine("AcornSpawnCoRoutine");
	}
	
 	IEnumerator AcornSpawnCoRoutine() 
	{
		int track = Random.Range(1,5);
		GameObject obj = (GameObject)Instantiate(AcornPrefab,getRandomPosition(track),Quaternion.identity);
		obj.transform.parent = MerryGoRound.transform;
		
		Invoke("AcornSpawn",Random.Range(minSeconds,maxSeconds));
		
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
		waitTime = 10.0f;
		yield return new WaitForSeconds(waitTime);
		
		DestroyObject(obj);
		
		
	}
	
	void ThornSpawn() {
		StartCoroutine("ThornSpawnCoRoutine");
	}
	Vector3 getRandomThornPosition(int track) {
		
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
			(newPosition.y + MerryGoRound.transform.position.y),60.0f);
	}
	
	IEnumerator ThornSpawnCoRoutine() 
	{
		int track = Random.Range(1,5);
		GameObject obj = (GameObject)Instantiate(ThornPrefab,getRandomThornPosition(track),Quaternion.identity);
		obj.transform.parent = MerryGoRound.transform;
		
		GameObject obj2 = (GameObject)Instantiate(ThornSpurt,obj.transform.position,Quaternion.identity);
		obj2.transform.parent = MerryGoRound.transform;
		
		Invoke("ThornSpawn",Random.Range(thornMinSeconds,thornMaxSeconds));
		
		float waitTime = 0.0f;
		
		switch(track) {
		case 1:
			waitTime = 8.0f;
			break;
		case 2:
			waitTime = 8.2f;
			break;
		case 3:
			waitTime = 8.4f;
			break;
		case 4:
			waitTime = 8.5f;
			break;
			
		}
		yield return new WaitForSeconds(waitTime);
		
		DestroyObject(obj);
		
		
	}
	
	public void gameOver() {
		Debug.LogError(@"GAME OVER" + MerryGoRound);
		Character.animation.Stop();
		Character.transform.parent = MerryGoRound.transform;
		
		CancelInvoke();
		StopAllCoroutines();
		GameOverText.active = true;
		//iTween.RotateUpdate(MerryGoRound,iTween.Hash("speed", 20.0f));
	}

	void SquirrelSnap(int targetLane)
	{
		iTween.MoveTo(Character, iTween.Hash("position", GameObject.Find("LaneWaypoint" + targetLane).transform));
	}



}

