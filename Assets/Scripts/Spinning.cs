using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {
	public GameObject MerryGoRound;
	public float Speed;
	public GameObject Character;
	float Stamina;

	void Start () {
	
	}
	

	void Update () 
	{
		iTween.RotateBy(MerryGoRound,iTween.Hash("speed", Speed, "y", 90));
	
	}

	void CharacterMoveRight()
	{
		iTween.MoveTo(Character,iTween.Hash("x", +2.5));	
	}

	void CharacterMoveLeft()
	{
		iTween.MoveTo(Character,iTween.Hash("x", -2.5));
	}
	
}
