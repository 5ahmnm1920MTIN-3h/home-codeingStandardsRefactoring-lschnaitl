using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float OFFSET = 15f;
    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //if obstacle's position x is < -15f it will be destroyed
        if(transform.position.x < -OFFSET)
        {
            Destroy(gameObject);
        }
        
        //if obstacle's position x is < -15f it will be destroyed
        if (transform.position.x > OFFSET)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // add the movement speed to the rigidbodys velocity in the correct direction
        rb.velocity = Vector2.left * moveSpeed;
    }
}
