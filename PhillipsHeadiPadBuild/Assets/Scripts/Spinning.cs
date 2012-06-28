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
	//public GameObject Camera;
	
	public AudioClip swipeSound;
	public AudioClip SpinPitch;
	
	Vector3 lastMousePos;
	bool usedMouse;
	float Stamina;
	public float Speed;
	public float vineCrawlDelay;
	public float ScrewSpeed;
	public float SecondsForVinesToGrow;
	
	float minSeconds = 3.0f;
	float maxSeconds = 5.5f;
	float thornMinSeconds = 1.5f;
	float thornMaxSeconds = 2.0f;
	public float currentElevation = 0;
	float originalScrewPosition = 0;
	bool didStart = false;
	void Start () {
		Invoke("beginGame",3.0f);
	}
	void beginGame(){
		didStart = true;
		Speed=15;
		Boost=2.5f;	
		Invoke("AcornSpawn",Random.Range(minSeconds,maxSeconds));
		Invoke("ThornSpawn",Random.Range(thornMinSeconds,thornMaxSeconds));
		usedMouse = false;
		lastMousePos = Input.mousePosition;
		CurrentLane = 2;
		originalScrewPosition = Screw.transform.position.y;
		Invoke("startVineCrawl",vineCrawlDelay);	
	}
	void startVineCrawl() {
		
 		iTween.MoveBy(Vines,new Vector3(0.0f,Vines.renderer.bounds.size.y - 100.0f ,0f),SecondsForVinesToGrow);
	}
	public void Update () 
	{
		if(didStart) {
			iTween.RotateBy(MerryGoRound,iTween.Hash("speed", Speed, "y", 30));
			
			
			currentElevation = currentElevation + ((Speed*ScrewSpeed) * Time.deltaTime);
			if(currentElevation < 630) { //Check if elevation is at the top of screen then end game
				iTween.MoveTo(Screw,iTween.Hash("y",Mathf.Round(currentElevation + originalScrewPosition)));
			} else {
				gameOver(true);	
			}
		
		
		
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
}
	
	
	

	void SpeedCalc()
	{
		switch(CurrentLane)
		{
		case 1:
			Debug.Log("Lane 1");
			Speed = 10;
			audio.pitch=.75f;
			break;
		case 2:
			Debug.Log("Lane 2");
			Speed = 15;
			audio.pitch=.85f;
			break;
		case 3:
			Debug.Log("Lane 3");
			Speed = 20;
			audio.pitch=.95f;
			break;
		case 4:
			Debug.Log("Lane 4");
			Speed = 25;
			audio.pitch=1.05f;
			break;
		case 5:
			Debug.Log("Lane 5");
			Speed = 30;
			audio.pitch=1.15f;
			break;
		default:
			Debug.Log("Unknown lane");
			break;
		}
	}
	
	Vector3 getRandomPosition(int track) {
		
		float radius = 0.0f;
		switch(track) {
		
		case 1:
			radius = 125.0f;
			break;
		case 2:
			radius = 218.0f;
			break;
		case 3:
			radius = 272.0f;
			break;
		case 4:
			radius = 326.0f;
			break;
		case 5:
			radius = 380.0f;
			break;
		}
		Vector2 newPosition = Random.insideUnitCircle;
		Debug.LogError("Track: " + track + " Pos: " + radius );
		return new Vector3((newPosition.x + MerryGoRound.transform.position.x - 200) + radius,
			(newPosition.y + MerryGoRound.transform.position.y- 150),80.0f);
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
		
		//iTween.ScaleTo(obj,iTween.Hash("scale",0.75f));
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
		case 5:
			waitTime = 6.8f;
			break;
		}
		//waitTime = 10.0f;
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
		return new Vector3((newPosition.x + MerryGoRound.transform.position.x - 30) + radius,
			(newPosition.y + MerryGoRound.transform.position.y - 30),60.0f);
	}
	
	IEnumerator ThornSpawnCoRoutine() 
	{
		int track =1;
		if(CurrentLane == 1)
			track = Random.Range(1, 3);
		else if(CurrentLane == 5)
			track = Random.Range(3,5);
		else
			track = Random.Range(CurrentLane-1, CurrentLane+1);
		
		
		GameObject obj = (GameObject)Instantiate(ThornPrefab,getRandomThornPosition(track),Quaternion.identity);
		obj.transform.parent = MerryGoRound.transform;
		
		
		
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
	
	public void gameOver(bool isSuccessful) {
		//Debug.LogError(@"GAME OVER" + MerryGoRound);
		
		
		
		CancelInvoke();
		StopAllCoroutines();
		if(!isSuccessful){
			Character.animation.Stop();
			Character.transform.parent = MerryGoRound.transform;
			//GameOverText.active = true;
			iTween.RotateBy(MerryGoRound,iTween.Hash("speed", 10.0f, "y", 30));
			Handheld.PlayFullScreenMovie("DEATH.mov",Color.black,FullScreenMovieControlMode.Full,FullScreenMovieScalingMode.AspectFit);
		} else {
			
			Handheld.PlayFullScreenMovie("END.mp4",Color.black,FullScreenMovieControlMode.Full,FullScreenMovieScalingMode.AspectFit);
		}
		Application.LoadLevel("TitleScreen");
	}

	void SquirrelSnap(int targetLane)
	{
		iTween.MoveTo(Character, iTween.Hash("position", GameObject.Find("LaneWaypoint" + targetLane).transform));
	}



}

