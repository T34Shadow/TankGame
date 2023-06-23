using Unity.VisualScripting;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    [Header("PlayerProperties")]
    [SerializeField] private GameObject playerTank;

    [Header("Range to player Properties ")]
    [SerializeField] private float minDisToPlayer;
    [SerializeField] private float maxDisToPlayer;
    [SerializeField] private bool isNearPlayer;
    [SerializeField] private bool isTooFar;

    [Header("Tank's Movement Properties")]
    [SerializeField] float forwardSpeed;
    [SerializeField] float backwardsSpeed;
    [SerializeField] float rotationSpeed;

    [Header("Tank's turret Properties")]
    [SerializeField] float turretSpeed;
    [SerializeField] float angleOfRotation;
    [SerializeField] private GameObject turretRing;
    [SerializeField] private Transform elevationMentlet;

    [Header("Shell")]
    [SerializeField] private float timer;
    [SerializeField] private float timerBtwFire;
    [SerializeField] private bool canFire;
    [SerializeField] private GameObject Shell;
    [SerializeField] private Transform shellSpawn;

    // Update is called once per frame
    void Update()
    {

        Vector3 playerPos = playerTank.transform.position;
        Vector3 tankPos = transform.position;

        //Calculating the displacement to and from the player so then we can use it to ckeck for how close the player is to the enermy tank
        float displacementToPlayer = Vector3.Distance(tankPos, playerPos);


        //if the displacement to the player is to far away the tank will want to close the discance 
        //if the displacement to the player is to close it will then want to move further away from the player
        //if non of this is true then the tank will hold it's current postion and aim, shoot and always hit the player
        //isTooFar = displacementToPlayer > maxDisToPlayer; //THIS IS THE SAME - Finn
        if (displacementToPlayer > maxDisToPlayer)
        {
            isTooFar = true;
        
        }
        else
        {
            isTooFar = false;
        }

        if (displacementToPlayer < minDisToPlayer)
        {
            isNearPlayer = true;
            MoveAway();
        }
        else
        {
            isNearPlayer = false;
        }
        //isNearPlayer = displacementToPlayer < minDisToPlayer;
        //if (isNearPlayer) Retreat();

        UpdateMovement();

    }
    public void UpdateMovement()
    {
        if (isTooFar)
        {
            MoveTowards(); // this is when the player is to far away

        }
        else
        {
            HoldPostion(); // the player is both not far way and to close 
        }

    }

    //setting all the function.

    public void MoveTowards()
    {
        //The whole use of the the MoveTowards function is to have the tank rotate towards the player and then move in that direction
        Vector3 playerPos = playerTank.transform.position;
        float velcoity = forwardSpeed * Time.deltaTime;

        transform.LookAt(playerPos);
        transform.rotation.x.IsUnityNull();

        Vector3 move = Vector3.forward * velcoity;
        transform.Translate(move);

    }

    public void MoveAway()
    {
        //The whole use of the the MoveAway function is to have the tank rotate towards the player and then move in the other direction
        Vector3 playerPos = playerTank.transform.position;
        float velcoity = backwardsSpeed * Time.deltaTime;

        transform.LookAt(playerPos);
        transform.rotation.x.IsUnityNull(); //Did you mean to get this as Euler angles and check if the X axis rotation is zero? -Finn

        Vector3 move = Vector3.back * velcoity;
        transform.Translate(move);
    }
    public void HoldPostion()
    {
        //while holding the tanks postion, allow it to shoot at the player
        transform.Translate(0, 0, 0);
        ShootAtPlayer();
    }

    public void ShootAtPlayer()
    {
        Vector3 playerPos = playerTank.transform.position;
        turretRing.transform.LookAt(playerPos);

        if (!canFire)//starting timer if cannot fire 
        {
            timer += Time.deltaTime;
            if (timer > timerBtwFire) // as soon as the timer gets to 0 canFire becomes true 
            {
                canFire = true;
                timer = 0;

            }
        }
        if (!isNearPlayer && !isTooFar && canFire) // only allowing the tank to shoot when all conditions are met
        {
            canFire = false;
            //Instantatining the shell, while setting its spawn position then its direction, once spawned in, the shell script takes care of the rest
            GameObject CloneShell = Instantiate(Shell, shellSpawn.position, elevationMentlet.transform.rotation) as GameObject;
        }

    }
}
