using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class a : MonoBehaviour
{
    public Respawn respawn;
    //public RespawnBowlingPin respawn;

    public void CountPoints() {
        if (respawn!=null)
        {
            respawn.CountPoints();
            respawn.SetThrowes();
        }
    }
}
