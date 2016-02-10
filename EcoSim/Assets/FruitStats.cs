using UnityEngine;
using System.Collections;

public class FruitStats : MonoBehaviour {

	public float Nutrition=0;
	public float maxNutrition=0;


	// Use this for initialization
	void Start () {
		maxNutrition = Random.Range (10, 30);
	}
	
	// Update is called once per frame
	void Update () {	
		if (maxNutrition > Nutrition) {
			Nutrition += 0.01f;
		} 
		else if (maxNutrition <= Nutrition) {
			maxNutrition = 0;
			Nutrition -= 0.001f;
			transform.position = new Vector3(transform.position.x ,(Terrain.activeTerrain.SampleHeight(transform.position)+(transform.localScale.y)),transform.position.z);
		}
	}
}