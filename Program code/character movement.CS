using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed =1;
    public float JumpForce = 1;
   
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
  
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;



    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        var movement = Input.GetAxis("Horizontal");
        transform.position +=new Vector3(movement,0,0) * Time.deltaTime*MovementSpeed;
        if(!Mathf.Approximately(0,movement))
            transform.rotation=movement < 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
        if(isGrounded==true && Input.GetKeyDown("space"))
        {
          
            
             body.velocity = Vector2.up * JumpForce;

        }
        
        anim.SetBool("Run", movement !=0);
        anim.SetBool("OnGround", grounded);   
    }
    


private void OnCollisionEnter2D()
{
    if(Mathf.Abs(body.velocity.y) <0.01f)
    {    
        grounded = true;
    }
}
}
