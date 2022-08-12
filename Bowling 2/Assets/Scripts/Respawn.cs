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
    private float points;

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
            }
        }
        if (other.CompareTag("bowling"))
        {
            points += 1;
        }
        Debug.Log(points);
    }
    public IEnumerator PickUp(Rigidbody rb, Animator bpu) {
            Physics.SyncTransforms();
        bpu.enabled = true;
        rb.isKinematic = true;
        bpu.SetBool("UP", true);
            yield return new WaitForSeconds(4);
        bpu.SetBool("UP", false);
            TBPP.SetBool("StartAnimation", true);
            yield return new WaitForSeconds(3);
        bpu.SetBool("UP", false);
            yield return new WaitForSeconds(1);
        bpu.SetBool("Down", true);
            yield return new WaitForSeconds(3);
        bpu.SetBool("Down", false);
        yield return new WaitForSeconds(2);
        rb.velocity = Vector3.zero;
        bpu.enabled = false;
        rb.isKinematic = false;
    }
}


