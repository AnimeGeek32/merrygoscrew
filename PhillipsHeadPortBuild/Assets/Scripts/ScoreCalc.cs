using UnityEngine;
using System.Collections;

public class ScoreCalc : MonoBehaviour {
	public StaminaMeterManager staminaMeterManager;
	public Spinning spinning;
	public int Elevation;
	
	void Start () {
		Elevation = 0;
	}
	
	void Update () {
		Elevation += (int)((spinning.Speed + staminaMeterManager.getStaminaLevel()) / Time.deltaTime);
	}
}
