using UnityEngine;
using System.Collections;

public class CollisionLogic : MonoBehaviour {
	public GameObject MerryGoRound;
	
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider collision) //when you hit the acorn
	{
		if(collision.gameObject.name == "Acorn") {
			Debug.LogError("GOT IT");
		}
	}
	
	
}
