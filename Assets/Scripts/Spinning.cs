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


	void Start () {
		Speed=10;
		Boost=2.5f;
		
		//GameObject obj = (GameObject)Instantiate(AcornPrefab,new Vector3(2.5F,0.6F,80.0F),Quaternion.identity);
		//obj.layer = MerryGoRound.layer;
		//obj.transform.parent = MerryGoRound.transform;	
		
		//Debug.LogError(obj.transform.position);
	
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
				audio.Play();
				Debug.Log("MoveLeft");
			} else {
				//Swipe Right
				iTween.MoveBy(Character,iTween.Hash("x", moveDistance));
				audio.Play();
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
}
