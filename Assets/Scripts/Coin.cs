using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreToGive++;
            collision.GetComponent<PlayerController>().AddScore(scoreToGive);
            Destroy(gameObject);
            
        }
    }
}
