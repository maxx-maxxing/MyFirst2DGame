using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreToGive;
    public float bobHeight;
    public float bobSpeed;
    
    private float startYPos;

    void Start()
    {
        startYPos = transform.position.y;
    }

    void Update()
    {
        float newYPos = startYPos + (Mathf.Sin(Time.time * bobSpeed) * bobHeight);
        transform.position = new Vector3(transform.position.x, newYPos, 0);
    }
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
