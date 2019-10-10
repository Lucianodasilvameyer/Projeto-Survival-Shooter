using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq; // algumas funcções adicionais
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float jumpHeight = 5f;
    
    public int nivelCasa = 0;

    public int hp = 10;

    public float walkSpeed = 3f;
    public float runSpeed = 8f;
    public float gravity = -12f;

    public float timer;
    public float timerMax = 5;

    [SerializeField]
    float velocityY;

    //[SerializeField]
    //Machado machado;

    [SerializeField]
    bool running = false;

    [SerializeField]
    bool atacando = false;
    [SerializeField]
    bool isOnCooldown = false;



    //[SerializeField]
    //Game game_ref;
  

    float smoothRotationVelocity;
    [SerializeField]
    float smoothRotationTime = 0.2f;

    float smoothSpeedVelocity;
    [SerializeField]
    float smoothSpeedTime = 0.2f;

    [SerializeField]
    Transform cameraT;

    [SerializeField]
    CharacterController charController;

    [SerializeField]
    Animator animator;

    int nivelInimigo = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        andar();
        Jump();
    }
    public void andar()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector2 inputDir = input.normalized;

        float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;

        if (inputDir != Vector2.zero)
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref smoothRotationVelocity, smoothRotationTime);

        running = (Input.GetKey(KeyCode.LeftShift));

        float targetSpeed = (running) ? runSpeed : walkSpeed * inputDir.magnitude;

        speed = Mathf.SmoothDamp(speed, targetSpeed, ref smoothSpeedVelocity, smoothSpeedTime);

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = transform.forward * speed * inputDir.magnitude + Vector3.up * velocityY; ;

        charController.Move(velocity * Time.deltaTime);

        speed = new Vector2(charController.velocity.x, charController.velocity.z).magnitude;

        if (charController.isGrounded)
        {
            velocityY = 0;
        }

    }
    public void Jump()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {


         if (charController.isGrounded)
         {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Animations"))
            {
                  animator.Play("Jump up");
            }
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
         }

      }

        
    }

}
