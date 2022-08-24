using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayScore : MonoBehaviour
{
    public Respawn respawn;
    [SerializeField] private TextMeshProUGUI points;

   // TextMeshProUGUI txt = GameObject.GetComponent<TextMeshProUGUI>();

    private void DisplayPoints()
    {
        //points = GetComponent<TextMeshProUGUI>();
        points.text = "20";
    }
    private void start()
    {
        points.text = "20";
    }

    private void update()
    {
        points.text = "20";
    }

}
