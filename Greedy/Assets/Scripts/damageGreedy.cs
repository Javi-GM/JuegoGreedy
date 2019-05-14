using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageGreedy : MonoBehaviour
{
    public int daño;
    public GameObject player;
    GreedyMovement gm;

    void Start()
    {
        gm = player.GetComponent<GreedyMovement>();
    }

        void OnTriggerEnter(Collider other)
    {
        
        if(other.name == "Rabbit_Red")
        {
            gm.GhostHit();
            Debug.Log("Daño");
            //Debug.Log(other);
        }
    }
}