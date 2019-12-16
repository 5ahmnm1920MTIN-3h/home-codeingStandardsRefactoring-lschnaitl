using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float jumpForce;
    private const string JUMP_TRIGGER_NAME = "Jump";
    private const string DEATH_STATE_NAME = "SantaDeath";
    private const string GROUND_TAG = "Ground";
    private const string OBSTACLE_TAG = "Obstacle";

    private bool grounded;
    private bool gameOver;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver && !gameOver && !gameOver)
        {
            if (grounded == true)
            {
                jump();
            }
        }
    }


    private void jump()
    {
        grounded = false;

        rb.velocity = Vector2.up * jumpForce;

        anim.SetTrigger(JUMP_TRIGGER_NAME);

        GameManager.instance.IncrementScore();
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        if(collision.gameObject.tag == GROUND_TAG)
        {
            grounded = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == OBSTACLE_TAG){
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            anim.Play(DEATH_STATE_NAME);
            gameOver = SetGameOverTrue();
        }
    }
}