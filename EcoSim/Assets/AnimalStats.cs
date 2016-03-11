using UnityEngine;
using System.Collections;



public class AnimalStats : MonoBehaviour
{
	const float ageRate = 0.01f;
	//Decides how to spawn animal
	public bool wasBorn;

	//Animal Related//
	public enum Gender { Male, Female};
	public Gender myGender = new Gender();
	public int genderVal;
	public bool willBreed;
	public bool isPregnant;
	public float age;
	public float health;


    public float attack;
    public float hunger;
    public float thirst;
    public float energy;
    public float speed;
    public GameObject huntTarget;
    public GameObject foodTarget;
    public int TargetNumber;
    public GameObject breedTarget;

	public GameObject fatherObj;
	public GameObject motherObj;


    public float dDay;
    public bool sleeping;

    public bool attackRange = false;

	public float dietWeight;
	public bool Herbivore = false;
	public bool Carnivore = false;	//IF BOTH = TRUE, OMNIVORE
	
	public bool hasGoal;
	public bool canGiveBirth;
	
	public Vector3 curPos;
	public Vector3 lastPos;
	public bool isMoving;


    //public int noOfSpecies = 10;
    public int sNumber;
    public int Number;
    public float breedAge;
    public float deathAge;
    public int breedCount;
	public float GestPeriod;
	public float myGestPeriod;
	public int breedCount;
    public float baseAttack;
    public float baseHealth;
    public float size;
    public enum Diet { Herb, Omni, Carn } // 0 = Herb, 1 = Omni, 2 = Carn
	float wanderRadius = 20.0f;
	bool needToEat = false;
	bool needToDrink = false;
	public float startTime = 0;
	public float currentTime = 0;
	public Vector3 NewTarget;



    void Start()
    {
		Debug.Log ("ERROR HERE");
			//deathAge = transform.parent.GetComponent<SpeciesCreator>().deathAge;
			dDay = (deathAge + (Random.Range (-deathAge / 5, deathAge / 5)));
			willBreed = false;
			isPregnant = false;
			age = 0;
			health = 10;//(baseHealth + Random.Range(-baseHealth / 10, baseHealth / 10));
			attack = (baseAttack + Random.Range (-baseAttack / 10, baseAttack / 10));
			hunger = 100.0f;
			thirst = 100.0f;
			energy = 100.0f;
			speed = 1.0f;
		if (genderVal == 0) {
			myGender = Gender.Male;
		} 
		else if (genderVal == 1) {
			myGender = Gender.Female;
		}
			
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

		age += ageRate;
		float thirdAge;
		thirdAge = deathAge/3;
		float twothirdAge;
		twothirdAge = thirdAge*2;

		if ((age > 0)&&(!isPregnant)) {
			willBreed = true;
		}
		HungerCheck();
		Wander ();
		updateStats();
		deathCheck();
		if (willBreed){
			BreedCheck();
		}
		if (isPregnant) {

			Pregnancy();
		}


		if (age < thirdAge)   //1st third of life = child
		{
				//DO CHILDHOOD



		}
		if ((age > thirdAge)&&(age < twothirdAge))//middle portion of life, able to breed.
		{

		}
		
		if (age < twothirdAge)//final portion of life.
		{


			
		}	
	}

	void BreedCheck()
	{
		if ((myGender == Gender.Male)&&(!needToDrink)&&(!needToEat))
		{
			breedTarget = scanArea("Animal");
			if((breedTarget.GetComponent<AnimalStats>().sNumber != sNumber)||(breedTarget.GetComponent<AnimalStats>().myGender == myGender))
			{
				breedTarget = null;
			}
			if(breedTarget != null)
			{
				if((breedTarget.GetComponent<AnimalStats>().sNumber == sNumber)&&(!breedTarget.GetComponent<AnimalStats>().isPregnant)&&(breedTarget.GetComponent<AnimalStats>().fatherObj != gameObject)&&(breedTarget != this.motherObj))
				{
					NavMeshAgent agent = GetComponent<NavMeshAgent> ();
					agent.destination = breedTarget.transform.position;
					//agent.speed = speed;
					if(Vector3.Distance(breedTarget.transform.position,transform.position) < 5.0f)
					{
						if (breedTarget.GetComponent<AnimalStats>().willBreed && (breedTarget.GetComponent<AnimalStats>().myGender == Gender.Female))//If they will breed
						breedTarget.GetComponent<AnimalStats>().breedTarget = this.gameObject;	//Do it.

					}
				}
			}
		}
		if (myGender == Gender.Female)
		{
			if (breedTarget != null)	//If we have 'Male DNA'
			{
				willBreed = false;
				isPregnant = true;
				myGestPeriod = GestPeriod;
			}
					
		}
	}

