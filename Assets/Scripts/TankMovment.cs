
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;


public class TankMovment : MonoBehaviour
{
    //Tank movement

    [Header("TankMovement")]
    public float speed;
    public float maxGroundForce;
    public Transform tankPos;
    public float rotationSpeed;
    [Header("TurretMovement")]
    public float sensX;
    public float sensY;
    public Transform orientation;
    public Transform elevationMentlet;
    float xRotation;
    float yRotation;
    public GameObject turretRing;
    [Header("Barrel")]
    public Transform barrelPivotPoint;
    public Transform barrelLocation;
    public Transform shellSpawn;
    public float elevationSpeed;
    public float minEleHieght;
    public float maxEleHieght;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Tank Movement
        float Movement = Input.GetAxis("Vertical");
        
        

        
        // New movement

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

        
        //barrel location reletive to turretRing

        Vector3 BarrelPos = new Vector3(barrelLocation.position.x, barrelLocation.position.y, barrelLocation.position.z);
        barrelPivotPoint.position = BarrelPos;


        barrelPivotPoint.transform.rotation = orientation.transform.rotation;//while this line of code is running, it does not allow for change in elevation on the barrel, however it allows for barrel location to be updated to the turrets location.

        


        //Barrel cam

       // if (Input.GetKey(KeyCode.Mouse1))
       // {
       //     
       // }

        //Barrel elevation with shift & ctrl
        //get input
        bool barrelUp = Input.GetKey(KeyCode.LeftShift);
        bool barrelDown = Input.GetKey(KeyCode.LeftControl);


        float changeInRotation = elevationSpeed;
        

        if (barrelUp) 
        {
            
            if(barrelPivotPoint.localRotation.x <= -maxEleHieght)
            {
                changeInRotation = 0;
            }

            barrelPivotPoint.Rotate(-changeInRotation, 0, 0);
        }

        if (barrelDown)
        {
            if (barrelPivotPoint.localRotation.x >= minEleHieght)
            {
                changeInRotation = 0;
            }

            barrelPivotPoint.Rotate(changeInRotation, 0, 0);
        }


        
    }











}

