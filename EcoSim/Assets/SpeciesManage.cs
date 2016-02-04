using UnityEngine;
using System.Collections;

public class SpeciesManage : MonoBehaviour {
    public static int speciesCount = 0;
    public static bool spawningFinished = false;
    public static bool spawningStarted = false;
    public bool visSpwnFin;
    public int visSpeciesCount;
    public bool visSpwnStrt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        visSpeciesCount = speciesCount;
        visSpwnFin = spawningFinished;
        visSpwnStrt = spawningStarted;
	}
}
