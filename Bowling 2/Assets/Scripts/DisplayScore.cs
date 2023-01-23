using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayScore : MonoBehaviour
{
    public Respawn respawn;

    public void displayPoints()
    {
        if (respawn.player == 1)
        {
            if (respawn.Throwes[respawn.numberOfRound][1] == 10)
            {
                FindObjectOfType<Scores>().saveScore(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][1]);
                if (respawn.numberOfRound == 19)
                {
                    FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, 10);
                    if (respawn.Throwes[respawn.numberOfRound - 2][1] == 10)
                    {
                        FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, 20);
                    }
                }
            } 
            else if(respawn.Throwes[respawn.numberOfRound][1] + respawn.Throwes[respawn.numberOfRound][2] == 10)
            {
                FindObjectOfType<Scores>().saveScore(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][1]);
                FindObjectOfType<Scores>().saveScore1(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][2]);
            }
            else
            {
                FindObjectOfType<Scores>().saveScore(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][1]);
                FindObjectOfType<Scores>().saveScore1(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][2]);
                FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Totalpoints[respawn.numberOfRound]);
            }

            if (respawn.numberOfRound >= 3)
            {
                if (respawn.Throwes[respawn.numberOfRound - 2][1] + respawn.Throwes[respawn.numberOfRound - 2][2] == 10 && respawn.Throwes[respawn.numberOfRound][1] != 10)
                {
                    FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, respawn.Totalpoints[respawn.numberOfRound - 2]);
                }
                if (respawn.Throwes[respawn.numberOfRound - 2][1] == 10)
                {
                    FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, respawn.Totalpoints[respawn.numberOfRound - 2]);
                }
            }
            if (respawn.numberOfRound >= 3)
            {
                if (respawn.numberOfRound >= 5)
                {
                    if (respawn.Throwes[respawn.numberOfRound - 4][1] == 10 && respawn.Throwes[respawn.numberOfRound - 2][1] == 10)
                    {
                        FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 4, respawn.Totalpoints[respawn.numberOfRound - 4]);
                    }
                }
                if (respawn.Throwes[respawn.numberOfRound - 2][1] == 10 && respawn.Throwes[respawn.numberOfRound - 2][1] == 10)
                {
                    FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, respawn.Totalpoints[respawn.numberOfRound - 2]);
                }

                if (respawn.Throwes[respawn.numberOfRound - 2][1] == 10 && respawn.Throwes[respawn.numberOfRound - 2][1] != 10)
                {
                    FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, respawn.Totalpoints[respawn.numberOfRound - 2]);
                }
            }
            if (respawn.numberOfRound >= 1) //19
            {
                FindObjectOfType<Scores>().saveScoreTotalPoints1(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.totalScorePlayer1);
            }
            respawn.player = 2;

        }
        else
        {
            if (respawn.Throwes[respawn.numberOfRound][1] == 10)
            {
                FindObjectOfType<Scores>().saveScore2(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][1]);
                if (respawn.numberOfRound == 20)
                {
                    FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, 10);
                    if (respawn.Throwes[respawn.numberOfRound-2][1] == 10)
                    {
                        FindObjectOfType<Scores>().saveScoreTotal(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, 20);
                    }
                }
            }
            else if (respawn.Throwes[respawn.numberOfRound][1] + respawn.Throwes[respawn.numberOfRound][2] == 10)
            {
                FindObjectOfType<Scores>().saveScore2(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][1]);
                FindObjectOfType<Scores>().saveScore3(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][2]);
            }
            else
            {
                FindObjectOfType<Scores>().saveScore2(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][1]);
                FindObjectOfType<Scores>().saveScore3(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Throwes[respawn.numberOfRound][2]);
                FindObjectOfType<Scores>().saveScoreTotal1(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.Totalpoints[respawn.numberOfRound]);
            }

            if (respawn.numberOfRound >= 3)
            {
                if (respawn.Throwes[respawn.numberOfRound - 2][1] + respawn.Throwes[respawn.numberOfRound - 2][2] == 10 && respawn.Throwes[respawn.numberOfRound][1] != 10)
                {
                    FindObjectOfType<Scores>().saveScoreTotal1(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, respawn.Totalpoints[respawn.numberOfRound - 2]);
                }
            }

            if (respawn.numberOfRound >= 3)
            {
                if (respawn.numberOfRound >= 5)
                {
                    if (respawn.Throwes[respawn.numberOfRound - 4][1] == 10)
                    {
                        FindObjectOfType<Scores>().saveScoreTotal1(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 4, respawn.Totalpoints[respawn.numberOfRound - 4]);
                    }
                }
                if (respawn.Throwes[respawn.numberOfRound-2][1] == 10)
                {
                    FindObjectOfType<Scores>().saveScoreTotal1(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound - 2, respawn.Totalpoints[respawn.numberOfRound - 2]);
                }
            }

            if (respawn.numberOfRound >= 2) //20
            {
                FindObjectOfType<Scores>().saveScoreTotalPoints2(respawn.player, respawn.numberOfThrowes, respawn.numberOfRound, respawn.totalScorePlayer2);
            }
            respawn.player = 1;
        }
    }
}
