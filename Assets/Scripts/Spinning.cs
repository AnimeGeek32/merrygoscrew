using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	public GameObject MerryGoRound;
	public float Speed;
	public GameObject Character;
	float Stamina;
	public GameObject Acorn1;
	public GameObject Acorn2;
	public GameObject Acorn3;
	public GameObject Acorn4;
	public GameObject Acorn5;
	public GameObject Obst1;
	public GameObject Obst2;
	public GameObject Obst3;
	public GameObject Obst4;
	public GameObject Obst5;

	void Start () {
	
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
	
	
	void StaminaRegen()
	{
		
	}
	
	void SpeedCalc()
	{
	if (	
	}
}
