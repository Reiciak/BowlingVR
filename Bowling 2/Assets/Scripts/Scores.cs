using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveScore(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/" + round + "/Throw1"  + "/Throw1").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }

    public void saveScore1(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/" + round + "/Throw2" + "/Throw2").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }
    public void saveScoreTotal(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/" + round + "/TotalScore").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }
    public void saveScoreTotal1(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/" + round + "/TotalScore").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }
    public void saveScore2(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/" + round + "/Throw1" + "/Throw1").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }

    public void saveScore3(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/" + round + "/Throw2" + "/Throw2").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }
    public void saveScoreTotalPoints1(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/Score").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }
    public void saveScoreTotalPoints2(int player, int throwNumber, int round, int point)
    {
        gameObject.transform.Find("Canvas/Player " + player + "/P" + player + "/Score1").GetComponent<TextMeshProUGUI>().SetText(point.ToString());
    }

}
