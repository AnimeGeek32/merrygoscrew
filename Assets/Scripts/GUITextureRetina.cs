using UnityEngine;
using System.Collections;

public class GUITextureRetina : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Screen.width == 2048)
		{
			int retinaTextureX = (int)((guiTexture.pixelInset.x * 2048) / 1024);
			int retinaTextureY = (int)((guiTexture.pixelInset.y * 1536) / 768);
			int retinaTextureWidth = (int)((guiTexture.pixelInset.width * 2048) / 1024);
			int retinaTextureHeight = (int)((guiTexture.pixelInset.height * 1536) / 768);
			
			guiTexture.pixelInset = new Rect(retinaTextureX, retinaTextureY, retinaTextureWidth, retinaTextureHeight);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
