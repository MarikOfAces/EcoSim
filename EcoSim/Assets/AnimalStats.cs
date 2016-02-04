using UnityEngine;
using System.Collections;



public class AnimalStats : MonoBehaviour
{
	//Decides how to spawn animal
	public bool wasBorn;

	//Animal Related//
	public enum Gender { Male, Female};
	public Gender myGender = new Gender();
	public bool willBreed;
	public float age;
	public float health;


	public float attack;
	public float hunger;
	public float thirst;
	public float energy;
	public float speed;



	public float dDay;
	public bool sleeping;

	public float dietWeight;
	public bool Herbivore = false;
	public bool Carnivore = false;	//IF BOTH = TRUE, OMNIVORE
	
	public bool hasGoal;
	public bool canGiveBirth;
	
	public Vector3 curPos;
	public Vector3 lastPos;
	public bool isMoving;


    //public int noOfSpecies = 10;
    public string sName;
    public int Number;
    public float breedAge;
    public float deathAge;
    public float baseAttack;
    public float baseHealth;
    public float size;
    public enum Diet { Herb, Omni, Carn } // 0 = Herb, 1 = Omni, 2 = Carn
	float wanderRadius = 2.0f;
	public float startTime = 0;
	public float currentTime = 0;

    void Start()
    {
		Debug.Log ("ERROR HERE");
			//deathAge = transform.parent.GetComponent<SpeciesCreator>().deathAge;
			dDay = (deathAge + (Random.Range (-deathAge / 5, deathAge / 5)));
			health = 10;//(baseHealth + Random.Range(-baseHealth / 10, baseHealth / 10));
			attack = (baseAttack + Random.Range (-baseAttack / 10, baseAttack / 10));
			hunger = 100.0f;
			thirst = 100.0f;
			energy = 100.0f;
			speed = 1.0f;
		death ();
			
			//name = ("animal " + i);
	}

	void Update ( ) {
		Wander ();
		LifeCycle ();
		updateStats ();
	}


//public class SpeciesList
//{
//    //static private Species[] mySpeciesList = new Species[10];
//    //public Species InitSpecies()
//    //{
//    //    //for (int count = 0; count < noOfSpecies; count++)
//    //    //{
//    //        Species species = new Species();
//    //        //species.Number = count;
//    //        species.deathAge = Random.Random(120.0f, 600.0f);
//    //        species.breedAge = species.deathAge / 5;
//    //        species.size = Random.Random(0.5f,2.0f);
//    //        species.baseHealth = (Random.Random(50.0f, 200.0f) * species.size);
//    //        species.baseAttack = (species.baseHealth / 10);
//    //        //mySpeciesList[count] = species;
//    //        //species = new Species();
//    //        return species;
//    //    //}
//    //}
//    //public Species GetSpecies(int SpeciesNo)
//    //{
//    //    //Species tempspecies = mySpeciesList[speciesNumber];
//    //    return mySpeciesList[SpeciesNo];
//    //}
//}


/*
public class AnimalStats : Species {
    //public GameObject thisAnimal;
//    public float health;
//    public float attack;
//    public float hunger;
//    public float thirst;
//    public float speed;

    public Species animalPrefab;
    public Species[] animalList;

    int i = 0;
	// Use this for initialization
	void Start () {

        health = (baseHealth + Random.Range(-baseHealth / 10, baseHealth/10));
        attack = (baseAttack + Random.Range(-baseAttack / 10, baseAttack / 10));
        hunger = 100.0f;
        thirst = 100.0f;
        speed = 1.0f;  


        
        //animalList = new Animal[1];
        //Debug.Log(animalList.Length);
        //animalPrefab = gameObject.AddComponent<Animal>();
        
        //while (animalList.Length > i)
        {            
            //Animal clone = (Animal)Instantiate(animalPrefab, Vector3.zero,Quaternion.identity);
            //GameObject.CreatePrimitive(PrimitiveType.Cube);
           // clone.name = ("animal" + i);
            //Debug.Log(i);
            //clone.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            //clone.transform.localScale = new Vector3(animalPrefab.size, animalPrefab.size, animalPrefab.size);
          //  animalList[i] = clone;
            //animalList[0].name = ("animal" + i);

            //myAnimal[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //myAnimal[i].name = 
            //myAnimal[i].AddComponent<Animal>;
            //Animal animal = gameObject.AddComponent<Animal>();           

            //animal = ;
            i++;
            print(i);
            
        }


        //GameObject animal = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //animal = AddComponent<Animal>;
        

        //SphereCollider sc = gameObject.AddComponent("SphereCollider") as SphereCollider;
        //Animal al = gameObject.AddComponent("Animal") as Animal;     
        //animal = AddComponent<Rigidbody>();
        
        //animal.transform.localScale = 0 ;

        
        //EnumRands();
        //for (int i = 0; i < 5; i++)
       // {
            //Animal myAnimal = new Animal();
            //Instantiate()
            //Instantiate(AnimalStats);
            //print(myAnimal.deathAge);


        //}
        
        //myAnimal.Equals();
        //print(myAnimal.baseAttack);

        //SpeciesList thisSpeciesList = new SpeciesList();
        //Animal thisAnimal = new Animal();
        //thisSpeciesList.InitSpecies();
        //thisAnimal.createSpecies();

	}
	

	// Update is called once per frame
	void Update () {
        //Animal thisAnimal = new Animal();
       // thisAnimal.createSpecies;

      //  SpeciesList thisSpeciesList = new SpeciesList();
       // thisSpeciesList.InitSpecies();

	}

    //void EnumRands (){
    //    int gendRand = Random.Range(0, 2);
    //    int dietRand = Random.Range(0, 3);
    //    switch (gendRand)
    //    {
    //        case 0:
    //            gender = Gender.Male;
    //            break;
    //        case 1:
    //            gender = Gender.Female;
    //            break;

    //    }
    //    switch (dietRand)
    //    {
    //        case 0:
    //            diet = Diet.Herb;
    //            break;
    //        case 1:
    //            diet = Diet.Omni;
    //            break;
    //        case 2:
    //            diet = Diet.Carn;
    //            break;

    //    }


    //}

    //void generateSpecies();



}
*/


