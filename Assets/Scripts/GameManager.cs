using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager manager;

	public CityGenerator city;

	public PlayerController playerPrefab;

	public GameObject mainMenu;
	public GameObject endMenu;
	public GameObject menuAudio;

	private PlayerController playerInstance;

	void Start(){
		manager = this;
	}

	// Use this for initialization
	public void StartGame () {
		playerInstance = Instantiate(playerPrefab, new Vector3(5f, 5f, 0f), Quaternion.identity) as PlayerController;
		mainMenu.SetActive(false);
		menuAudio.SetActive(false);
	}

	public void EndGame(){
		print("end game");
		endMenu.SetActive(true);
		playerInstance.gameObject.SetActive(false);
		menuAudio.SetActive(true);
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void OpenDeirdreTwitter(){
		Application.OpenURL("https://twitter.com/cosmicwangst");
	}

	public void OpenEmmaTwitter(){
		Application.OpenURL("https://twitter.com/lycaontalks");
	}

	void Update(){
		if(playerInstance != null){
			if(playerInstance.transform.position.y < -1){
				playerInstance.transform.position = new Vector3(5f, 5f, 0f);
			}

		}
	}

}
