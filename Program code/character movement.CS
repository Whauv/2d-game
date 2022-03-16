using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed =1;
    public float JumpForce = 1;
    // [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    // private float JumpTimeCounter;
    // public float JumpTime;
    // private bool isJumping;
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
            // isJumping = true;
            
            // JumpTimeCounter = JumpTime;
            
             body.velocity = Vector2.up * JumpForce;

        }
        /*if (Input.GetKey(KeyCode.Space) && isJumping == true)

        {
            if (JumpTimeCounter > 0)
            {
                body.velocity = Vector2.up * JumpForce;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }           
        }
         if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        /*float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);    

        if(horizontalInput > 0.01f)
            transform.localScale=Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale= new Vector3(-0.7525256f,0.8287119f,1)*/

        /*if (Input.GetButtonDown("Jump") && Mathf.Abs(body.velocity.y) <0.001f)
            {
                Jump();
            }*/
        anim.SetBool("Run", movement !=0);
        anim.SetBool("OnGround", grounded);   
    }
    

/*private void Jump()
{
    body.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    anim.SetTrigger("jump");
    grounded=false;
}*/
private void OnCollisionEnter2D(Collision2D col)
{
    if(Mathf.Abs(body.velocity.y) <0.001f)
    {    
        grounded = true;
    }
}
}