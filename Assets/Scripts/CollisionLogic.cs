using UnityEngine;
using System.Collections;

public class CollisionLogic : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collision) //when you hit the acorn
	{
		if(collision.gameObject.tag == "Acorn") {
			Debug.Log("GOT IT");
			GameObject staminaMeterManager = GameObject.Find("StaminaMeter");
			int currentStaminaLevel = staminaMeterManager.GetComponent<StaminaMeterManager>().getStaminaLevel();
			if(currentStaminaLevel < 9)
			{
				staminaMeterManager.GetComponent<StaminaMeterManager>().setStaminaLevel(currentStaminaLevel + 1);
			}
		}
	}
	
	
}
