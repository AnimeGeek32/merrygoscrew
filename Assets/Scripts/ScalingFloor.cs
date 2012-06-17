using UnityEngine;
using System.Collections;

public class ScalingFloor : MonoBehaviour {

	public GameObject FloorGrass;
	public GameObject FloorClouds;
	public GameObject FloorTrees;
	public GameObject FloorMountain;
	public GameObject FloorSpace;
	public AudioClip LevelChange;
	
	public Spinning spinning;
	
	void Start()
	{
			
	}
	
	void Update()
	{
		GameObject GameManager = GameObject.Find("GameManager");
		float currentElevation = GameManager.GetComponent<Spinning>().currentElevation;
		FadeIn(currentElevation);
		Debug.Log("Elevation"+currentElevation);
	}
	
	void FadeIn (float currentElevation)
	{
		if(currentElevation>=105 && !FloorTrees.active){
			FloorTrees.active=true;
			iTween.ScaleTo(FloorGrass,iTween.Hash("speed",spinning.Speed,"x", 25, "z", 25));
			audio.PlayOneShot(LevelChange);
		} 
		if(currentElevation<105 && FloorTrees.active){
			
		}
		if(currentElevation>=210 && !FloorMountain.active){
			FloorMountain.active=true;
			iTween.ScaleTo(FloorTrees,iTween.Hash("speed",spinning.Speed,"x", 25, "z", 25));
			audio.PlayOneShot(LevelChange);
		}
		if(currentElevation>=315 && !FloorClouds.active){
			FloorClouds.active=true;
			iTween.ScaleTo(FloorMountain,iTween.Hash("speed",spinning.Speed,"x", 25, "z", 25));
			audio.PlayOneShot(LevelChange);
		}
		if(currentElevation>=420 && !FloorSpace.active){
			FloorSpace.active=true;
			iTween.ScaleTo(FloorClouds,iTween.Hash("speed",spinning.Speed,"x", 25, "z", 25));
			audio.PlayOneShot(LevelChange);
		}
	}
}
