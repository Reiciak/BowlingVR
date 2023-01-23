using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform ball1;
    [SerializeField] private Transform ball2;
    [SerializeField] private Transform ball3;
    [SerializeField] private Transform Res;
    [SerializeField] private Animator TBPP;
    [SerializeField] private Animator BPU;
    [SerializeField] private Rigidbody Rb;
    [SerializeField] public GameObject BowlingPinPrefab;
    [SerializeField] private Transform bowlingTransform;

    private Vector3 bowlingRespawnPosition;
    public List<GameObject> bowling_2 = new List<GameObject>();
    private bool throws = false;
    internal int numberOfRound = 1;
    public Dictionary<int, Dictionary<int, int>> Throwes = new Dictionary<int, Dictionary<int, int>>();
    public Dictionary<int, int> Totalpoints = new Dictionary<int, int>();
    public Dictionary<int, int> TotalScore = new Dictionary<int, int>();
    public int numberOfThrowes = 0;
    private bool isStrike = false;
    private static readonly int throwesInRound = 2;
    private bool stop = false;
    public Scores scores = new();
    public DisplayScore displayScore = new();
    public int player = 1;
    public bool nextRound = false;
    public int points1 = 0;
    public int points2 = 0;
    internal int totalScore = 0;
    public a setRound = new();
    public int totalScorePlayer1 = 0;
    public int totalScorePlayer2 = 0;

    private void Start()
    {
        if (bowlingTransform != null)
        {
            bowlingRespawnPosition = bowlingTransform.position;
        }
        for (int i = 1; i <= 20; i++)
        {
            Throwes.Add(i, new Dictionary<int, int>());
        }

        setRound = new a();
        setRound.respawn = this;
    }

    public void NextRound()
    {
        numberOfRound++;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball1") || other.CompareTag("Ball2") || other.CompareTag("Ball3"))
        {
            if (!isStrike)
            {
                ++numberOfThrowes;
            }
           
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
            }
            StartCoroutine(BarAnimation(TBPP));
        }
        if (other.CompareTag("bowling"))
        {
            if (!throws)
            {
                if (!stop)
                {
                    FirstThrow();
                }
            }
            else
            {
                if (!stop)
                {
                    if (!isStrike)
                    {
                        SecondThrow();
                    }
                }
            }
        }

        if (other.CompareTag("Ball1") || other.CompareTag("Ball2") || other.CompareTag("Ball3") && !other.CompareTag("bowling"))
        {
            if (!throws)
            {
                if (!stop)
                {
                    if (!Throwes[numberOfRound].ContainsKey(1))
                    {
                        Throwes[numberOfRound].Add(1, 0);
                    }
                }
            }
            else
            {
                if (!stop)
                {
                    if (!isStrike)
                    {
                        if (!Throwes[numberOfRound].ContainsKey(2))
                        {
                            Throwes[numberOfRound].Add(2, 0);
                        }
                    }
                }
            }
        }
    }
    public void CountPoints()
    {
        Debug.Log("Count points start");
        if (numberOfThrowes == throwesInRound)
        {
            CountingPoints();
        }
    }

    private IEnumerator NewBowlingPin(Rigidbody rb, Animator bpu)
    {
        Physics.SyncTransforms();
        bpu.enabled = true;
        rb.isKinematic = true;
        rb.freezeRotation = true;
        yield return new WaitForSeconds(5);
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
        yield return new WaitForSeconds(3);
        TBPP.SetBool("StartAnimation", true);
        yield return new WaitForSeconds(1);
        TBPP.SetBool("StartAnimation", false);
    }

    public void FirstThrow()
    {
        if (!Throwes[numberOfRound].ContainsKey(1))
        {
            Throwes[numberOfRound].Add(1, 0);
        }
        points1 = Throwes[numberOfRound].GetValueOrDefault(1) + 1;
        Throwes[numberOfRound].Remove(1);
        Throwes[numberOfRound].Add(1, points1);
        if (points1 == 10)
        {
            Debug.Log("STRIKE");
            isStrike = true;
            numberOfThrowes = 2;
            setRound.CountPoints();
            Throwes[numberOfRound].Add(2, 0);
        }
    }
    public void SecondThrow()
    {
        if (!Throwes[numberOfRound].ContainsKey(1))
        {
            Throwes[numberOfRound].Add(2, 0);
        }
        points2 = Throwes[numberOfRound].GetValueOrDefault(2) + 1;
        Throwes[numberOfRound].Remove(2);
        Throwes[numberOfRound].Add(2, points2);
        if (Throwes[numberOfRound][1] + Throwes[numberOfRound][2] == 10)
        {
            Debug.Log("SPARE");
        }
    }

    public bool GetThrowes()
    {
        return throws;
    }

    public void CountingPoints()
    {
        if (numberOfRound >= 5)
        {
            if (Throwes[numberOfRound - 2][1] == 10 || Throwes[numberOfRound - 4][1] == 10)
            {
                Strike();
            } else if (Throwes[numberOfRound - 2][1] + Throwes[numberOfRound - 2][2] == 10)
            {
                Spare();
            }
        }
        stop = !stop;
        var score = Throwes[numberOfRound].Sum(x => x.Value);
        Totalpoints.Remove(numberOfRound);
        Totalpoints.Add(numberOfRound, score);
        score = 0;
        if (numberOfRound >= 1) //19
        {
            if (player == 1)
            {
                foreach (var tmpPoints in Totalpoints)
                {
                    if (tmpPoints.Key % 2 == 1)
                    {
                        totalScorePlayer1 += tmpPoints.Value;
                    }
                    Debug.Log($"Points1: {totalScorePlayer1}");
                }

            }
            else
            {
                foreach (var tmpPoints in Totalpoints)
                {
                    if (tmpPoints.Key % 2 == 0)
                    {
                        totalScorePlayer2 += tmpPoints.Value;
                    }
                    Debug.Log($"Points2: {totalScorePlayer2}");
                }
            }
        }
        StartCoroutine(RespawnBowlingPin());
    }

    public void Strike(){
        Debug.Log("tfu strike");
        if (numberOfRound >= 5)
        {
            if (Throwes[numberOfRound - 4][1] == 10 && Throwes[numberOfRound - 2][1] == 10)
            {
                var score = 10 + 10 + Throwes[numberOfRound][1];
                Totalpoints.Remove(numberOfRound - 4);
                Totalpoints.Add(numberOfRound - 4, score);
            }
        }
        if (Throwes[numberOfRound - 2][1] == 10 && Throwes[numberOfRound][1] == 10)
        {
            Totalpoints.Remove(numberOfRound - 2);
            Totalpoints.Add(numberOfRound - 2, 0);
        }
        if (Throwes[numberOfRound - 2][1] == 10 && Throwes[numberOfRound][1] != 10)
        {
            var score = 10 + Throwes[numberOfRound][1] + Throwes[numberOfRound][2]; //.Sum(x => x.Value)
            Totalpoints.Remove(numberOfRound - 2);
            Totalpoints.Add(numberOfRound - 2, score);
            score = 0;
        }
    }

        public void Spare(){
        Debug.Log("tfu spare");
        var score = 10 + Throwes[numberOfRound][1];
        Totalpoints.Remove(numberOfRound-2);
        Totalpoints.Add(numberOfRound-2, score);
        Debug.Log($"SCORE {score}");
        score = 0;
    }

    public void SetThrowes()
    {
        throws = !throws;
    }

    public IEnumerator RespawnBowlingPin()
    {
        if (numberOfThrowes == throwesInRound)
        {
            nextRound = true;
            StartCoroutine(NewBowlingPin(Rb, BPU));
            StartCoroutine(BarAnimation(TBPP));
            yield return new WaitForSeconds(5); //4
            StartCoroutine(MakeBowlingPin());
            displayScore.displayPoints();
            numberOfThrowes = 0;
            isStrike = false;
            totalScorePlayer1 = 0;
            totalScorePlayer2 = 0;
        }
    }
    public IEnumerator MakeBowlingPin()
    {
        yield return new WaitForSeconds(5); //4
        GameObject newBowling = Instantiate(BowlingPinPrefab, bowlingRespawnPosition + new Vector3(-0f, 0f, 0.0f), Quaternion.identity,transform.parent); //new Vector3(-6.535f, 0.04f, 0.357f)
        stop = !stop;

        var tmpBowling = new List<GameObject>();
        foreach (Transform child in newBowling.GetComponentsInChildren<Transform>())
        {
            var pin = child.gameObject.GetComponentInChildren<Transform>().gameObject;
            if (pin.GetComponent<Rigidbody>() != null)
            {
                tmpBowling.Add(pin);
            }
        }
        bowling_2.Clear();
        bowling_2 = tmpBowling;
    }
}



