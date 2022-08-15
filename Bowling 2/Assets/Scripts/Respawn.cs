using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
    private int points1;
    private int points2;
    private int score;
    private bool Throw = false;
    private int number = 0;
    private Dictionary<int, Dictionary<int, int>> Throwes = new Dictionary<int, Dictionary<int, int>>();
    private Dictionary<int,int> Score = new Dictionary<int, int>();

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball1") || other.CompareTag("Ball2") || other.CompareTag("Ball3"))
        {
            if (Throw)
            {
                Debug.Log("Second throw ball");
            }
            foreach (var bowlingpin in bowling_2)
            {
                if (Throw)
                {
                    Debug.Log("Itering second ball throw");
                }
                bowlingpin.GetComponent<Rigidbody>().isKinematic = false;
                BPU = bowlingpin.GetComponent<Animator>();
                Rb = bowlingpin.GetComponent<Rigidbody>();
                other.transform.position = Res.transform.position;
                if (bowlingpin.transform.localRotation.x == 0 && bowlingpin.transform.localRotation.y <= Math.Abs(5))
                {
                    if (Throw)
                    {
                        Debug.Log("Pick up second ball throw");
                    }
                    StartCoroutine(PickUp(Rb, BPU));
                }
                if (Throw)
                {
                    Debug.Log("Start animation second ball throw");
                }
                StartCoroutine(BarAnimation(TBPP));
            }
            Throw = !Throw;
        }
        if (other.CompareTag("bowling"))
        {
            if (Throw)
            {
                FirstThrow();
            }
            else{
                SecondThrow();
            }
            Throwes.Add(number++, Score);

        }
    }
    public IEnumerator PickUp(Rigidbody rb, Animator bpu) {
            Physics.SyncTransforms();
        bpu.enabled = true;
        rb.isKinematic = true;
        rb.freezeRotation = true;
        bpu.SetBool("UP", true);
            yield return new WaitForSeconds(2);
        bpu.SetBool("UP", false);
            yield return new WaitForSeconds(1);
        bpu.SetBool("Down", true);
            yield return new WaitForSeconds(4);
        bpu.SetBool("Down", false);
            yield return new WaitForSeconds(1);
        rb.velocity = Vector3.zero;
        rb.freezeRotation = false;
        bpu.enabled = false;
        rb.isKinematic = false;
    }

    public IEnumerator BarAnimation(Animator TBPP)
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Start Animation!!!");
        TBPP.SetBool("StartAnimation", true);
        yield return new WaitForSeconds(1);
    }

    public void FirstThrow()
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
        }
    }
    public void SecondThrow()
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
        else
        {
            //Debug.Log($"Points: {score}");
        }
    }
}


