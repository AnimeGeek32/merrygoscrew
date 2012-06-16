using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	public GameObject MerryGoRound;
	public GameObject Character;
	public GameObject Acorn;
	public int CurrentLane;
	public float Boost;
	public GameObject AcornPrefab;
	float Stamina;
	float Speed;
	float minSeconds = 0.5f;
	float maxSeconds = 2.0f;

	void Start () {
		Speed=10;
		Boost=2.5f;	
		
		
		Invoke("AcornSpawn",Random.Range(minSeconds,maxSeconds));
		
	
	}
	

	void Update () 
	{
		iTween.RotateBy(MerryGoRound,iTween.Hash("speed", Speed, "y", 30));
		
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
	        Touch primaryTouch = Input.GetTouch(0);
	        float direction  = primaryTouch.deltaPosition.x ;
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
	}
	
	
	/*void OnTriggerStay(Collider Acorn) //when you hit the acorn
	{
		if(Acorn.attachedRigidbody)
			Mathf(Speed+Boost);
	}
	
	void OnCollisionExit(Collision Acorn) //after you collide with the acorn
	{
		Destroy(gameObject);
	}
	*/
	void OnCollisionEnter(Collision Vine)
	{
		Debug.Log("TEST Collision");	
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
	
	Vector3 getRandomPosition() {
		int track = Random.Range(0,5);
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
			(newPosition.y + MerryGoRound.transform.position.y),80.0F);
	}
	void AcornSpawn() {
		/*var i= Random.value* range;
		var j= Random.value* range;
		var k = Random.value* range;
		var pos = Vector3(i,j,k)+player.position;
		*/ 	
		GameObject obj = (GameObject)Instantiate(AcornPrefab,getRandomPosition(),Quaternion.identity);
		
		obj.transform.parent = MerryGoRound.transform;
		
		Invoke("AcornSpawn",Random.Range(minSeconds,maxSeconds));
	}
}
