using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeciesCreator : MonoBehaviour {
    //Function Related//
    public int maxSpecies = 0;
    public float startTime = 0;
    public float currentTime = 0;
    float wanderRadius = 20.0f;

    //Species Related//

    public string sName;
    public int sNumber;
    public float breedAge;
    public float deathAge;
    public float baseAttack;
    public float baseHealth;
    public float size;
    public enum Diet { Herb, Omni, Carn }
    public Vector3 spawnZone;

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
        Wander();
        LifeCycle();
        updateStats();
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
                    SpeciesManage.speciesCount++;
                    deathAge = Random.Range(120.0f, 600.0f);
                    breedAge = deathAge / 5;
                    size = Random.Range(0.5f, 2.0f);
                    baseHealth = (Random.Range(50.0f, 200.0f) * size);
                    baseAttack = (baseHealth / 10);
                    sNumber = SpeciesManage.speciesCount;
                    spawnZone = new Vector3(Random.Range(-100.0f, 100.0f), 0, Random.Range(-100.0f, 100.0f));
                    //spawnZone = new Vector3(transform.position.x,Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
                    
                    
                    //tempSpecies.add
                    
                    for (int i = 0; i < 5; i++)
                    {
                        sName = ("animal " + i);
                        tempSpecies = Instantiate<SpeciesCreator>(this);
                        tempSpecies.name = ("Species" + SpeciesManage.speciesCount);
                        //tempSpecies.tag = ("Species:" + SpeciesManage.speciesCount);
                        //Debug.Log("Death Age (createSpecies)");
                        // Debug.Log(myAnimal.deathAge);

                        Vector3 tempVec = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
                        transform.position = (spawnZone += tempVec);
                        Vector3 onTerrain = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);
                        transform.position = onTerrain;
                        health = (baseHealth + Random.Range(-baseHealth / 10, baseHealth / 10));
                        attack = (baseAttack + Random.Range(-baseAttack / 10, baseAttack / 10));
                        hunger = 100.0f;
                        thirst = 100.0f;
                        energy = 100.0f;
                        speed = 1.0f;
                        dDay = (deathAge + (Random.Range(-deathAge / 5, deathAge / 5)));
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
                Destroy(gameObject);
        }
        
    }

    void LifeCycle()
    {
        age += 0.1f;
        float thirdAge;
        thirdAge = deathAge/3;
        float twothirdAge;
        twothirdAge = thirdAge*2;
        if (age < thirdAge)   //1st third of life = child
        {

        }
        if ((age > thirdAge)&&(age < twothirdAge))//middle portion of life, able to breed.
        {

        }

        if (age < twothirdAge)//final portion of life. Lose ability to procreate?
        {
            Breed();

        }
        if (age > deathAge)
        {
            Destroy(gameObject);
        }
        
    }

    void Navigate()
    {

    }

    void Breed()
    {
        if (myGender == Gender.Male)
        {
            
        }
        if (myGender == Gender.Female)
        {
            while (willBreed == true)
            {
                GameObject[] objects;
                objects = GameObject.FindGameObjectsWithTag(gameObject.tag);        //Scan through species members nearby, look for a mate
                for (int i = 0; i < objects.Length; i++)
                {
                    
                    //Debug.Log(objects[i].transform.position);
                    
                    if (objects[i].name == name)
                    {
                        Debug.Log(objects[i].name + name);
                        Debug.Log("Distance: " + Vector3.Distance(gameObject.transform.position, objects[i].transform.position));
                        Vector3 target = objects[i].transform.position;
                        NavMeshAgent agent = GetComponent<NavMeshAgent>();          //Lookat & move to target mate
                        agent.destination = target;
                        //agent.destination = objects[i].transform.position;
                        transform.LookAt(objects[i].transform.position);            
                        if (Vector3.Distance(transform.position,objects[i].transform.position) < 1.0f)  //If next to mate... then mate.
                        {
                            
                            float ageTemp = age;
                            float hpTemp = health;
                            float attTemp = attack;
                            float dDayTemp = dDay;
                            //bool hasGoalTemp = false;
                            Vector3 tempVec = transform.position;
                            Gender tempGend = myGender;
                            willBreed = false;
                            Birth();
                            Debug.Log("Baby Made!");
                            //hasGoal = hasGoalTemp
                            age = ageTemp;
                            health = hpTemp;
                            attack = attTemp;
                            dDay = dDayTemp;
                            transform.position = tempVec;
                            myGender = tempGend;

                        }
                    }
                }
            }

        }
    }
    void Birth(/*int fHp, int fAtt, int fDDay*/)
    {
        


        Vector3 tempVec = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));             //Place our baby near the mother.
        transform.position = (spawnZone += tempVec);


        health = (baseHealth + Random.Range(-baseHealth / 10, baseHealth / 10));
        attack = (baseAttack + Random.Range(-baseAttack / 10, baseAttack / 10));
        hunger = 100.0f;
        thirst = 100.0f;
        energy = 100.0f;
        speed = 1.0f;
        dDay = (deathAge + (Random.Range(-deathAge / 5, deathAge / 5)));
        age = 0;
        if (Random.Range(0, 2) == 0)
        {
            myGender = Gender.Female;
        }
        else
        {
            myGender = Gender.Male;
        }
        SpeciesCreator tempChild;                                         //Create a new temporary 'Baby animal'
        tempChild = Instantiate<SpeciesCreator>(this);
        tempChild.name = (name);    //Set childs nameto parents name (Name is simply used as a species reference)
    }

    void Wander()
    {
        //currentTime = Time.time;
        if (hasGoal == false)      
        {

            Vector3 NewTarget = Random.insideUnitSphere * wanderRadius;     //Generate a circle around the snake of radius 'WanderRadius' and choose a random new point in that circle
            NewTarget += transform.position;                        //Add new target to snakes current position  
            NewTarget += new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position), transform.position.z);

            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = NewTarget;                          //Change target destination on navmesh to equal random point we just generated    
       
            startTime = Time.time;
            hasGoal = true;
        }
        currentTime = Time.time;
        if ((startTime + 5.0f) <= currentTime)
        {
            hasGoal = false;
        }

    }

    void updateStats()
    {
        curPos = transform.position;
        if (curPos == lastPos)  //-
        {
            isMoving = false;

        }                       //Movement Check      
        else 
        {
            isMoving = true;
        }

        lastPos = curPos;

        if(isMoving)
        {
            energy -= 0.01f;
            hunger -= 0.01f;
        }
    }
    
        

}
