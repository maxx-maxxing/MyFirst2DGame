using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;
    public float jumpForce;
    public SpriteRenderer sr;
    public static int score;
    public TextMeshProUGUI scoreText;
    
    private bool isGrounded;

    void Start ()
    {
        scoreText.text = "Score: " + score;
    }
    
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

    private void OnCollisionEnter2D (Collision2D collision)
    {
        // OLD: if(collision.GetContact(0) == Vector2.up)
        if(Vector2.Dot(collision.GetContact(0).normal, Vector2.up) > 0.8f)
        {
            isGrounded = true;
        }
    }

    public void GameOver()
    {
        ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score: {score}";
    }

    public void ResetScore()
    {
        score = 0;
    }

    
}
