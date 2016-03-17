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

	public float flee;
	public float fight;

    public float attack;
	public float aggression;
    public float hunger;
    public float thirst;
    public float energy;
    public float speed;
	public float baseSpeed;
	public float maxSpeed;
	public bool running;

    public int TargetNumber;
    public GameObject breedTarget;
	public GameObject huntTarget;
	public GameObject foodTarget;
	public GameObject combatTarget;

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
    public float baseAttack;
    public float baseHealth;
    public float size;
    public enum Diet { Herb, Omni, Carn } // 0 = Herb, 1 = Omni, 2 = Carn
	float wanderRadius = 20.0f;
	public bool needToEat = false;
	public bool needToDrink = false;
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
			baseHealth = (baseHealth + Random.Range(-baseHealth / 10, baseHealth / 10));
		health = baseHealth;
			attack = (baseAttack + Random.Range (-baseAttack / 10, baseAttack / 10));
		aggression *= (Random.Range (0.9f,1.10f));
			hunger = 100.0f;
			thirst = 100.0f;
			energy = 100.0f;
		baseSpeed = speed;
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


	void LifeCycle()
	{

		age += ageRate;
		float thirdAge;
		thirdAge = deathAge/3;
		float twothirdAge;
		twothirdAge = thirdAge*2;

		if ((age > breedAge)&&(!isPregnant)) {
			willBreed = true;
		}
		combat ();
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
		if (running) {
			speed = baseSpeed *baseSpeed* (1 / (baseHealth / health));
		} else {
			speed = baseSpeed * (1 / (baseHealth / health));	//Decrease our speed, by a percentage equal to the percentage our health has dropped (50% health = 50% speed)
		}
		if (speed > maxSpeed)
			speed = maxSpeed;
		if (maxSpeed < baseSpeed)
			maxSpeed = baseSpeed;
	}

	void BreedCheck()
	{

		if ((myGender == Gender.Male)&&(!needToDrink)&&(!needToEat))
		{
			if(breedTarget == null)
			{
				print ("Animal Looking to breed");
				breedTarget = scanArea("Animal", 2);

			}



		}
		if((breedTarget != null)&&(myGender == Gender.Male))
		{
			if ((breedTarget.GetComponent<AnimalStats> ().isPregnant)||(breedTarget.GetComponent<AnimalStats>().sNumber != sNumber))
			{
				breedTarget = null;
			}
			if((breedTarget.GetComponent<AnimalStats>().sNumber == sNumber)&&(!breedTarget.GetComponent<AnimalStats>().isPregnant)&&(breedTarget.GetComponent<AnimalStats>().fatherObj != gameObject));//&&(breedTarget != this.motherObj))
			{
				if (breedTarget.GetComponent<AnimalStats>().myGender != myGender)
				{
					print ("Moving to breed");
					setupNavAgent(breedTarget.transform);
					//NavMeshAgent agent = GetComponent<NavMeshAgent> ();
					//agent.destination = breedTarget.transform.position;
					//agent.speed = speed = speed;
					if(Vector3.Distance(breedTarget.transform.position,transform.position) < 2.0f)
					{
						if (breedTarget.GetComponent<AnimalStats>().willBreed && (breedTarget.GetComponent<AnimalStats>().myGender == Gender.Female))//If they will breed
						{
							breedTarget.GetComponent<AnimalStats>().breedTarget = gameObject;	//Do it.
							breedTarget = null;
						}
						
					}
				}
				else
				{
					breedTarget = null;
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
		if (myGender == Gender.Female) {
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
			
				setupNavAgent(NewTarget);                         //Change target destination on navmesh to equal random point we just generated    
			
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
		if (health > baseHealth)
			health = baseHealth;
		if ((health < baseHealth) && (sleeping)) {
			hunger -= 0.02f;
			energy -= 0.1f;
			health += 0.1f;
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
			foodTarget = null;
		}
		if (needToDrink) {
			foodTarget = scanArea("Water",3);
			if ((foodTarget != null)&&(foodTarget.tag == "Water"))
			{
				print ("Moving to water");
				Vector3 closestWater = foodTarget.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
				setupNavAgent(foodTarget.transform);
				Ray ray = new Ray(transform.position,Vector3.down);
				RaycastHit rayHit;
				if(Physics.Raycast(ray,out rayHit,1))
				{
					if(rayHit.transform.tag == "Water")
					{
						setupNavAgent(gameObject.transform);
						thirst +=0.3f;
					}
				}
			}
		}
		if (needToEat) {
			{

				//print ("HUNGRY");
				if (Herbivore && (foodTarget == null)) {
					foodTarget = scanArea("Fruit", 1);
				}
			//EAT PLANT LIFE
				if (Carnivore && (foodTarget == null))
				{
					//foodTarget = scanArea("Meat", 0);
					if (foodTarget == null)
						hunt();
					//Kill prey
					//eat
				}
				if (foodTarget != null)
				{
					if (energy > 10.0f) {
						
						running = true;
						maxSpeed = Vector3.Distance(gameObject.transform.position,foodTarget.transform.position);
					}
					setupNavAgent(foodTarget.transform);
					//print(Vector3.Distance(gameObject.transform.position,foodTarget.transform.position));
					if (Vector3.Distance(gameObject.transform.position,foodTarget.transform.position) < 2.0f);
					{
						//gameObject.GetComponent<NavMeshAgent> ().Stop ();
						if (foodTarget.tag == ("Meat")&&(foodTarget != null))	
						{
							hunger += 1f;
							foodTarget.GetComponent<AnimalStats>().hunger -= 1.5f ;
							if (foodTarget.GetComponent<AnimalStats>().hunger <= 0)
								Destroy(foodTarget);
							if (health < baseHealth)
							{
								health += 0.1f;
								hunger -= 0.2f;
							}
						}
						if (foodTarget.tag == ("Fruit")&&(foodTarget != null))
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
	void hunt()
	{
		if (huntTarget == null)
			huntTarget = scanArea("Animal", 0);//scan for animal
		if (huntTarget != null) {
			if (TargetNumber != sNumber) {    //check it's from a different species
				if (energy > 10.0f) {
					
					running = true;
					maxSpeed = Vector3.Distance(gameObject.transform.position,huntTarget.transform.position);
				}
				setupNavAgent (huntTarget.transform);
				if (Vector3.Distance (huntTarget.transform.position, transform.position) < 5.0f) { //If we are close, attack
					attackRange = true;
					attackTarget (); //Attack
					foodTarget = huntTarget; //Check area for meat (If enemy dies, there will be meat)
				}
			} else 
				huntTarget = null;
		}
	}

	void combat()
	{
		if (combatTarget != null) {
			if(fightOrFlight ())	//FIGHT
			{
				running = true;
				attackTarget();
			}
			if(!fightOrFlight())	//FLEE
			{
				running = true;
				Vector3 fleeDirection = transform.position - combatTarget.transform.position;
				fleeDirection.Normalize();
				setupNavAgent(fleeDirection);
			}
		}
		
	}
	bool fightOrFlight()
	{
		flee = (1 / (baseHealth / health) * (combatTarget.GetComponent<AnimalStats> ().baseHealth / combatTarget.GetComponent<AnimalStats> ().health));//*combatTarget.health);
		fight = (1 / attack * aggression);
		if (flee > fight)
			return true;
		else
			return false;
	}
	void attackTarget()
	{

		if (huntTarget != null) {
			huntTarget.GetComponent<AnimalStats> ().combatTarget = gameObject;
			combatTarget = huntTarget;
			combatTarget.GetComponent<AnimalStats>().health = (huntTarget.GetComponent<AnimalStats>().health - (attack / 10));
		}
		if (energy > 10.0f) {
			
			running = true;
			maxSpeed = Vector3.Distance(gameObject.transform.position,combatTarget.transform.position);
		}
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

	GameObject scanArea(string LookingFor, int searchType)
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20.0f);
		foreach (Collider col in hitColliders)
		{
			print ("scan for breed");
			if ((col.tag == LookingFor)&&(col.gameObject != gameObject))
			{
				print ("scan done");
				if (searchType == 0)
				{
					if (col.gameObject.transform.position.y > transform.position.y + 1)
					{
						return null;
					}
					huntTarget = col.gameObject;
					foodTarget = col.gameObject;
					return col.gameObject;  //Animal/Corpse
				}
				if (searchType == 1)
				{
					return col.gameObject;  //Fruit 
				}
				
				if (searchType == 2)
				{
					TargetNumber = col.gameObject.GetComponent<AnimalStats>().sNumber;
					print ("numbers " + TargetNumber+sNumber);
					if (TargetNumber == sNumber)
						print ("Target same species");
						if (col.gameObject != gameObject)
					{	
						print ("target found");
							return col.gameObject; //BreedTarget
					}
				}
				if (searchType == 3)
				{
					return col.gameObject;	//Water
				}
			}
			return null;
		}
		return null;
	}
	void setupNavAgent(Transform tempT)
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = tempT.position;
		agent.speed = speed;
	}
	void setupNavAgent(Vector3 tempV)
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = tempV;
		agent.speed = speed;
	}
}

