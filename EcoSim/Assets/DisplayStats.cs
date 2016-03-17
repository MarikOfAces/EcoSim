using UnityEngine;
using System.Collections;

public class DisplayStats : MonoBehaviour {

	private int dispType;
	public GUIText dispText;
	public GameObject clickedObject;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			print ("Click input recieved");
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);// Casts the ray where mouse clicks and get the first game object hit
			RaycastHit hit;
			Physics.Raycast (ray, out hit);
			if (hit.transform.gameObject.tag == "Animal")
			{
				print ("Animal");
				dispType =1;
				clickedObject = hit.transform.gameObject;
			}
			else if (hit.transform.gameObject.tag == "Tree")
			{
				dispType =2;
				clickedObject = hit.transform.gameObject;
			}
		}
		if (dispType == 1) {
			dispText.text =  "Age" + clickedObject.GetComponent<AnimalStats>().age.ToString();
			OnGUI();
			      
		}
		if (dispType == 2) {
			
		}
	}
	void OnGUI() {
		if (clickedObject != null) {
			dispText.text = 
			"Species Number: " + clickedObject.GetComponent<AnimalStats> ().sNumber + "\n" +
				"Name: " + clickedObject.GetComponent<AnimalStats> ().name + "\n" + "\n" +

				"Gender: " + clickedObject.GetComponent<AnimalStats> ().myGender.ToString () + "\n" +
				"Age: " + clickedObject.GetComponent<AnimalStats> ().age.ToString () + "\n" +
				"Health: " + clickedObject.GetComponent<AnimalStats> ().health.ToString () + "\n" +
				"Energy: " + clickedObject.GetComponent<AnimalStats> ().energy.ToString () + "\n" +
				"Thirst: " + clickedObject.GetComponent<AnimalStats> ().thirst.ToString () + "\n" +
				"Hunger: " + clickedObject.GetComponent<AnimalStats> ().hunger.ToString () + "\n" + "\n" +

				"Flee/Fight :" + clickedObject.GetComponent<AnimalStats> ().flee.ToString () + "/" + clickedObject.GetComponent<AnimalStats> ().fight.ToString ();
		}

		
	}
}
