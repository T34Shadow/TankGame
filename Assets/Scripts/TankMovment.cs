using UnityEngine;


public class TankMovment : MonoBehaviour
{

    //Tank movement Properties  
    [Header("TankMovement")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardsSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform tankPos;

    //Turret Properties 
    [Header("TurretMovement")]
    private float xRotation;
    private float yRotation;
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform elevationMentlet;
    [SerializeField] private GameObject turretRing;


    //Barrel Properties 
    [Header("Barrel")]
    [SerializeField] private float elevationSpeed;
    [SerializeField] private float ZoomedElevationSpeed;
    [SerializeField] private float minEleHieght;
    [SerializeField] private float maxEleHieght;
    [SerializeField] private Transform barrelPivotPoint;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform shellSpawn;
    [SerializeField] private GameObject barrel;

    //Camear Properties 
    [Header("Camera")]
    [SerializeField] private Transform ThiredPersomCamPos;
    [SerializeField] private Transform FirstPersomCamPos;
    [SerializeField] private Camera MainCam;

    //Shell Properties 
    [Header("Shell")]
    [SerializeField] private float timer;
    [SerializeField] private float timerBtwFire;
    [SerializeField] private bool canFire;
    [SerializeField] private GameObject Shell;
    [SerializeField] private GameObject canister;
    [SerializeField] private Transform canisterSpwanPoint;
    [SerializeField] private GameObject cooldownLightGreen;

    // Start is called before the first frame update
    void Start()
    {
        //This locks and hides the cursor to the centur of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Zooming in and changining camear pos

        if (Input.GetKey(KeyCode.Mouse1))
        {
            MainCam.transform.position = FirstPersomCamPos.transform.position;
        }
        else
        {

            MainCam.transform.position = ThiredPersomCamPos.transform.position;
        }

        //Tank Movement
        ////Get input
        bool forwardMovement = Input.GetKey(KeyCode.W);
        bool backwardsMovement = Input.GetKey(KeyCode.S);

        //declearining what the speed should be by a change in time, and then applyining that to the tanks pos
        if (forwardMovement)
        {
            Vector3 desFwdSpeed = new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            transform.Translate(desFwdSpeed);
        }
        if (backwardsMovement)
        {
            Vector3 desBwdSpeed = new Vector3(0, 0, -backwardsSpeed * Time.deltaTime);
            transform.Translate(desBwdSpeed);
        }


        //Tank rotation

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed * Time.deltaTime, 0f);
        }


        //Turret Rotaion with mouse on camear

        // get mouse input 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // rotate cam and orientaion
        turretRing.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);


        //Barrel elevation with shift & ctrl
        //get input
        bool barrelUp = Input.GetKey(KeyCode.LeftShift);
        bool barrelDown = Input.GetKey(KeyCode.LeftControl);
        float changeInRotation = elevationSpeed;


        if (barrelUp) // allowing the tank's barrel to be rotated upwards 
        {
            //Debug.Log(barrelPivotPoint.localRotation.x);
            if (barrelPivotPoint.localRotation.x <= -maxEleHieght) // stopping the roation at a max hight 
            {
                changeInRotation = 0;
            }

            barrelPivotPoint.Rotate(0, changeInRotation, 0);
        }

        if (barrelDown) // allowimg the tank's barrel to be rotated downwards
        {
            //Debug.Log(barrelPivotPoint.localRotation.x);
            if (barrelPivotPoint.localRotation.x >= minEleHieght) // stopping the roation at a min light
            {
                changeInRotation = 0;
            }

            barrelPivotPoint.Rotate(0, -changeInRotation, 0);
        }


        //Tank shooting on commnaned with tank cansister being ejeced out the top of the turrect cap.

        bool shoot = Input.GetKeyDown(KeyCode.Mouse0);

        //barrel reload

        if (!canFire)//starting timer if can not fire 
        {
            timer += Time.deltaTime;
            if (timer > timerBtwFire) // as soon as the timer gets to 0 canFire becomes true 
            {
                canFire = true;
                timer = 0;

            }
        }
        if (shoot && canFire) // only allowing the player to shoot when both are true
        {
            canFire = false;
            //shell spwan/cloneing 
            GameObject CloneShell = Instantiate(Shell, shellSpawn.position, elevationMentlet.transform.rotation) as GameObject;

            //canister spwan/cloneing 
            GameObject CloneCnaister = Instantiate(canister, canisterSpwanPoint.position, elevationMentlet.transform.rotation) as GameObject;
        }
        if (!canFire) // changing a game object's active in world space 
        {
            cooldownLightGreen.SetActive(false);

        }
        if (canFire)
        {
            cooldownLightGreen.SetActive(true);
        }

    }

}