using UnityEngine;
using System.Collections;

public class StaminaMeterManager : MonoBehaviour {
	private int staminaLevel;
	
	// Use this for initialization
	void Start () {
		staminaLevel = 3;
		for(int i = 0; i < 10; i++)
		{
			if( i <= staminaLevel )
			{
				transform.Find("StaminaMeterTick" + i).gameObject.active = true;
			}
			else
			{
				transform.Find("StaminaMeterTick" + i).gameObject.active = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public int getStaminaLevel()
	{
		return staminaLevel;
	}
	
	public void setStaminaLevel(int targetValue)
	{
		staminaLevel = targetValue;
		for(int i = 0; i < 10; i++)
		{
			if( i <= staminaLevel )
			{
				transform.Find("StaminaMeterTick" + i).gameObject.active = true;
			}
			else
			{
				transform.Find("StaminaMeterTick" + i).gameObject.active = false;
			}
		}
	}
}
