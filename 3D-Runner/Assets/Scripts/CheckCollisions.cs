using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            
            AddCoin();
            //Destroy(other.gameObject);
            other.transform.parent.gameObject.SetActive(false);
        }
    }


    public void AddCoin()
    {
        score++;

        CoinText.text = "Score: " + score.ToString();
    }
}
