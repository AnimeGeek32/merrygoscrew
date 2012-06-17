using UnityEngine;
using System.Collections;

public class StaminaMeterManager : MonoBehaviour {
	private int staminaLevel;
	
	// Use this for initialization
	void Start () {
		staminaLevel = 1;
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
		
		InvokeRepeating("decrementStamina",6.0f,3);
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
		
		if(staminaLevel < 0) {
			//Game over	
			GameObject gameManager  = GameObject.Find("GameManager");
			gameManager.GetComponent<Spinning>().gameOver();
		}
	}
	
	private void decrementStamina() {
		if(staminaLevel >= 0)
			setStaminaLevel(staminaLevel - 1);
	}
}
