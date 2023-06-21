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

    private void Awake()
    {
        //instance = this;
        //runner = GameObject.FindGameObjectsWithTag("Runner");
        //ig = FindObjectOfType<InGameRanking>();

        characterPositions.Add(Runners[0].transform.position);
        characterPositions.Add(Runners[1].transform.position);
        characterPositions.Add(Runners[2].transform.position);
        characterPositions.Add(Runners[3].transform.position);
        characterPositions.Add(Runners[4].transform.position);

        Time.timeScale = 0f;
    }


    private void Start()
    {
        //for (int i = 0; i < runner.Length; i++)
        //{
        //    sortArray.Add(runner[i].GetComponent<RankingSystem>());
        //}
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
        
    }


    void CalculateRanking()
    {
        //sortArray = sortArray.OrderBy(x => x.distance).ToList();

        //sortArray[0].rank = 1;
        //sortArray[1].rank = 2;
        //sortArray[2].rank = 3;
        //sortArray[3].rank = 4;
        //sortArray[4].rank = 5;

        //ig.a = sortArray[4].name;
        //ig.b = sortArray[3].name;
        //ig.c = sortArray[2].name;
        //ig.d = sortArray[1].name;
        //ig.e = sortArray[0].name;

        var sortedCharacters = Runners.OrderBy(character => Vector3.Distance(character.transform.position, target.position)).ToList();

        // Sýralama sonuçlarýný text nesnelerine yazdýr
        for (int i = 0; i < sortedCharacters.Count; i++)
        {    
            ScoreBoard[i].GetComponent<TextMeshProUGUI>().text = $"{i + 1}. {sortedCharacters[i].name}";
        }
    }
}
