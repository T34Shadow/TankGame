using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


public class TankMovment : MonoBehaviour
{
    //Tank movement

    [Header("TankMovement")]
    [SerializeField] private float speed;
    [SerializeField] private float maxGroundForce;
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
        float Movement = Input.GetAxis("Vertical");

        float desSpeed = Movement * speed * Time.deltaTime;

        transform.Translate(0f, 0f, desSpeed);


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
        

        if (shoot)
        {
            //shell spwan
            GameObject CloneShell = Instantiate(Shell, shellSpawn.position, elevationMentlet.transform.rotation) as GameObject;

            //canister spwan

            GameObject CloneCnaister = Instantiate(canister, canisterSpwanPoint.position, elevationMentlet.transform.rotation) as GameObject;
        }
        if (shoot)
        {
            //barrel recoil

            barrel.transform.Translate(0, 0, -1);
            
            barrel.transform.Translate(0, 0, +1);
                
            
            

        }
    }











}

