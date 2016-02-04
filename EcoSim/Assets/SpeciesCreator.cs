using UnityEngine;
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

    public string sName;
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
					int dietRand = Random.Range(0,3);
					if (dietRand == 1)
					{
						Herbivore = true;
					Carnivore = false;
					}	
					else if (dietRand == 2)
					{
						Carnivore = true;
					Herbivore = false;
					}
					else if (dietRand == 0)
					{
						Herbivore = true;
						Carnivore = true;
					}
					
				  
                    //spawnZone = new Vector3(transform.position.x,Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
					gSpecies = new GameObject("Species" + SpeciesManage.speciesCount);
					gSpecies.transform.parent = gameObject.transform;
				//SPECIES CREATED
                    
                    for (int i = 0; i < 5; i++)
                    {
					//Temp Animal creation
					GameObject tempAnimal = null;
					//tempAnimal = GameObject.CreatePrimitive(PrimitiveType.Cube);
					//tempAnimal = GameObject.CreatePrimitive(PrimitiveType.Cube);//("ThisAnimal" + i);
					tempAnimal = Instantiate(animalPrefab);

					tempAnimal.name = ("ThisAnimal" + i);
					tempAnimal.transform.parent = gSpecies.transform;
					tempAnimal.AddComponent<AnimalStats>();
					tempAnimal.AddComponent<NavMeshAgent>();
					//tempAnimal.AddComponent<animalPrefab>();
					Quaternion nullQuart = new Quaternion(0,0,0,0);

					//Species Stats Handling
					AnimalStats speciesStats = new AnimalStats();

					tempAnimal.GetComponent<AnimalStats>().deathAge = deathAge;
					tempAnimal.GetComponent<AnimalStats>().breedAge = breedAge;
					tempAnimal.GetComponent<AnimalStats>().baseHealth = baseHealth;
					tempAnimal.GetComponent<AnimalStats>().baseAttack = baseAttack;
					tempAnimal.GetComponent<AnimalStats>().Herbivore = Herbivore;
					tempAnimal.GetComponent<AnimalStats>().Carnivore = Carnivore;



					//Instantiate(tempAnimal,spawnZone, nullQuart);



                       	sName = ("animal " + i);
						
						
                        //tempSpecies = Instantiate<SpeciesCreator>(this);
                        //tempSpecies.name = ("Species" + SpeciesManage.speciesCount);
                        //tempSpecies.tag = ("Species:" + SpeciesManage.speciesCount);
                        //Debug.Log("Death Age (createSpecies)");
                        // Instantiate(tempAnimal,spawnZone, nullQuart);Debug.Log(myAnimal.deathAge);

                        Vector3 tempVec = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
                        transform.position = (spawnZone += tempVec);
                        Vector3 onTerrain = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
                        transform.position = onTerrain;


//                        hunger = 100.0f;
//                        thirst = 100.0f;
//                        energy = 100.0f;
//                        speed = 1.0f;
                        //dDay = (deathAge + (Random.Range(-deathAge / 5, deathAge / 5)));
                        if (Random.Range(0, 2) == 0)
                        {
                            myGender = Gender.Female;
                        }
                        else
                        {
                            myGender = Gender.Male;
                        }

                    }



                    //Destroy(gameObject);  //DO NOT DESTROY, Causes instantiated objects scripts to not run.
                }

            //}
                //Destroy(gameObject);
        }
        
    }

}