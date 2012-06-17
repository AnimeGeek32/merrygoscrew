using UnityEngine;
using System.Collections;

public class ScalingFloor : MonoBehaviour {

	public GameObject FloorGrass;
	public GameObject FloorClouds;
	public GameObject FloorTrees;
	public GameObject FloorMountain;
	public GameObject FloorSpace;

	void Start()
	{
		iTween.ScaleTo(FloorGrass,iTween.Hash("time", 5, "x", 25, "z", 25));
		iTween.ScaleTo(FloorTrees,iTween.Hash("time", 5, "x", 25, "z", 25, "delay", 5));
		iTween.ScaleTo(FloorMountain,iTween.Hash("time", 5, "x", 25, "z", 25, "delay", 10));
		iTween.ScaleTo(FloorClouds,iTween.Hash("time", 5, "x", 25, "z", 25, "delay", 15));
		
		//iTween.ColorTo(FloorTrees, iTween.Hash ("time", 5, "a", 1, "delay", 2.5));
		//iTween.ColorTo(FloorMountain, iTween.Hash ("time", 5, "a", 1, "delay", 7.5));
		//iTween.ColorTo(FloorClouds, iTween.Hash ("time", 5, "a", 1, "delay", 11.5));
		//iTween.ColorTo(FloorSpace, iTween.Hash ("time", 5, "a", 1, "delay", 16.5));
	}
	
	void Update () {
	
	}
}
