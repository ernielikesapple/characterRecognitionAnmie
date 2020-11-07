using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animatedObjects : MonoBehaviour
{
    public GameObject redGO;
    public GameObject blueGO;
    public extractImageInfo ex;
    Dictionary<string, List<Vector3>> coordinatesDic = new Dictionary<string, List<Vector3>>();
    static List<GameObject> redGOLists = new List<GameObject>();
    static List<GameObject> blueGOLists = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        coordinatesDic = ex.GetRednBlueCoordinates();
        loadInitialStates();
    }

    // Update is called once per frame
    void Update()
    {
        animatingObjects();
    }

    void loadInitialStates() {
        for (int i = 0; i < coordinatesDic["red"].Count; i++)
        {
            Vector3 redCoord = coordinatesDic["red"][i];
            redGOLists.Add(Instantiate(redGO, redCoord, Quaternion.identity) as GameObject);
        }

        for (int i = 0; i < coordinatesDic["blue"].Count; i++ )
        {
            Vector3 blueCoord = coordinatesDic["blue"][i];
            blueGOLists.Add(Instantiate(blueGO, blueCoord, Quaternion.identity) as GameObject);
        }
    }

    void animatingObjects() {
        for (int i = 0; i < redGOLists.Count; i++)
        {
            GameObject redG = redGOLists[i];
            NavMeshAgent redAgent = redG.GetComponent<NavMeshAgent>();
            redAgent.SetDestination(new Vector3(coordinatesDic["red"][i].x - 100f, coordinatesDic["red"][i].y, coordinatesDic["red"][i].z));
        }
        
        for (int j = 0; j < blueGOLists.Count; j++)
        {
            Debug.Log("???");
            GameObject blueG = blueGOLists[j];
            NavMeshAgent blueAgent = blueG.GetComponent<NavMeshAgent>();

            
            blueAgent.SetDestination(new Vector3(coordinatesDic["blue"][j].x - 100f, coordinatesDic["blue"][j].y, coordinatesDic["blue"][j].z));
        }
    }
}
