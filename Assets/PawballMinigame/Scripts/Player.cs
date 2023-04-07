using UnityEngine;


public class Player : MonoBehaviour
{
public float speed;
    public float rotationSpeed;
    public Animator anim;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, -verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);            
        }


        if(Input.GetKey(KeyCode.W) ||  (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)) ){
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdling",false);
         } 
         else{
            anim.SetBool("isRunning", false);
             anim.SetBool("isIdling" , true);
         }
    }

         

    



    
}
