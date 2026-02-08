using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;

    private bool isJumping;
    private bool estSol;
    public Transform GroundCheckLeft;
    public Transform GroundCheckRight;

    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        estSol = Physics2D.OverlapArea(GroundCheckLeft.position, GroundCheckRight.position);
        float MouvementHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && estSol)
        {
            isJumping = true;
        }

        movePlayer(MouvementHorizontal);

        Flip(rb.linearVelocity.x);

        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void movePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f){
            spriteRenderer.flipX = true;
        }
    }
}