	void Pregnancy()
	{
		if (myGender = Gender.Female) {
			myGestPeriod -= ageRate;
			if (myGestPeriod < 1.0f) {
				breedCount++;
				GameObject babyAnimal = null;
				babyAnimal = Instantiate (gameObject);
				babyAnimal.GetComponent<AnimalStats> ().breedTarget = null;
				babyAnimal.GetComponent<AnimalStats> ().isPregnant = false;
				babyAnimal.GetComponent<AnimalStats> ().willBreed = false;

				babyAnimal.name = (name + ' ' + breedTarget.GetComponent<AnimalStats> ().name + ": " + breedCount);
				babyAnimal.transform.parent = transform.parent.transform;
				babyAnimal.transform.position = transform.position;
			
				babyAnimal.GetComponent<AnimalStats> ().deathAge = (breedTarget.GetComponent<AnimalStats> ().deathAge + deathAge) / 2;
				babyAnimal.GetComponent<AnimalStats> ().breedAge = (breedTarget.GetComponent<AnimalStats> ().breedAge + breedAge) / 2;
				babyAnimal.GetComponent<AnimalStats> ().baseHealth = (breedTarget.GetComponent<AnimalStats> ().baseHealth + baseHealth) / 2;
				babyAnimal.GetComponent<AnimalStats> ().baseAttack = (breedTarget.GetComponent<AnimalStats> ().baseAttack + baseAttack) / 2;
				babyAnimal.GetComponent<AnimalStats> ().Herbivore = Herbivore;
				babyAnimal.GetComponent<AnimalStats> ().Carnivore = Carnivore;
				babyAnimal.GetComponent<AnimalStats> ().sNumber = sNumber;
				babyAnimal.GetComponent<AnimalStats> ().genderVal = Random.Range (0, 2);
				babyAnimal.GetComponent<AnimalStats> ().fatherObj = breedTarget;
				babyAnimal.GetComponent<AnimalStats> ().motherObj = gameObject;

	
				breedTarget = null;
				isPregnant = false;
			}
		}

	}


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
			
				NewTarget = Random.insideUnitSphere * wanderRadius;     //Generate a circle around the snake of radius 'WanderRadius' and choose a random new point in that circle
				//NewTarget += transform.position;                        //Add new target to snakes current position  
				NewTarget += new Vector3 (transform.position.x, Terrain.activeTerrain.SampleHeight (transform.position), transform.position.z);
			
				NavMeshAgent agent = GetComponent<NavMeshAgent> ();
				agent.destination = NewTarget;                          //Change target destination on navmesh to equal random point we just generated    
			
