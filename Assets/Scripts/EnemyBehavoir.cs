using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehavoir : MonoBehaviour
{
    //Movement Properties 
    [Header("Tank's Movement Properties")]
    [SerializeField] float forwardSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject tank;
    //private bool isMoveing;


    //Rotating tank Properties 

    //Rotating turret Properties 
    [Header("Tank's turret properties")]
    [SerializeField] GameObject turretRing;
    public float turretXaxis = 0;
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

    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = PlayerTank.transform.position;
        Vector3 tankPos = tank.transform.position;

        float displacementToPlayer = Vector3.Distance(tankPos, playerPos);

        if (displacementToPlayer < minProxiRange)
        {
            isNearPlayer = true;
        }
        else
        {
            isNearPlayer = false;
        }

        TankMovement();
        AimAtPlayer();

        //move towards - if the player is out of range the tanks line of fire

        //hold postion - ready to shoot, and the plauer is not to close and the tank as a clear line of sight

        //attack - if the tank is in hold postion, aim at player and shoot

    }


    public void TankMovement()
    {
        
        if (isNearPlayer is true)
        {
            Flee();
        }
        else if(isNearPlayer is false)
        {
            Repostion();
        }
    }
    public void Flee() //Flee - flee if the player gets to close 

    {
        //if the player come close to the tnak, it will want to point at the player while moveing away
        float velocity = backwardsSpeed * Time.deltaTime;
        transform.Translate(0, 0, -velocity);
    }

    public void Repostion()  //repostion - if the tank is within range of the player but there is somthing in the line of fire
    {
        float velocity = forwardSpeed * Time.deltaTime;
        transform.Translate(0, 0, velocity);
    }
    public void AimAtPlayer()
    {
        turretXaxis = turretRing.transform.rotation.x;
        turretRing.transform.LookAt(PlayerTank.transform.position);
       
    }

   

    
}
