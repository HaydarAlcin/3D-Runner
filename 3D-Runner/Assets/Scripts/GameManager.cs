using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //public static GameManager instance;
    ////public InGameRanking ig;

    //private GameObject[] runner;
    //List<RankingSystem> sortArray = new List<RankingSystem>();

    public List<Vector3> characterPositions = new List<Vector3>();
    public GameObject[] Runners,ScoreBoard;
    public Transform target;

    public TMP_InputField inputPlayerName;
    public TMP_Text Player;
    public Button StartBtn;

    public List<GameObject> sortedCharacters = new List<GameObject>();

    public PlayerController pc;

    public bool raceOver;

    private void Awake()
    {

        characterPositions.Add(Runners[0].transform.position);
        characterPositions.Add(Runners[1].transform.position);
        characterPositions.Add(Runners[2].transform.position);
        characterPositions.Add(Runners[3].transform.position);
        characterPositions.Add(Runners[4].transform.position);

        Time.timeScale = 0f;
    }

    private void Update()
    {
        CalculateRanking();
    }

    public void StartButton()
    {
        Time.timeScale = 1f;
        Player.GetComponent<TextMeshPro>().text = inputPlayerName.text;

        
        inputPlayerName.gameObject.SetActive(false);
        StartBtn.gameObject.SetActive(false);
        
    }


    public void CalculateRanking()
    {

        if (raceOver==false)
        {
            sortedCharacters = Runners.OrderBy(character => Vector3.Distance(character.transform.position, target.position)).ToList();

            // Sýralama sonuçlarýný text nesnelerine yazdýr
            for (int i = 0; i < sortedCharacters.Count; i++)
            {
                ScoreBoard[i].GetComponent<TextMeshProUGUI>().text = sortedCharacters[i].name;
            }

            
        }
    }

    public void RaceOver()
    {
        raceOver = true;
    }
}
