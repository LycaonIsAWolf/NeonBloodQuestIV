using UnityEngine;
using System.Collections;

public class BuildingDestroyer : MonoBehaviour {

	public Transform master;

	void OnCollisionStay(Collision collision){
		if(collision.gameObject.CompareTag("Building")){
			Destroy(master.gameObject);
		}
	}

}
