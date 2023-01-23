using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class a : MonoBehaviour
{
    public Respawn respawn;

    public void CountPoints()
    {
       Debug.Log("A class");
        if (respawn != null)
        {
            respawn.points1 = 0;
            respawn.points2 = 0;
            if (respawn.nextRound)
            {
                Debug.LogError("NEXT ROUND");
                respawn.nextRound = false;
                respawn.NextRound();
                return;
            }
            if (respawn.GetThrowes())
            {
                Debug.LogError("THROWES");
                respawn.CountPoints();
            }
            Debug.LogError("NEXT ROUND");
            respawn.SetThrowes();
        }
    }
}
