using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using Cinemachine;

public class PlayerMotion : MonoBehaviour {

    
    private Transform myTransform;
    private CharacterController character;
    private GameObject cam;
    private Vector3 direction;
    private float targetAngle;
    public float speed = 5;
    public float turnSmoothing = 0.1f;
    private float turnSmoothRef;
    private Rigidbody rigidBody;




    


    private void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
        myTransform = gameObject.transform;
        character = GetComponent<CharacterController>();
        cam = Camera.main.gameObject;

    }
    private void FixedUpdate()
    {
        Move();

    }
    private void Move()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical).normalized;
        targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (direction.magnitude >= .1f)
        {
            float target = targetAngle + cam.transform.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target, ref turnSmoothRef, turnSmoothing);
            
            transform.rotation = Quaternion.Euler(0, angle, 0);
            myTransform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
       
          
       
        
        
        

    }

    
   


   


    

    

   


}