				startTime = Time.time;
				hasGoal = true;
			}
			currentTime = Time.time;
			if ((startTime + 5.0f) <= currentTime) {
				hasGoal = false;
				NewTarget = new Vector3(0,0,0);
				//NewTarget
			}	
		}
	}

	void updateStats()
	{
		energy -= 0.001f;
		hunger -= 0.001f;
		thirst -= 0.0001f;
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
			thirst -= 0.001f;
		}
		if (hunger <= 0) {
			hunger = 0;
			health-= 0.1f;
		}
		if (thirst <= 0) {
			thirst = 0;
			health-= 0.1f;
		}
	}

	void HungerCheck()
	{

		if (hunger < 50) {
			needToEat = true;
		}
		if (hunger > 85)
			needToEat = false;
			foodTarget = null;
		if (thirst < 50) {
			needToDrink = true;
		}
		if (thirst > 85) {
			needToDrink = false;
		}
		if (needToDrink) {
			foodTarget = scanArea("Water");
			if ((foodTarget != null)&&(foodTarget.tag == "Water"))
			{
				print ("Moving to water");
				Vector3 closestWater = foodTarget.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
				NavMeshAgent agent = GetComponent<NavMeshAgent> ();
				agent.destination = foodTarget.transform.position;
				Ray ray = new Ray(transform.position,Vector3.down);
				RaycastHit rayHit;
				if(Physics.Raycast(ray,out rayHit,1))
				{
					if(rayHit.transform.tag == "Water")
					{
						agent.destination = transform.position;
						thirst +=0.3f;
					}
				}
			}
		}
		if (needToEat) {
			{

				//print ("HUNGRY");
				if (Herbivore && (foodTarget == null)) {
					foodTarget = scanArea("Fruit");
				}
			//EAT PLANT LIFE
				if (Carnivore && (foodTarget == null)) {
					foodTarget = scanArea("Meat");
					//Kill prey
					//eat
				}
				if (foodTarget != null)
				{
					NavMeshAgent agent = GetComponent<NavMeshAgent> ();
					agent.destination = foodTarget.transform.position; //Moveto object
					//print(Vector3.Distance(gameObject.transform.position,foodTarget.transform.position));
					if (Vector3.Distance(gameObject.transform.position,foodTarget.transform.position) < 2.0f);
					{
						//gameObject.GetComponent<NavMeshAgent> ().Stop ();
						if (foodTarget.tag == ("Meat"))	
						{
							hunger += 1f;
							foodTarget.GetComponent<AnimalStats>().hunger -= 1.5f ;
							if (foodTarget.GetComponent<AnimalStats>().hunger <= 0)
								Destroy(foodTarget);
						}
						if (foodTarget.tag == ("Fruit"))
						{
							hunger += 0.5f;
							foodTarget.GetComponent<FruitStats>().Nutrition -=0.5f;
							if (foodTarget.GetComponent<FruitStats>().Nutrition <= 0)
							Destroy(foodTarget);
						}
					}
				}
			}
		}
	}

	void eat()
	{
		gameObject.GetComponent<NavMeshAgent> ().Stop ();

	}

	void deathCheck()
	{
		if ((health < 0.1)||(age > deathAge)){
			gameObject.name = ("Corpse");
			gameObject.tag = ("Meat");
			Destroy (gameObject, 120);
			gameObject.GetComponent<NavMeshAgent>().Stop();
		}
		//GameObject tempOBJ;
		//tempOBJ.transform.position.Set (transform.position.x,transform.position.y,transform.position.z);
		//tempOBJ.transform.localScale.Set(transform.localScale.x,transform.localScale.y,transform.localScale.z);
		//tempOBJ = GameObject.CreatePrimitive (PrimitiveType.Cube);
		//Destroy (gameObject);
	}	

	GameObject scanArea(string LookingFor){
		Collider[] hitColliders = Physics.OverlapSphere (transform.position, 40.0f);
		int i = 0;
		//print (LookingFor);
		foreach (Collider col in hitColliders) {
			if ((col.tag == "Animal"))
			{

				return col.gameObject;

			}
			else if (col.tag == LookingFor){
				if (col.gameObject.transform.position.y > transform.position.y + 1)
					return null;
				return col.gameObject;
				//print("targetFOUND");

			}

		}
		return null;
	}

















    void HungerCheck()
    {

        if (hunger < 50)
        {
            needToEat = true;
        }
        if (hunger > 85)
            needToEat = false;
        foodTarget = null;

        if (needToEat)
        {
            {

                //print ("HUNGRY");
                if (Herbivore && (foodTarget == null))
                {
                    print("LookingForFruit");
                    foodTarget = scanArea("Fruit", 1);

                }
                //EAT PLANT LIFE
                if (Carnivore && (foodTarget == null))
                {
                    foodTarget = scanArea("Meat", 0);
                    if (foodTarget == null)
                        hunt();


                    //Kill prey
                    //eat
                }
                if (foodTarget != null)
                {
                    NavMeshAgent agent = GetComponent<NavMeshAgent>();
                    agent.destination = foodTarget.transform.position; //Moveto object
                    //print(Vector3.Distance(gameObject.transform.position,foodTarget.transform.position));
                    if (Vector3.Distance(gameObject.transform.position, foodTarget.transform.position) < 0.5f) ;
                    {
                        //gameObject.GetComponent<NavMeshAgent> ().Stop ();
                        if (foodTarget.tag == ("Meat"))
                        {
                            hunger += 1f;
                            foodTarget.GetComponent<AnimalStats>().hunger -= 1.5f;
                            if (foodTarget.GetComponent<AnimalStats>().hunger <= 0)
                                Destroy(foodTarget);
                        }
                        if (foodTarget.tag == ("Fruit"))
                        {
                            hunger += 0.1f;
                            foodTarget.GetComponent<FruitStats>().Nutrition -= 0.3f;
                            if (foodTarget.GetComponent<FruitStats>().Nutrition <= 0)
                                Destroy(foodTarget);
                        }
                    }
                }
            }
        }
    }

    void hunt()
    {
        if (huntTarget == null)
            huntTarget = scanArea("Animal", 0);//scan for animal
        if (TargetNumber != sNumber)    //check it's from a different species
        {
            //hasGoal = true;
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            NewTarget = huntTarget.transform.position;
            agent.destination = huntTarget.transform.position; //Moveto object
            //print(Vector3.Distance(huntTarget.transform.position, transform.position));
            if (Vector3.Distance(huntTarget.transform.position, transform.position) < 5.0f) //If we are close, attack
            {
                attackRange = true;
                attackTarget(); //Attack
                foodTarget = huntTarget; //Check area for meat (If enemy dies, there will be meat)
            }







}