using UnityEngine;
using System.Collections;


	
public class CollisionLogic : MonoBehaviour {
	bool isGathered=false;
	public AudioClip catchAudio;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		 
	}
	void OnTriggerEnter(Collider collision) //when you hit the acorn
	{
		//Debug.Log(collision.gameObject.tag + " ==> " + collision.gameObject.name);
		if((collision.gameObject.tag == "Player") && (!isGathered)) {
			isGathered=true;
			collision.gameObject.audio.PlayOneShot(catchAudio);
			GameObject staminaMeterManager = GameObject.Find("StaminaMeter");
			int currentStaminaLevel = staminaMeterManager.GetComponent<StaminaMeterManager>().getStaminaLevel();
			if(currentStaminaLevel < 9)
			{
				staminaMeterManager.GetComponent<StaminaMeterManager>().setStaminaLevel(currentStaminaLevel + 2);
			}
			Destroy(this.gameObject);
		}
	}
	
	
	
}
