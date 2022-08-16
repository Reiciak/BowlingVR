using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Timers;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform ball1;
    [SerializeField] private Transform ball2;
    [SerializeField] private Transform ball3;
    [SerializeField] private Transform Res;
    [SerializeField] private Transform cube;
    [SerializeField] private Animator TBPP;
    [SerializeField] private Animator BPU;
    [SerializeField] private Rigidbody Rb;

    public List<GameObject> bowling_2 = new List<GameObject>();
    public float speed = 2f;
    private bool throwes = false;
    private int number = 0;
    private Dictionary<int, Dictionary<int, int>> Throwes = new Dictionary<int, Dictionary<int, int>>();
    private Dictionary<int,int> Score = new Dictionary<int, int>();
    private Dictionary<int, int> Totalpoints = new Dictionary<int, int>();
    private int numberOfThrowes = 0;
    private bool isStrike = false;
    private static int throwesInRound = 2;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball1") || other.CompareTag("Ball2") || other.CompareTag("Ball3"))
        {
            foreach (var bowlingpin in bowling_2)
            {
                bowlingpin.GetComponent<Rigidbody>().isKinematic = false;
                BPU = bowlingpin.GetComponent<Animator>();
                Rb = bowlingpin.GetComponent<Rigidbody>();
                other.transform.position = Res.transform.position;
                if (bowlingpin.transform.localRotation.x == 0 && bowlingpin.transform.localRotation.y <= Math.Abs(5))
                {
                    StartCoroutine(PickUp(Rb, BPU));
                }
                StartCoroutine(BarAnimation(TBPP));
            }
            throwes = !throwes;
        }
        if (other.CompareTag("bowling"))
        {
            if (throwes)
            {
                FirstThrow();
            }
            else{
                if (isStrike)
                {
                    return;
                }
                SecondThrow();
            }
            Throwes.Add(number++, Score);
        }
        numberOfThrowes++;
        if (numberOfThrowes == throwesInRound)
        {
            Debug.Log(".");
            CountingPoints();
        }
    }
    private IEnumerator PickUp(Rigidbody rb, Animator bpu) {
            Physics.SyncTransforms();
        bpu.enabled = true;
        rb.isKinematic = true;
        rb.freezeRotation = true;
        bpu.SetBool("UP", true);
            yield return new WaitForSeconds(2);
        bpu.SetBool("Down", true);
            yield return new WaitForSeconds(6);
        bpu.SetBool("UP", false);
            yield return new WaitForSeconds(1);
        rb.velocity = Vector3.zero;
        rb.freezeRotation = false;
        bpu.enabled = false;
        rb.isKinematic = false;
    }

    private IEnumerator BarAnimation(Animator TBPP)
    {
            yield return new WaitForSeconds(2);
        TBPP.SetBool("StartAnimation", true);
            yield return new WaitForSeconds(1);
        TBPP.SetBool("StartAnimation", false);
    }

    private void FirstThrow()
    {
        if (!Score.ContainsKey(1))
        {
            Score.Add(1, 0);    
        }
        var points = Score.GetValueOrDefault(1) + 1;
        Score.Remove(1);
        Score.Add(1, points);
        Debug.LogError(points);
        if (points == 10)
        {
            Debug.Log("STRIKE");
            isStrike = true;
        }
    }
    private void SecondThrow()
    {
        if (!Score.ContainsKey(2))
        {
            Score.Add(2, 0);
        }
        var points = Score.GetValueOrDefault(2) + 1;
        Score.Remove(2);
        Score.Add(2, points);
        Debug.LogError(points);
        if (points == 10)
        {
            Debug.Log("SPARE");
        }
    }

    private int CountingPoints()
    {
        if (Score[1] == 10)
        {
            Strike();
        }
        if (Score[1]+ Score[2] == 10)
        {
            Spare();
        }
            var score = Score.Sum(x => x.Value);
            Totalpoints.Remove(1);
            Totalpoints.Add(1, score);
            Debug.Log($"points: {Totalpoints[1]}");
            return 0;
    }

    private int Strike()
    {
        if (!Score.ContainsKey(1))
        {
            return 0;
        }else if (!Score.ContainsKey(2))
        {
            var score = 10 + Score.Sum(x => x.Value);
            Totalpoints.Add(number--, score);
        }
        return 0;
    }

    private int Spare()
    {
        if (!Score.ContainsKey(1))
        {
            return 0;
        }
        else if (!Score.ContainsKey(2))
        {
            var score = 10 + Score[1];
            Totalpoints.Add(number--, score);
        }
        return 0;
    }
}


