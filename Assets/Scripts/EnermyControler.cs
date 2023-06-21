using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnermyControler : MonoBehaviour
{
    [Header("PlayerProperties")]
    [SerializeField] private GameObject playerTank;

    [Header("Range to player Properties ")]
    [SerializeField] private float minDisToPlayer;
    [SerializeField] private float maxDisToPlayer;
    [SerializeField] private bool isNearPlayer;
    [SerializeField] private bool isToFar;

    [Header("Tank's Movement Properties")]
    [SerializeField] float forwardSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] float rotationSpeed;

    [Header("Tank's turret Properties")]
    [SerializeField] float turretSpeed;
    [SerializeField] float angleOfRotation;
        [SerializeField] private GameObject turretRing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = playerTank.transform.position;
        Vector3 tankPos = transform.position;

        float displacementToPlayer = Vector3.Distance(tankPos, playerPos);
        
        if (displacementToPlayer > maxDisToPlayer)
        {
            isToFar = true;
        }
        else
        {
            isToFar = false;
        }

        if (displacementToPlayer < minDisToPlayer)
        {
            isNearPlayer = true;
            
        }
        else
        {
            isNearPlayer = false;
            //float velcoity = forwardSpeed * Time.deltaTime;
            //transform.Translate(0, 0, velcoity);
        }
        
        TankMovement();
        
    }
    public void TankMovement()
    {
     if (isToFar is true)
        {
            MoveTowards();
            
        }
     else
        {
            HoldPostion();

        }
       
    }
    public void Retreat()
    {
        MoveAway();
    }
    public void Repostion()
    {
        
        
    }
    public void MoveTowards()
    {
        Vector3 playerPos = playerTank.transform.position;
        Vector3 tankPos = transform.position;

        float velcoity = forwardSpeed * Time.deltaTime;

        transform.LookAt(playerPos);
        transform.rotation.x.IsUnityNull();
                
       
        Vector3 move = Vector3.forward * velcoity;
        transform.Translate(move);
        
    }
    
    public void MoveAway()
    {
       
    }
    public void HoldPostion()
    {
        transform.Translate(0, 0, 0);

        
    }

    public void Circle()
    {
              
    }
    public void AimAtPlayer()
    {

    }
   
}
