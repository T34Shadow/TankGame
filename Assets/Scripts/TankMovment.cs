
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
    float xRotation;
    float yRotation;
    public Transform turretRing; 



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

        Vector3 pos = transform.position;

        //oldMovement
        {

            // float desiredSpeed = Movement * speed;
            //
            //
            // float actualSpeed = vel.z;
            //
            // float desiredChangeSpeed = desiredSpeed - actualSpeed;
            // float desiredAcc = desiredChangeSpeed / Time.deltaTime;
            //
            // float actualAcc;
            //
            // actualAcc = Mathf.Clamp(desiredAcc, -maxGroundForce, maxGroundForce);
            // acc.z = actualAcc;
        }
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

        



    }

       
       
        

        

        //GameObject turretRing = GameObject.Find("turretRing");
        ////Turret Rotaion with cam
        //// get mouse input 
        //float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        //    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        //
        //    yRotation += mouseX;
        //    xRotation -= mouseY;
        //
        //// rotate cam and orientaion
        //turretRing.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //    orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        
    


}

