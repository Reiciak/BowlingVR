using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class RespawnBowlingPin : MonoBehaviour
{
    //private bool throwes = false;
    //private int number = 0;
    //private Dictionary<int, Dictionary<int, int>> Throwes = new Dictionary<int, Dictionary<int, int>>();
    //private Dictionary<int, int> Score = new Dictionary<int, int>();
    //private Dictionary<int, int> Totalpoints = new Dictionary<int, int>();
    //private int numberOfThrowes = 0;
    //private bool isStrike = false;
    //private static int throwesInRound = 2;
    //private int a = 0;

    //public Respawn respawn;
    //private bool throwes = true; 
    //private bool isStrike = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("bowling"))
    //    {
    //        if (throwes)
    //        {
    //            Debug.Log("rzut 1");
    //            FirstThrow();
    //            if (isStrike)
    //            {
    //                //numberOfThrowes++;
    //                Debug.Log($"ile {numberOfThrowes}   ");
    //            }
    //        }
    //        else
    //        {
    //            if (!isStrike)
    //            {
    //                Debug.Log("rzut 2");
    //                SecondThrow();
    //            }
    //        }
    //    }
    //}

    //public void FirstThrow()
    //{
    //    if (!Score.ContainsKey(1))
    //    {
    //        Score.Add(1, 0);
    //    }
    //    var points = Score.GetValueOrDefault(1) + 1;
    //    Score.Remove(1);
    //    Score.Add(1, points);
    //    Debug.Log(points);
    //    if (points == 11)
    //    {
    //        Debug.Log("STRIKE");
    //        isStrike = true;
    //    }
    //}
    //public void SecondThrow()
    //{
    //    if (!Score.ContainsKey(2))
    //    {
    //        Score.Add(2, 0);
    //    }
    //    var points = Score.GetValueOrDefault(2) + 1;
    //    Score.Remove(2);
    //    Score.Add(2, points);
    //    Debug.Log(points);
    //    if (Score[1] + Score[2] == 12)
    //    {
    //        Debug.Log("SPARE");
    //    }
    //}

    //public void CountPoints()
    //{
    //    Debug.Log($"LICZY {numberOfThrowes}   ");
    //    if (numberOfThrowes == throwesInRound)
    //    {
    //        Debug.Log(".");
    //        CountingPoints();
    //    }
    //}

    //public void CountingPoints()
    //{
    //    Debug.Log($"Round Number is {number}");
    //    //if (Throwes[number][1] >= 2) { };
    //    if (Throwes[number - 1][1] == 11)
    //    {
    //        Strike();
    //    }
    //    else if (Throwes[number - 1][1] + Throwes[number - 1][2] == 12)
    //    {
    //        Spare();
    //    }
    //    var score = Score.Sum(x => x.Value) - 2; //-2 odjêcie punktów za kule
    //    Totalpoints.Remove(number);
    //    Totalpoints.Add(number, score);
    //    Debug.Log($"points: {Totalpoints[number]}");
    //}

    //public void Strike()
    //{
    //    Debug.Log("tfuStrike");
    //    var score = 20 + Score.Sum(x => x.Value) - 1;
    //    Totalpoints.Remove(number);
    //    Totalpoints.Add(number, score);
    //}

    //public void Spare()
    //{
    //    Debug.Log("tfuSpare");
    //    var score = 10 + Score[1] - 2;
    //    Totalpoints.Remove(number - 1);
    //    Totalpoints.Add(number - 1, score);
    //}
}
