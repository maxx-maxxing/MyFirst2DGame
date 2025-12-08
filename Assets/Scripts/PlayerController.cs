using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    
    private bool isGrounded;

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rig.linearVelocity = new Vector2(moveInput * moveSpeed, rig.linearVelocity.y);

        if (rig.linearVelocity.x > 0)
        {
            sr.flipX = true;
        }
        else if (rig.linearVelocity.x < 0)
        {
            sr.flipX = false;
        } 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (rig.transform.position.y < -5)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        if (normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
