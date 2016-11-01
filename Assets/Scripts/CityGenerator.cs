using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityGenerator : MonoBehaviour {

	public float size = 50f;
	public int spacing = 5;
	public float buildingScale = 4f;

	public List<Character> characterPrefabs;

	public List<Building> buildingPrefabs;
	public Transform ground;

	private Vector3[] buildingRotations;
	private Building centerBuilding;
	private List<Building> buildings;

	// Use this for initialization
	void Start () {
		ground.transform.localScale = new Vector3(size + 10, 0.1f, size + 10);
		buildings = new List<Building>();

		buildingRotations = new Vector3[]{
			new Vector3(0, 0, 0),
			new Vector3(0, 90, 0),
			new Vector3(0, 180, 0),
			new Vector3(0, 270, 0)
		};

		int halfSize = (int)(size/2);
		for(int x = -halfSize; x < halfSize; x += spacing){
			for(int y = -halfSize; y < halfSize; y += spacing){
				Building building = Instantiate(buildingPrefabs[Random.Range(0, buildingPrefabs.Count)]) as Building;
				buildings.Add(building);
				building.transform.parent = transform;

				building.transform.position = new Vector3(x, 0, y);
				building.transform.localScale = new Vector3(building.transform.localScale.x * buildingScale, building.transform.localScale.y * buildingScale, building.transform.localScale.z * buildingScale);
				building.transform.rotation = Quaternion.EulerAngles(buildingRotations[Random.Range(0, buildingRotations.Length)]);

				if(characterPrefabs.Count > 0){
					int characterIndex = Random.Range(0, characterPrefabs.Count);
					building.AddInhabitant(Instantiate(characterPrefabs[characterIndex]) as Character);
					characterPrefabs.RemoveAt(characterIndex);
				}
				
				if(x == 0 && y == 0){
					centerBuilding = building;
				}

			}
		}

	}
	
}
