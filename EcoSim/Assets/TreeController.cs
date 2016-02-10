using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour
{
	public GameObject fruitPrefab;
    public int maxTrees = 100;

    public float age = 0;
    public int breedStr;
	public int fruitCount;
	public int maxFruit;

    public float sizeModify;
    public float growSpeed;
    public float spaceNeeded;
    public float maxSize;
    public float heightModify;
	public bool RecentlyBred = false;

	const int BREED_AGE = 35;

	public float health;

    public Vector3 VecDebug; //make this = to a vector you wish to track in inspector. 

	public bool timerStarted = false;
	public float startTime = 0;
	public float currentTime = 0;

    // Use this for initialization
    void Start()
    {

		RecentlyBred = false;
        breedStr = Random.Range(10, 25);
        sizeModify = Random.Range(1.0f, 3.0f);
        growSpeed = Random.Range(1.00001f, 1.00005f);
        maxSize = Random.Range(5.0f, 20.0f);
        heightModify = Random.Range(3.0f, 10.0f);
		maxFruit = (int)breedStr * (int)maxSize;
		age = 0;
        spaceNeeded = (maxSize * 2.5f);
        Vector3 temp = new Vector3(sizeModify,sizeModify*heightModify,sizeModify);
        transform.localScale = temp;
            temp = new Vector3(transform.position.x ,(Terrain.activeTerrain.SampleHeight(transform.position)+(transform.localScale.y)),transform.position.z);
        transform.position = temp;
        name = ("Tree" + TreeManage.treeCount);
    }

    // Update is called once per frame
    void Update()
    {
        age += 0.1f;
		if (Random.Range(0, 100) < 1) {
			spawnFruit();
		}
        if (transform.localScale.y < maxSize)
        {
            grow();
        }
		if (age < BREED_AGE)
			RecentlyBred = false;
		if ((age > BREED_AGE)&&!RecentlyBred) {
			int breedChance = Random.Range (1, 1001);
			if (breedChance > 900) {
				print ("TRIED TO BREED");
				spawnSappling (breedStr);
				RecentlyBred = true;
				//transform
			}
		}
		if (RecentlyBred) {
			if (!timerStarted) {
				startTime = Time.time;
				timerStarted = true;
			}
			
			if (timerStarted) {
				currentTime = Time.time;
				if ((startTime + 15.0f) <= currentTime) {
					RecentlyBred = false;
					print ("Breed Reset");
					timerStarted = false;
					
				}
			}
		}

    }

    void spawnSappling(int breedStr)
    {
        if (maxTrees > TreeManage.treeCount)
        {
            if (breedStr > 0)
            {
				Vector3 spawnDirect = new Vector3((Random.Range(-10,11)),0,(Random.Range(-10,11)));
				Vector3 spawnPos = (Random.insideUnitSphere*50);
				spawnPos += spawnDirect;
				spawnPos += transform.position;
                spawnPos.y = Terrain.activeTerrain.SampleHeight(spawnPos);
                VecDebug = spawnPos;
                if (Vector3.Distance(spawnPos, transform.position) > spaceNeeded)
                {

					int breedrandom = Random.Range(0,10);
					if (breedrandom == 1||breedrandom ==2||breedrandom ==3||breedrandom ==4||breedrandom ==5)
						breedStr--;
					if (breedrandom == 9||breedrandom ==10)
						breedStr++;
					TreeManage.treeCount++;    
                    //GameObject originTree = new GameObject();
                    //originTree = gameObject;

                    GameObject tempTree ;// = new GameObject(); 

                    tempTree = Instantiate<GameObject>(gameObject);
                    tempTree.name = (gameObject.name + " " + TreeManage.treeCount);         //set tree name to parent name+unique number         
                    tempTree.transform.position = spawnPos;                                 //Move clone to new position
					tempTree.transform.parent = transform.parent;
					tempTree.GetComponent<TreeController>().RecentlyBred = false;
                    //Instantiate(tempTree, spawnPos, tempQuart);                             //create our tree using 'tempTree'

                    //tempTree.AddComponent<
                    //tempTree.AddComponent<TreeController>();                   
                    //tempTree.name = ("Tree" + TreeManage.treeCount);
                    //Instantiate(tempTree)
//					tempAnimal = Instantiate(animalPrefab);
//					
//					tempAnimal.name = ("ThisAnimal" + i);
//					tempAnimal.transform.parent = gSpecies.transform;
//					tempAnimal.AddComponent<AnimalStats>();
//					tempAnimal.AddComponent<NavMeshAgent>();
                     
                }
            }

        }
    }
    void grow()
    {
        gameObject.transform.localScale *= growSpeed;
        Vector3 tempVec = new Vector3(transform.position.x ,(Terrain.activeTerrain.SampleHeight(transform.position)+(transform.localScale.y)),transform.position.z);
        transform.position = tempVec;
    }
	void spawnFruit()
	{
		GameObject tempFruit ;
		tempFruit = Instantiate(fruitPrefab);
		tempFruit.name = ("Fruit");     
                 

		tempFruit.transform.parent = transform;//Move clone to new position & parent to tree

		Vector3 tempVec = transform.position;	//Pick random point around us 
		tempVec += (Random.insideUnitSphere*3);
		//tempVec = new Vector3(tempVec.x,(Terrain.activeTerrain.SampleHeight(tempFruit.transform.position)),tempVec.z);
		tempFruit.transform.position = tempVec;


		fruitCount++;
		health -= 0.1f;
	}
	
}