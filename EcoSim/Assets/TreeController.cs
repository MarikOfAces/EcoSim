using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour
{
    public int maxTrees = 100;

    public int age = 0;
    public int breedStr;
	public int fruitCount;
	public int maxFruit;

    public float sizeModify;
    public float growSpeed;
    public float spaceNeeded;
    public float maxSize;
    public float heightModify;

	public float health;

    public Vector3 VecDebug; //make this = to a vector you wish to track in inspector. 

    // Use this for initialization
    void Start()
    {
		tag = 
        breedStr = Random.Range(10, 25);
        sizeModify = Random.Range(1.0f, 3.0f);
        growSpeed = Random.Range(1.00001f, 1.00005f);
        maxSize = Random.Range(5.0f, 20.0f);
        heightModify = Random.Range(3.0f, 10.0f);
		maxFruit = (int)breedStr * (int)maxSize;

        spaceNeeded = (maxSize * 1.5f);
        Vector3 temp = new Vector3(sizeModify,sizeModify*heightModify,sizeModify);
        transform.localScale = temp;
            temp = new Vector3(transform.position.x ,(Terrain.activeTerrain.SampleHeight(transform.position)+(transform.localScale.y)),transform.position.z);
        transform.position = temp;
        name = ("Tree" + TreeManage.treeCount);
    }

    // Update is called once per frame
    void Update()
    {
        age++;
		if (Random.Range(0, 100) < 1) {
			spawnFruit();
		}
        if (transform.localScale.y < maxSize)
        {
            grow();
        }
        int breedChance = Random.Range(1, 1000);
        if (breedChance > 900)
        {
            
            spawnSappling(breedStr);
            breedChance = 0;
            //transform

        }
    }

    void spawnSappling(int breedStr)
    {
        if (maxTrees > TreeManage.treeCount)
        {
            if (breedStr > 0)
            {
                breedStr--;
                Vector3 spawnPos = (Random.insideUnitSphere*200);
                spawnPos.y = Terrain.activeTerrain.SampleHeight(spawnPos);
                VecDebug = spawnPos;
                if (Vector3.Distance(spawnPos, transform.position) > spaceNeeded)
                {
                    TreeManage.treeCount++;    
                    //GameObject originTree = new GameObject();
                    //originTree = gameObject;

                    GameObject tempTree ;// = new GameObject(); 

                    tempTree = Instantiate<GameObject>(gameObject);
                    tempTree.name = (gameObject.name + " " + TreeManage.treeCount);         //set tree name to parent name+unique number         
                    tempTree.transform.position = spawnPos;                                 //Move clone to new position
                    //Instantiate(tempTree, spawnPos, tempQuart);                             //create our tree using 'tempTree'

                    //tempTree.AddComponent<
                    //tempTree.AddComponent<TreeController>();                   
                    //tempTree.name = ("Tree" + TreeManage.treeCount);
                    //Instantiate(tempTree)

                     
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
		fruitCount++;
		health -= 0.1f;
	}
}