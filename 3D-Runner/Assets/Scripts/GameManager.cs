using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_InputField inputPlayerName;
    public TMP_Text Player;

    private void Awake()
    {
        Time.timeScale = 0f;
    }


    public void StartButton()
    {
        Time.timeScale = 1f;
        Player.GetComponent<TextMeshPro>().text = inputPlayerName.text;

        
        inputPlayerName.gameObject.SetActive(false);
        
    }
}
