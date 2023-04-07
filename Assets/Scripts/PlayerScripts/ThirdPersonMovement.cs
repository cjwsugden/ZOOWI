using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System.Collections;

public class ThirdPersonMovement : MonoBehaviour
{

    public Animator anim;
    public CharacterController controller;
    public Transform cam;

    public int speed = 3;
    public int walkspeed = 3;
    public int runspeed = 8;
    public float gravity = -9.81f;
    public float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;



    void Start(){
        
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        speed = 3;
    }

    
    // Update is called once per frame
    void Update()
    {

        

        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


         if (Input.GetKeyDown(KeyCode.LeftShift)) {

            speed = runspeed;
        }
        
        else if (Input.GetKeyUp(KeyCode.LeftShift)) {

            speed = 3;

            }

        
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)  )
        {
            //isWalking = true;
            //anim.SetAnimatorString(1);
            //anim.SetTrigger("Cat_Walk");
            if(speed == runspeed){
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdling", false);
            anim.SetBool("isWalking",false);
            }
            else{
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdling", false);
            }
        }


        else{
            
                anim.SetBool("isRunning", false);
                 anim.SetBool("isIdling", true);
                 anim.SetBool("isWalking",false);
            
            
            //isIdling = true;
            //anim.SetAnimatorString(0);
            //anim.SetTrigger("Cat_Walk");
            
        }


    }

    
}