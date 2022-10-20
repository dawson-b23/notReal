using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnStressTest : MonoBehaviour
{
    private bool testActive = true;
    public GameObject NPC;
    int cloneNum = 0;
    // Start is called before the first frame update
    //void Start()
    //{
        //NPCRef = Resources.Load("Prefabs/Jackson/Queen BC");
        //Debug.Log("Reference loaded");
   // }
    void Update()
    {
        while(testActive)
        {

            //GameObject NPC =(GameObject)Instantiate(NPCRef, NPCSpawn.position, NPCSpawn.rotation);
            Instantiate(NPC, new Vector3(0, 0, 0), Quaternion.identity);
            WaitTest();
            Debug.Log("Created NPC Clone");

            cloneNum++;
            
        }
    }

    IEnumerator WaitTest()
    {
        yield return new WaitForSeconds(2);
    }

    void OnTriggerExit2D(Collider2D other)
     
    {
        testActive = false;
        Debug.Log("Broke Unity at " + cloneNum);
    }
}
