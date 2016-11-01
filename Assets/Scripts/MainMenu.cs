using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public ColorLerper lerper;
	public Text title;

	void Update () {
		title.color = lerper.currentColor;
	}
}
