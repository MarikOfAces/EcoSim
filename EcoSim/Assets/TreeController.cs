using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour
{
	public GameObject tCont;
	public GameObject fruitPrefab;
    public int maxTrees = 100;
	public int tCount;

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
		tCont = transform.parent.gameObject;
		tCont.GetComponent<TreeManage> ().visTreeCount++;
		name = ("Tree" + tCont.GetComponent<TreeManage> ().visTreeCount);

		RecentlyBred = false;
        breedStr = Random.Range(10, 25);
        sizeModify = Random.Range(1.0f, 3.0f);
        growSpeed = Random.Range(1.00001f, 1.00005f);
        maxSize = Random.Range(5.0f, 20.0f);
        heightModify = Random.Range(3.0f, 10.0f);
		age = 0;
        spaceNeeded = (maxSize * 2.5f);
        Vector3 temp = new Vector3(sizeModify,sizeModify*heightModify,sizeModify);
        transform.localScale = temp;
            temp = new Vector3(transform.position.x ,(Terrain.activeTerrain.SampleHeight(transform.position)+(transform.localScale.y)),transform.position.z);
        transform.position = temp;
		//ransform.localScale -= Vector3 (1, 1, 1);
		transform.localScale -= new Vector3(transform.localScale.x -1,transform.localScale.y-1,transform.localScale.z-1);

		health = sizeModify * maxSize;
    }

    // Update is called once per frame
    void Update()
    {
		//int tCount = gameObject.transform.parent.GetComponent<TreeManage>().visTreeCount;
        age += 0.1f;
		if (age > BREED_AGE) {
			if (Random.Range (0, 1000) < 1) {
				maxFruit = ((int)breedStr * (int)sizeModify * ((int)age / 10)) / 10;
				spawnFruit ();
			}
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
        if (maxTrees > tCont.GetComponent<TreeManage>().visTreeCount)
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
                    //GameObject originTree = new GameObject();
                    //originTree = gameObject;

                    GameObject tempTree ;// = new GameObject(); 	
                    tempTree = Instantiate<GameObject>(gameObject);//Copy mother tree, instantiate child as a clone of mother
					foreach (Transform child in tempTree.transform) {
						Destroy(child.gameObject);		//delete any fruits we copied from mother tree
					}
                    tempTree.name = (gameObject.name + " " + tCount);         //set tree name to parent name+unique number         
                    tempTree.transform.position = spawnPos;                                 //Move clone to new position
					tempTree.transform.parent = transform.parent;
					tempTree.GetComponent<TreeController>().RecentlyBred = false;
                     
                }
            }

        }
    }
    void grow()
    {
        gameObject.transform.localScale *= growSpeed;
		gameObject.transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y* growSpeed*growSpeed*growSpeed,transform.localScale.z);
        Vector3 tempVec = new Vector3(transform.position.x ,(Terrain.activeTerrain.SampleHeight(transform.position)+(transform.localScale.y)),transform.position.z);
        transform.position = tempVec;
    }
	void spawnFruit()
	{
		if (maxFruit > fruitCount) {
			GameObject tempFruit;
			tempFruit = Instantiate (fruitPrefab);
			tempFruit.name = ("Fruit");     
                 

			tempFruit.transform.parent = transform;//Move clone to new position & parent to tree

			Vector3 tempVec = transform.position;	//Pick random point around us 
			tempVec += (Random.insideUnitSphere * 3);
			//tempVec = new Vector3(tempVec.x,(Terrain.activeTerrain.SampleHeight(tempFruit.transform.position)),tempVec.z);
			tempFruit.transform.position = tempVec;


			fruitCount++;
			health -= 0.1f;
		} else {
			if (Random.Range (0,2) > 0)
			{
				tCount--;
			}
			health -= 0.3f;
		}
		if (health < 0) {
			maxTrees++;
			Destroy(gameObject);
		}
	}
	
}