using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SlimeMovement : MonoBehaviour
{
       // Start is called before the first frame update
    private NavMeshAgent agent;
    private GameObject player;

    private Vector2 playerDirection;
    private GameObject healthBar;


    private bool canMove;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            Debug.Log("player not found :(");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && canMove){
            agent.SetDestination(player.transform.position);
        } else{
            agent.SetDestination(gameObject.transform.position);
        }
        FacePlayer();
    }

    void CanMove(){
        canMove = true;
    }

    void LockMove(){
        canMove = false;
    }

    public void FacePlayer(){
        playerDirection = player.transform.position-gameObject.transform.position;
        if(playerDirection.x <0){
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            healthBar.transform.localScale = new Vector3(-1, 1, 1);
        }else{
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            healthBar.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}