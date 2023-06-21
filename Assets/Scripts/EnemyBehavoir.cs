
using UnityEngine;


public class EnemyBehavoir : MonoBehaviour
{
    //Movement Properties 
    [Header("Tank's Movement Properties")]
    [SerializeField] float forwardSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject tank;

    [SerializeField] private float timer;
    [SerializeField] private float timerBtwAction;



    //Rotating tank Properties 

    //Rotating turret Properties 
    [Header("Tank's turret properties")]
    [SerializeField] GameObject turretRing;
   
    //Barrel Properties 

    //Shell Properties 

    //Range to player
    [Header("Range to player Properties ")]
    [SerializeField] float maxFireRange;
    [SerializeField] float minProxiRange;
    [SerializeField] float maxProxiRange;
    private bool isNearPlayer;
    private bool isToFar;

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

        if (displacementToPlayer > maxProxiRange)
        {
            isToFar = true;
        }
        else
        {
            isToFar = false;
        }

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
        else if (isNearPlayer)
        {
            Repostion();
        }
        else if (isToFar is true)
        {
            MoveTowardsPlayer();
        }

    }
    public void Flee() //Flee - flee if the player gets to close 

    {
        Vector3 playerPos = PlayerTank.transform.position;
        Vector3 tankPos = tank.transform.position;

        //if the player come close to the tank, it will want to point away from the player as it moves
        float velocity = forwardSpeed * Time.deltaTime;
        transform.Translate(0, 0, velocity);

        float rotationVelocity = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationVelocity, 0);
        
        
        
        
    }

    public void Repostion()  //repostion - if the tank is within range of the player but there is somthing in the line of fire
    {
        
        float velocity = forwardSpeed * Time.deltaTime;
        transform.Translate(0, 0, velocity);
        float roationVelocity = rotationSpeed * Time.deltaTime;
        
        
        
    }
    public void AimAtPlayer()
    {
        
        turretRing.transform.LookAt(PlayerTank.transform.position);
       
        
       
    }
    public void MoveTowardsPlayer()
    {
        Vector3 playerPos = PlayerTank.transform.position;
        Vector3 tankPos = tank.transform.position;

        
        float velocity = forwardSpeed * Time.deltaTime;
        transform.Translate(0, 0, velocity);

        float rotationVelocity = rotationSpeed * Time.deltaTime;
        transform.LookAt(playerPos);
    }

   

    
}
