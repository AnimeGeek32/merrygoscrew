using UnityEngine;
using System.Collections;

public class AudioStretchComp : MonoBehaviour {
 	public AudioClip GameMusic;
	public StaminaMeterManager staminaMeterManager;
	public Spinning spinning;
	
	void Start () {
	audio.pitch=1;
	}
	
	void Update () 
	{
	 if(staminaMeterManager.getStaminaLevel<2)
			audio.pitch=.73;
		
	if(staminaMeterManager.getStaminaLevel>5)
			audio.pitch=1.33;
		
	
	}
}
