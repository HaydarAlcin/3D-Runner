using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;
    public Transform StartPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            
            AddCoin();
            //Destroy(other.gameObject);
            other.transform.parent.gameObject.SetActive(false);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = StartPosition.position;
        }
    }
    public void AddCoin()
    {
        score++;

        CoinText.text = "Score: " + score.ToString();
    }
}
