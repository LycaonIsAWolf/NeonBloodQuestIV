using UnityEngine;
using System.Collections;

public class ColorLerper : MonoBehaviour {
	public Color currentColor;
	public bool lerp = true;

	public float lerpTime = 5f;

	public Color[] colorPalette;

	private float elapsedTime = 0f;
	private Color startColor;
	private Color endColor;



	public static ColorLerper Create(string name, float lt=1f){
		ColorLerper cl = new GameObject(name).AddComponent<ColorLerper>();
		cl.lerpTime = lt;
		return cl;
	}

	void Start(){
		startColor = colorPalette[Random.Range(0, colorPalette.Length)];
		endColor = colorPalette[Random.Range(0, colorPalette.Length)];
		while(endColor == startColor){
			endColor = colorPalette[Random.Range(0, colorPalette.Length)];
		}
		currentColor = startColor;
	}

	void Update(){
		if(lerp){
			elapsedTime += Time.deltaTime;

			currentColor = Colorx.Slerp(startColor, endColor, elapsedTime/lerpTime);

			if(elapsedTime >= lerpTime){
				startColor = endColor;
				
				endColor = colorPalette[Random.Range(0, colorPalette.Length)];
				while(endColor == startColor){
					endColor = colorPalette[Random.Range(0, colorPalette.Length)];
				}

				elapsedTime = 0f;
			}
		}

	}

}
