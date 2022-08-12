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
    private float points1;
    private float points2;
    private float score;
    private bool Throw = false;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var bowlingpin in bowling_2)
        {
            bowlingpin.GetComponent<Rigidbody>().isKinematic = false;
            BPU = bowlingpin.GetComponent<Animator>();
            Rb = bowlingpin.GetComponent<Rigidbody>();

            if (other.CompareTag("Ball1") || other.CompareTag("Ball2") || other.CompareTag("Ball3"))
            {
                other.transform.position = Res.transform.position;
                if (bowlingpin.transform.localRotation.x == 0 && bowlingpin.transform.localRotation.y <= Math.Abs(5))
                {
                    StartCoroutine(PickUp(Rb, BPU));
                }
                StartCoroutine(BarAnimation(TBPP));
            }
            Throw = !Throw;
        }
        if (other.CompareTag("bowling"))
        {
            points1 += 1;
            if (Throw)
            {
                FirstThrow(points1);
            }
            else{
                SecondThrow(points1, points2);
            }
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
        TBPP.SetBool("StartAnimation", true);
        yield return new WaitForSeconds(1);
    }

    public float FirstThrow(float points1)
    {
        if(points1 == 10)
        {
            Debug.Log("STRIKE");
            return points1;
        }
        else
        {
            Debug.Log($"Points: {points1}");
            return points1;
        }
    }
    public float SecondThrow(float points1, float points2)
    {
        points2 += 1;
        score = points1 + points2;
        if (score == 10)
        {
            Debug.Log("SPARE");
            return 10+points2;
        }
        else
        {
            Debug.Log($"Points: {score}");
            return score;
        }
    }
}


