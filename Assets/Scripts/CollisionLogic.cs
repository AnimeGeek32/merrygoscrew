using UnityEngine;
using System.Collections;

public class CollisionLogic : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider collision) //when you hit the acorn
	{
		Debug.LogError("COLL: " + collision.gameObject.name);
		if(collision.gameObject.name == "AcornPrefab") {
			Debug.LogError("GOT IT");
		}
	}
	
	
}
