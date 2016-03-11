﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeciesCreator : MonoBehaviour {
    //Function Related//

	public GameObject animalPrefab;
    public int maxSpecies = 0;
    public float startTime = 0;
    public float currentTime = 0;
    float wanderRadius = 20.0f;

    //Species Related//

    public float sNumber;
    public float breedAge;
    public float deathAge;
    public float baseAttack;
    public float baseHealth;
    public float size;

    public Vector3 spawnZone;

	public float dietWeight;
	public bool Herbivore = false;
	public bool Carnivore = false;	//IF BOTH = TRUE, OMNIVORE

    //Animal Related//
    public enum Gender { Male, Female};
    public Gender myGender = new Gender();
    public bool willBreed;
    public float age;
    public float health;
    public float attack;
    public float hunger;
    public float thirst;
    public float speed;
    public float energy;
    public float dDay;

    public bool hasGoal;
    public bool canGiveBirth;

    public Vector3 curPos;
    public Vector3 lastPos;
    public bool isMoving;


    //public GameObject prefab;

	// Use this for initialization
	void Start () {
        maxSpecies = 10;
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
                    baseAttack = (baseHealth / 10);
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
                    //else if (dietRand == 0)
                    //{
                    //    Herbivore = true;
                    //    Carnivore = true;
                    //}
					
				  
                    //spawnZone = new Vector3(transform.position.x,Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
					gSpecies = new GameObject("Species" + SpeciesManage.speciesCount);
					gSpecies.transform.parent = gameObject.transform;
				//SPECIES CREATED
                    
                    for (int i = 0; i < 10; i++)
                    {
					//Temp Animal creation
					GameObject tempAnimal = null;
					tempAnimal = Instantiate(animalPrefab);

					tempAnimal.name = ("Ani " + i);
					tempAnimal.transform.parent = gSpecies.transform;
					tempAnimal.AddComponent<AnimalStats>();
					tempAnimal.AddComponent<NavMeshAgent>();

					Quaternion nullQuart = new Quaternion(0,0,0,0);


					//Species Stats Handling
					AnimalStats speciesStats = new AnimalStats();

					tempAnimal.GetComponent<AnimalStats>().deathAge = deathAge;
					tempAnimal.GetComponent<AnimalStats>().breedAge = breedAge;
					tempAnimal.GetComponent<AnimalStats>().baseHealth = baseHealth;
					tempAnimal.GetComponent<AnimalStats>().baseAttack = baseAttack;
					tempAnimal.GetComponent<AnimalStats>().Herbivore = Herbivore;
					tempAnimal.GetComponent<AnimalStats>().Carnivore = Carnivore;
					tempAnimal.GetComponent<AnimalStats>().sNumber = (SpeciesManage.speciesCount);
                        if (Random.Range(0,2) == 0)
                        {
                            tempAnimal.GetComponent<AnimalStats>().myGender = AnimalStats.Gender.Female;
                        }

                        Vector3 tempVec = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
                        transform.position = (spawnZone += tempVec);
                        Vector3 onTerrain = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
                        transform.position = onTerrain;
                    }
                    //Destroy(gameObject);  //DO NOT DESTROY, Causes instantiated objects scripts to not run.
                }
        }
        
    }

}