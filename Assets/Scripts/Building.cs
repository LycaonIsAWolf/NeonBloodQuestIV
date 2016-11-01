using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Building : MonoBehaviour {

	public void AddInhabitant(Character c){
		Vector2 pos = (Random.insideUnitCircle.normalized);

		c.transform.position = transform.position + new Vector3(pos.x * 5, 0, pos.y * 5);
		c.transform.parent = transform;

	}

	// Use this for initialization
	void Start () {
		foreach(MeshCollider collider in GetComponentsInChildren<MeshCollider>()){
			collider.transform.gameObject.AddComponent<BuildingDestroyer>().master = transform;
		}
	}
	
}
