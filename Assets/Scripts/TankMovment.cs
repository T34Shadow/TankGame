using System.Threading;
using UnityEngine;


public class TankMovment : MonoBehaviour
{
    //Tank movement

    [Header("TankMovement")]
    public float forwardSpeed;
    public float backwardsSpeed;
    [SerializeField] private Transform tankPos;
    [SerializeField] private float rotationSpeed;

    [Header("TurretMovement")]
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform elevationMentlet;
    float xRotation;
    float yRotation;
    [SerializeField] private GameObject turretRing;

    [Header("Barrel")]
    [SerializeField] private Transform barrelPivotPoint;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform shellSpawn;
    [SerializeField] private GameObject barrel;
    [SerializeField] private float elevationSpeed;
    [SerializeField] private float ZoomedElevationSpeed;
    [SerializeField] private float minEleHieght;
    [SerializeField] private float maxEleHieght;

    [Header("Carrma")]
    [SerializeField] private Transform ThiredPersomCamPos;
    [SerializeField] private Transform FirstPersomCamPos;
    [SerializeField] private Camera MainCam;

    [Header("Shell")]
    [SerializeField] private GameObject Shell;
    [SerializeField] private GameObject canister;
    [SerializeField] private Transform canisterSpwanPoint;
    [SerializeField] private float timer; 
    [SerializeField] private float timerBtwFire;
    [SerializeField] private bool canFire;
    [SerializeField] private GameObject cooldownLightGreen;
  


    // [Header("RayCastPos")]
    // [SerializeField] private Transform frontRight;
    // [SerializeField] private Transform frontLeft;
    // [SerializeField] private Transform backRight;
    // [SerializeField] private Transform backLeft;
    // [SerializeField] private float RayLength = 0.5f;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //Barrel cam

        if (Input.GetKey(KeyCode.Mouse1))
        {
            MainCam.transform.position = FirstPersomCamPos.transform.position;

            //elevationSpeed = ZoomedElevationSpeed;

        }
        else
        {

            MainCam.transform.position = ThiredPersomCamPos.transform.position;

        }

        //Tank Movement
        bool forwardMovement = Input.GetKey(KeyCode.W);
        bool backwardsMovement = Input.GetKey(KeyCode.S);



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


        //Turret Rotaion with mouse on cam

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


        if (barrelUp)
        {
            Debug.Log(barrelPivotPoint.localRotation.x);
            if (barrelPivotPoint.localRotation.x <= -maxEleHieght)
            {
                changeInRotation = 0;
            }

            barrelPivotPoint.Rotate(0, changeInRotation, 0);
        }

        if (barrelDown)
        {
            Debug.Log(barrelPivotPoint.localRotation.x);
            if (barrelPivotPoint.localRotation.x >= minEleHieght)
            {
                changeInRotation = 0;
            }

            barrelPivotPoint.Rotate(0, -changeInRotation, 0);
        }


        //Tank shooting on commnaned with tank cansister being ejeced out the top of the turrect cap.

        bool shoot = Input.GetKeyDown(KeyCode.Mouse0);

        //barrel cooldown

        if (!canFire)
        {
            timer += Time.deltaTime;
                if (timer > timerBtwFire)
            {
                canFire = true;
                timer = 0;

            }
        }
        if (shoot && canFire)
        {
            canFire = false;
            //shell spwan
            GameObject CloneShell = Instantiate(Shell, shellSpawn.position, elevationMentlet.transform.rotation) as GameObject;

            //canister spwan

            GameObject CloneCnaister = Instantiate(canister, canisterSpwanPoint.position, elevationMentlet.transform.rotation) as GameObject;
        }
        if (!canFire)
        {
            cooldownLightGreen.SetActive(false);
            
        }
        if (canFire)
        {
            cooldownLightGreen.SetActive(true);
        }
       // if (shoot)
       // {
       //     //barrel recoil
       //
       //     barrel.transform.Translate(0, 0, -1);
       //
       //     barrel.transform.Translate(0, 0, +1);
       //
       // }
        


    }

}













