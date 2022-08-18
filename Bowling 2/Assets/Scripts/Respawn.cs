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
    [SerializeField] public GameObject BowlingPinPrefab;


    public List<GameObject> bowling_2 = new List<GameObject>();
    public float speed = 2f;
    private bool throwes = false;
    private int number = 0;
    private Dictionary<int, Dictionary<int, int>> Throwes = new Dictionary<int, Dictionary<int, int>>();
    private Dictionary<int, int> Score = new Dictionary<int, int>();
    private Dictionary<int, int> Totalpoints = new Dictionary<int, int>();
    private int numberOfThrowes = 0;
    private bool isStrike = false;
    private static int throwesInRound = 2;
    private int a = 0;

    private void Start()
    {
        if (numberOfThrowes == throwesInRound)
        {
            Debug.Log("koniec animacji 2");
            Instantiate(BowlingPinPrefab, new Vector3(-6.535f, 0.04f, 0.357f), Quaternion.identity);
            StartCoroutine(BarAnimation(TBPP));
            StartCoroutine(NewBowlingPin(Rb, BPU));
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball1") || other.CompareTag("Ball2") || other.CompareTag("Ball3"))
        {
            numberOfThrowes++;
            throwes = !throwes;
            Debug.Log($"throwes: {throwes}");
            a++;
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

            if (a % 2 == 1)
            {
                Throwes.Add(number++, Score);
            }
        }
        if (other.CompareTag("bowling") || a >= 1) //|| a >= 1
        {
            if (throwes)
            {
                Debug.Log("rzut 1");
                FirstThrow();
                if (isStrike)
                {
                    //numberOfThrowes++;
                    Debug.Log($"ile {numberOfThrowes}   ");
                }
            }
            else
            {
                if (!isStrike)
                {
                    Debug.Log("rzut 2");
                    SecondThrow();
                }
            }
        }
    }
    public void CountPoints()
    {
        Debug.Log($"LICZY {numberOfThrowes}   ");
        if (numberOfThrowes == throwesInRound)
        {
            Debug.Log(".");
            CountingPoints();
        }
    }

    private IEnumerator NewBowlingPin(Rigidbody rb, Animator bpu)
    {
        Physics.SyncTransforms();
        bpu.enabled = true;
        rb.isKinematic = true;
        rb.freezeRotation = true;
        yield return new WaitForSeconds(4);
        bpu.SetBool("UP", false);
        yield return new WaitForSeconds(1);
        rb.velocity = Vector3.zero;
        rb.freezeRotation = false;
        bpu.enabled = false;
        rb.isKinematic = false;
    }

    private IEnumerator PickUp(Rigidbody rb, Animator bpu)
    {
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
        Debug.Log(points);
        if (points == 11)
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
        Debug.Log(points);
        if (Score[1] + Score[2] == 12)
        {
            Debug.Log("SPARE");
        }
    }

    private void CountingPoints()
    {
        Debug.Log($"Round Number is {number}");
        //if (Throwes[number][1] >= 2) { };
        if (Throwes[number - 1][1] == 11)
        {
            Strike();
        }
        else if (Throwes[number - 1][1] + Throwes[number - 1][2] == 12)
        {
            Spare();
        }
        var score = Score.Sum(x => x.Value) - 2; //-2 odjêcie punktów za kule
        Totalpoints.Remove(number);
        Totalpoints.Add(number, score);
        Debug.Log($"points: {Totalpoints[number]}");
    }

    private void Strike()
    {
        var score = 20 + Score.Sum(x => x.Value) - 1;
        Totalpoints.Remove(number);
        Totalpoints.Add(number, score);
    }

    private void Spare()
    {
        var score = 10 + Score[1] - 2;
        Totalpoints.Remove(number - 1);
        Totalpoints.Add(number - 1, score);
    }
}


