using UnityEngine;
using System.Collections;

public class DJ_Prototype1_ControlManager : MonoBehaviour {

	public Color leftColor = Color.red;
	public Color rightColor = Color.green;
	
	private float initialX;
	private float finalX;
	private float swipeDistance;
	private bool swipeComplete;
	
	// Use this for initialization
	void Start () {
		initialX = 0;
		finalX = 0;
		swipeComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0)
		{
			Touch oneTouch = Input.GetTouch(0);
			
			if(oneTouch.phase == TouchPhase.Began)
			{
				swipeComplete = false;
				initialX = oneTouch.position.x;
			}
			
			if(oneTouch.phase == TouchPhase.Ended)
			{
				finalX = oneTouch.position.x;
				swipeComplete = true;
			}
			
			if(swipeComplete)
			{
				swipeDistance = finalX - initialX;
				
				if(swipeDistance < 0)
				{
					renderer.material.color = leftColor;
				}
				else if(swipeDistance > 0)
				{
					renderer.material.color = rightColor;
				}
				swipeComplete = false;
			}
		}
	}
}
