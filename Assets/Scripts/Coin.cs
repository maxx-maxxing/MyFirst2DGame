using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreToGive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().AddScore(scoreToGive);
            Debug.Log($"Score: {collision.GetComponent<PlayerController>().score}");
            Destroy(gameObject);
            
        }
    }
}
