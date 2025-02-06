using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PoisonSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject poison;
    [SerializeField]
    private float poisonTimer, currentPoisonTimer;
    //private Vector3 poisonOffset = new Vector3(0.5f,0,0);
    private Vector2 lastPosition,movementDirection;
    public float spawnDistance = 10f;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        poisonTimer = 0.25f;
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = transform.position;
        movementDirection = (currentPosition-lastPosition).normalized;

        currentPoisonTimer += Time.deltaTime;
        if(currentPoisonTimer >= poisonTimer){
            SpawnPoison();
            currentPoisonTimer = 0;
        }
    }

    void SpawnPoison(){
        if(movementDirection != Vector2.zero){
            Vector2 spawnPosition = (Vector2)transform.position - movementDirection * spawnDistance;
            Instantiate(poison, spawnPosition, Quaternion.identity);
        }
    }
}
