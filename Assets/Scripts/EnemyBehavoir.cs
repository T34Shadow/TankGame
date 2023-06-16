using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoir : MonoBehaviour
{
    //Movement Properties 
    [Header("Tank's Movement Properties")]
    [SerializeField] float forwardSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] GameObject tank;
    private bool isMoveing;
    

    //Rotating tank Properties 

    //Rotating turret Properties 

    //Barrel Properties 

    //Shell Properties 

    //Range to player
    [Header("Range to player Properties ")]
    [SerializeField] float maxFireRange;
    [SerializeField] float minProxiRange;
    
    private bool isNearPlayer;

    //Line of fire

  
    //Players Properties
    [Header("Player's Properties")]
    [SerializeField] GameObject PlayerTank;




    public void rangeToPlayer()
    {
        Vector3 playerPos = PlayerTank.transform.position;
        Vector3 tankPos = tank.transform.position;

        Vector3 displacmentToPlayer = playerPos - tankPos;
        Debug.Log(displacmentToPlayer);
        
    }

    // Update is called once per frame
    void Update()
    {

        //Flee - flee if the player gets to close 
        Flee();
        rangeToPlayer();

        //move towards - if the player is out of range the tanks line of fire

        //repostion - if the tank is within range of the player but there is somthing in the line of fire

        //hold postion - ready to shoot, and the plauer is not to close and the tank as a clear line of sight

        //attack - if the tank is in hold postion, aim at player and shoot


    }

    public void Flee()
    {
        
    }
}
