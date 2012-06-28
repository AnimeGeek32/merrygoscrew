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
			
		}
		if(currentElevation>=210 && !FloorMountain.active){
			FloorMountain.active=true;
			
		}
		if(currentElevation>=315 && !FloorClouds.active){
			FloorClouds.active=true;
			
		}
		if(currentElevation>=420 && !FloorSpace.active){
			FloorSpace.active=true;
	
		}
	}
	
	void ScalingFloors ()
	{
		iTween.ScaleTo(FloorGrass,iTween.Hash("time",150,"x", 25, "z", 25));
		iTween.ScaleTo(FloorTrees,iTween.Hash("time",150,"x", 25, "z", 25, "delay", 14));
		iTween.ScaleTo(FloorMountain,iTween.Hash("time",150,"x", 25, "z", 25,"delay", 28));
		iTween.ScaleTo(FloorClouds,iTween.Hash("time",150,"x", 25, "z", 25, "delay", 42));
		
		
	}

}
