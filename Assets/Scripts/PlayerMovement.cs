using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpForce;
    private Rigidbody2D MyRigidBody;
    public bool OnGround;
    public LayerMask GroundLayer;
    //private Collider2D MyCollider;
    private Animator MyAnimator;
    public float MaxJumpTime;
    private float JumpTimeCounter;
    public float SpeedMultiplier;
    public float SpeedChangeInterval;
    private float SpeedChangeIntervalCount;
    public Transform Toes;
    public float ToeThiccness;
    public GameManager TheGameManager;
    private float MoveSpeedStore;
    private float SpeedChangeIntervalCountStore;
    public float SpeedChangeIntervalStore;
    

    void Start()
    {
        MyRigidBody = GetComponent<Rigidbody2D>();
        //MyCollider = GetComponent<Collider2D>();
        MyAnimator = GetComponent<Animator>();
        JumpTimeCounter = MaxJumpTime;
        SpeedChangeIntervalCount = SpeedChangeInterval;
        MoveSpeedStore = MovementSpeed;
        SpeedChangeIntervalCountStore = SpeedChangeIntervalCount;
        SpeedChangeIntervalStore = SpeedChangeInterval;
    }

    void Update()
    {
        MyRigidBody.velocity = new Vector2(MovementSpeed, MyRigidBody.velocity.y);
        //OnGround = Physics2D.IsTouchingLayers(MyCollider, GroundLayer);
        OnGround = Physics2D.OverlapCircle(Toes.position, ToeThiccness, GroundLayer);
        if(transform.position.x > SpeedChangeIntervalCount)
        {
            SpeedChangeIntervalCount += SpeedChangeInterval;
            SpeedChangeInterval = SpeedChangeInterval * SpeedMultiplier;
            MovementSpeed = MovementSpeed * SpeedMultiplier;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.UpArrow)) && OnGround)
        {
            MyRigidBody.velocity = new Vector2(MyRigidBody.velocity.x, JumpForce);
            
           
        }
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow))
        {
            if(JumpTimeCounter > 0)
            {
                MyRigidBody.velocity = new Vector2(MyRigidBody.velocity.x, JumpForce);
                JumpTimeCounter -= Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            JumpTimeCounter = 0;
        }
        if (OnGround)
        {
            JumpTimeCounter = MaxJumpTime;
        }
        MyAnimator.SetFloat("Speed", MyRigidBody.velocity.x);
        MyAnimator.SetBool("OnGround", OnGround);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "DIE")
        {
            TheGameManager.RestartGame();
            MovementSpeed = MoveSpeedStore;
            SpeedChangeIntervalCount = SpeedChangeIntervalCountStore;
            SpeedChangeInterval = SpeedChangeIntervalStore;

        }
    }
}
