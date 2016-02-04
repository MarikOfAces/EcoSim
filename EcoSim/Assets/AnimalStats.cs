using UnityEngine;
using System.Collections;



public class Species : MonoBehaviour
{
    //public int noOfSpecies = 10;
    public string sName;
    public int Number;
    public float breedAge;
    public float deathAge;
    public float baseAttack;
    public float baseHealth;
    public float size;
    public enum Diet { Herb, Omni, Carn } // 0 = Herb, 1 = Omni, 2 = Carn

    //void Start()
    //{
    //    deathAge = Random.Range(120.0f, 600.0f);
    //    breedAge = deathAge / 5;
    //    size = Random.Range(0.5f, 2.0f);
    //    baseHealth = (Random.Range(50.0f, 200.0f) * size);
    //    baseAttack = (baseHealth / 10);
    //    Debug.Log(deathAge);
    //}
    public Species()
    {
        //for (int count = 0; count < noOfSpecies; count++)
        //{
        //species.Number = speciesNo;
        //Species species = new Species();        

        //Debug.Log("Death Age (InitSpecies)");
        // Debug.Log(species.deathAge);

        //mySpeciesList[count] = species;
        //species = new Species();
        //}
    }
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

public class Animal : Species
{
    public float health;
    public float attack;
    public float hunger;
    public float thirst;
    public float speed;

    //void Start()
    //{
    //    //Animal animal = new Animal();
    //   // Instantiate(animal);
    //    //GameObject.CreatePrimitive()
    //    //myAnimal.deathAge = myAnimal.InitSpecies().deathAge;
    //    //Species mySpecies = new Species();
    //    //mySpecies = mySpecies.InitSpecies();
    //    //myAnimal = mySpecies;
    //    //myAnimal.breedAge = myAnimal

    //    //species.deathAge = Random.Range(120.0f, 600.0f);
    //    //species.breedAge = species.deathAge / 5;
    //    //species.size = Random.Range(0.5f, 2.0f);
    //    //species.baseHealth = (Random.Range(50.0f, 200.0f) * species.size);
    //    //species.baseAttack = (species.baseHealth / 10);



    //    //Debug.Log("Death Age (createSpecies)");
    //   // Debug.Log(myAnimal.deathAge);
    //    health = (baseHealth + Random.Range(-baseHealth / 10, baseHealth/10));
    //    attack = (baseAttack + Random.Range(-baseAttack / 10, baseAttack / 10));
    //    hunger = 100.0f;
    //    thirst = 100.0f;
    //    speed = 1.0f;        
    //   // Debug.Log(myAnimal.health);
    //}   
}


public class AnimalStats : Species {
    //public GameObject thisAnimal;
    public float health;
    public float attack;
    public float hunger;
    public float thirst;
    public float speed;

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


