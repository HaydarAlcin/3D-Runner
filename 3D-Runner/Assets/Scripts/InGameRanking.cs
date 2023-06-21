using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameRanking : MonoBehaviour
{
    public GameObject[] namesTxt;
    public string a, b, c, d, e;

    private void Update()
    {
        namesTxt[0].GetComponent<TextMeshProUGUI>().text = a;
        namesTxt[1].GetComponent<TextMeshProUGUI>().text = b;
        namesTxt[2].GetComponent<TextMeshProUGUI>().text = c;
        namesTxt[3].GetComponent<TextMeshProUGUI>().text = d;
        namesTxt[4].GetComponent<TextMeshProUGUI>().text = e;
    }
}
