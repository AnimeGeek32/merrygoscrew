using UnityEngine;
using System.Collections;

public class VineCollosion : MonoBehaviour {
	public AudioClip hitAudio;
	bool didHit=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collision) //when you hit the acorn
	{
		Debug.Log(collision.gameObject.tag + " ==> " + collision.gameObject.name);
		if((collision.gameObject.tag == "Player") && (!didHit)) {
			didHit=true;
			
			collision.gameObject.audio.PlayOneShot(hitAudio);
			GameObject staminaMeterManager = GameObject.Find("StaminaMeter");
			int currentStaminaLevel = staminaMeterManager.GetComponent<StaminaMeterManager>().getStaminaLevel();
			if(currentStaminaLevel > 0 )
			{
				staminaMeterManager.GetComponent<StaminaMeterManager>().setStaminaLevel(currentStaminaLevel - 1);
				
			}
			Destroy(this.gameObject);
		}
	}
}
