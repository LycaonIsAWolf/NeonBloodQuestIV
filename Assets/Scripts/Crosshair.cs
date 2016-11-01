using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public Texture2D normal, active;
	public RawImage image;

	public bool canInteract = false;

	void Update(){
		if(canInteract){
			image.texture = active;
		}
		else{
			image.texture = normal;
		}
	}

}
