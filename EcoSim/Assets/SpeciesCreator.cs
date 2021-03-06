﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeciesCreator : MonoBehaviour {
    //Function Related//

	public GameObject animalPrefab;
    public const int maxSpecies = 5;
	public const int AnisPerSpecies = 10;
    public float startTime = 0;
    public float currentTime = 0;
    float wanderRadius = 20.0f;

    //Species Related//

    public float sNumber;
    public float breedAge;
    public float deathAge;
    public float baseAttack;
    public float baseHealth;
	public float gestPeriod;
    public float size;

    public Vector3 spawnZone;

	public float dietWeight;
	public bool Herbivore = false;
	public bool Carnivore = false;	//IF BOTH = TRUE, OMNIVORE

    //Animal Related//
	public int genderVal;
    public bool willBreed;
    public float age;
    public float health;
    public float attack;
    public float hunger;
    public float thirst;
    public float speed;
    public float energy;
    public float dDay;
	public float aggression;

    public bool hasGoal;
    public bool canGiveBirth;

    public Vector3 curPos;
    public Vector3 lastPos;
    public bool isMoving;


    //public GameObject prefab;

	// Use this for initialization
	void Start () {
        spawnSpecies();
        canGiveBirth = false;
        willBreed = false;
        hasGoal = false;
        startTime = 0;
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void spawnSpecies()
    {


        if (!SpeciesManage.spawningStarted)
        {
            SpeciesManage.spawningStarted = true;
            //if (!SpeciesManage.spawningFinished)
            //{ 
                while (maxSpecies > SpeciesManage.speciesCount)
                {
                 	SpeciesCreator tempSpecies;
					GameObject gSpecies = null;
                    SpeciesManage.speciesCount++;
                    deathAge = Random.Range(120.0f, 600.0f);
                    breedAge = deathAge / 5;
                    size = Random.Range(0.5f, 2.0f);
                    baseHealth = (Random.Range(50.0f, 200.0f) * size);
					baseAttack = Random.Range ((baseHealth / 20),(baseHealth / 10));
					speed = Random.Range(5.0f,25.0f);
					aggression = Random.Range(1.0f,5.0f);
					gestPeriod = breedAge / Random.Range(1.0f,5.0f);
                    //sNumber = SpeciesManage.speciesCount;
                    spawnZone = new Vector3(Random.Range(-100.0f, 100.0f), 0, Random.Range(-100.0f, 100.0f));
					int dietRand = Random.Range(0,2);
					if (dietRand == 0)
					{
						Herbivore = true;
					Carnivore = false;
					}	
					else if (dietRand == 1)
					{
						Carnivore = true;
					Herbivore = false;
					}
					
				  
                    //spawnZone = new Vector3(transform.position.x,Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
					gSpecies = new GameObject("Species" + SpeciesManage.speciesCount);
					gSpecies.transform.parent = gameObject.transform;
				//SPECIES CREATED
                    
                    for (int i = 0; i < AnisPerSpecies; i++)
                    {
					//Temp Animal creation
					//print ("we got here");
					GameObject tempAnimal = null;
					//tempAnimal = GameObject.CreatePrimitive(PrimitiveType.Cube);
					//tempAnimal = GameObject.CreatePrimitive(PrimitiveType.Cube);//("ThisAnimal" + i);
					tempAnimal = Instantiate(animalPrefab);

					tempAnimal.name = ("Ani " + i);	
					tempAnimal.transform.parent = gSpecies.transform;
					tempAnimal.AddComponent<AnimalStats>();
					tempAnimal.AddComponent<NavMeshAgent>();
					//print ("we got here 2");
					//tempAnimal.AddComponent<animalPrefab>();
					Quaternion nullQuart = new Quaternion(0,0,0,0);


					//Species Stats Handling

					tempAnimal.GetComponent<AnimalStats>().deathAge = deathAge;
					tempAnimal.GetComponent<AnimalStats>().breedAge = breedAge;
					tempAnimal.GetComponent<AnimalStats>().baseHealth = baseHealth;
					tempAnimal.GetComponent<AnimalStats>().baseAttack = baseAttack;
					tempAnimal.GetComponent<AnimalStats>().Herbivore = Herbivore;
					tempAnimal.GetComponent<AnimalStats>().Carnivore = Carnivore;
					tempAnimal.GetComponent<AnimalStats>().GestPeriod = gestPeriod;
					tempAnimal.GetComponent<AnimalStats>().sNumber = (SpeciesManage.speciesCount);
					tempAnimal.GetComponent<AnimalStats>().genderVal = Random.Range (0,2);
					tempAnimal.GetComponent<AnimalStats>().speed = speed;
					tempAnimal.GetComponent<AnimalStats>().motherObj = gameObject;
					tempAnimal.GetComponent<AnimalStats>().fatherObj = gameObject;
					tempAnimal.GetComponent<AnimalStats>().aggression = aggression;

					//Instantiate(tempAnimal,spawnZone, nullQuart);
                       	
	
                        //tempSpecies = Instantiate<SpeciesCreator>(this);
                        //tempSpecies.name = ("Species" + SpeciesManage.speciesCount);
                        //tempSpecies.tag = ("Species:" + SpeciesManage.speciesCount);
                        //Debug.Log("Death Age (createSpecies)");
                        // Instantiate(tempAnimal,spawnZone, nullQuart);Debug.Log(myAnimal.deathAge);

                        Vector3 tempVec = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
                        transform.position = (spawnZone += tempVec);
                        Vector3 onTerrain = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
                        transform.position = onTerrain;

                    }



                    //Destroy(gameObject);  //DO NOT DESTROY, Causes instantiated objects scripts to not run.
                }

            //}
                //Destroy(gameObject);
        }
        
    }

}