	void LifeCycle()
	{
		age += 0.01f;
		float thirdAge;
		thirdAge = deathAge/3;
		float twothirdAge;
		twothirdAge = thirdAge*2;
		if (age < thirdAge)   //1st third of life = child
		{
				//DO CHILDHOOD
		}
		if ((age > thirdAge)&&(age < twothirdAge))//middle portion of life, able to breed.
		{
				//DO PRIME LIFE
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
							//Birth();
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
	//void Birth(/*int fHp, int fAtt, int fDDay*/)
	//{
	//	
	//	
	//	
	//	Vector3 tempVec = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));             //Place our baby near the mother.
	//	//transform.position = (spawnZone += tempVec);
	//	
	//	
	//	health = (baseHealth + Random.Range(-baseHealth / 10, baseHealth / 10));
	//	attack = (baseAttack + Random.Range(-baseAttack / 10, baseAttack / 10));
	//	hunger = 100.0f;
	//	thirst = 100.0f;
	//	energy = 100.0f;
	//	speed = 1.0f;
	//	dDay = (deathAge + (Random.Range(-deathAge / 5, deathAge / 5)));
	//	age = 0;
	//	if (Random.Range(0, 2) == 0)
	//	{
	//		myGender = Gender.Female;
	//	}
	//	else
	//	{
	//		myGender = Gender.Male;
	//	}
	//	SpeciesCreator tempChild;                                         //Create a new temporary 'Baby animal'
	//	tempChild = Instantiate<SpeciesCreator>(this);
	//	tempChild.name = (name);    //Set childs nameto parents name (Name is simply used as a species reference)
	//}

	void Wander()
	{
		if (energy < 5)
		{		
			Debug.Log ("Need to sleep");
			sleeping = true;
		}	
		if (sleeping) {
			Debug.Log("IsSleeping");
			hunger -= 0.01f;
			energy += 0.02f;
			//GetComponent<NavMeshAgent>().updatePosition = false;
			GetComponent<NavMeshAgent>().Stop();
			if(energy > 95)
			{
				sleeping = false;
				GetComponent<NavMeshAgent>().Resume();
			}
			//GetComponent<NavMeshAgent>().updatePosition = true;
		}
		else if (!sleeping) {
			//currentTime = Time.time;
			if (hasGoal == false) {
			
				Vector3 NewTarget = Random.insideUnitSphere * wanderRadius;     //Generate a circle around the snake of radius 'WanderRadius' and choose a random new point in that circle
				NewTarget += transform.position;                        //Add new target to snakes current position  
				NewTarget += new Vector3 (transform.position.x, Terrain.activeTerrain.SampleHeight (transform.position), transform.position.z);
			
				NavMeshAgent agent = GetComponent<NavMeshAgent> ();
				agent.destination = NewTarget;                          //Change target destination on navmesh to equal random point we just generated    
			
				startTime = Time.time;
				hasGoal = true;
			}
			currentTime = Time.time;
			if ((startTime + 5.0f) <= currentTime) {
				hasGoal = false;
			}
		
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

	void hunt()
	{
		if (hunger < 5) {
			{
				if (Herbivore) {
					//MoveTo objecty
					//Eat Object
				}
			//EAT PLANT LIFE
		else if (Carnivore) {
					//Moveto object
					//Kill prey
					//eat
				}
			}
		}
	}

	void eat()
	{
	}

	void death(){
		//GameObject tempOBJ;
		//tempOBJ.transform.position.Set (transform.position.x,transform.position.y,transform.position.z);
		//tempOBJ.transform.localScale.Set(transform.localScale.x,transform.localScale.y,transform.localScale.z);
		//tempOBJ = GameObject.CreatePrimitive (PrimitiveType.Cube);
		Destroy (gameObject);
	}
		
}