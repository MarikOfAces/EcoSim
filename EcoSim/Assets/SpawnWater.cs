using UnityEngine;
using System.Collections;

public class SpawnWater : MonoBehaviour {
	public GameObject waterPrefab;
	public Terrain terrain;
	private int terrainWidth; // terrain size (x)
	private int terrainLength; // terrain size (z)
	private int terrainPosX; // terrain position x
	private int terrainPosZ; // terrain position z
	private int waterCount;
	// Use this for initialization
	void Start () {
		waterCount = Random.Range (5, 15);
		// terrain size x
		terrainWidth = (int)terrain.terrainData.size.x;
		// terrain size z
		terrainLength = (int)terrain.terrainData.size.z;
		// terrain x position
		terrainPosX = (int)terrain.transform.position.x;
		// terrain z position
		terrainPosZ = (int)terrain.transform.position.z;

	}	
	// Update is called once per frame
	void Update () {
		while (waterCount>0) {
			GameObject tempWater = waterPrefab;
			tempWater.transform.localScale = new Vector3(Random.Range (20,40),0.2f,Random.Range (20,40));

			Instantiate(tempWater);
			//tempWater.transform.parent = transform.parent;
			int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
			int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
			float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
			tempWater.transform.position = new Vector3(posx,posy,posz);
			waterCount--;
		}

	}
}
