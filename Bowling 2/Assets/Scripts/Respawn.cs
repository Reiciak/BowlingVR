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

    private List<GameObject> bowling;
    public float speed = 2f;


    private void Start()
    {
        foreach (GameObject b in GameObject.FindGameObjectsWithTag("bowling"))
        {
            if (b.GetComponentInParent<Transform>() == this.GetComponentInParent<Transform>())
            {
                bowling.Add(b);
            }
        }
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        Rb.GetComponent<Rigidbody>().isKinematic = false;
        if (other.CompareTag("Ball1"))
        {
            ball1.transform.position = Res.transform.position;
            Physics.SyncTransforms();
            //yield return new WaitForSeconds(1);
            BPU.GetComponent<Animator>().enabled = true;
            Rb.GetComponent<Rigidbody>().isKinematic = true;
            BPU.SetBool("UP", true);
            yield return new WaitForSeconds(1);
            BPU.SetBool("UP", false);
            TBPP.SetBool("StartAnimation", true);
            yield return new WaitForSeconds(2);
            BPU.SetBool("UP", false);
            yield return new WaitForSeconds(1);
            BPU.SetBool("Down", true);
            yield return new WaitForSeconds(1);
            BPU.SetBool("Down", false);
        }
        if (other.CompareTag("Ball2"))
        {
            ball2.transform.position = Res.transform.position;
            Physics.SyncTransforms();
            yield return new WaitForSeconds(2);
            TBPP.SetBool("StartAnimation", true);
        }
        if (other.CompareTag("Ball3"))
        {
            ball3.transform.position = Res.transform.position;
            Physics.SyncTransforms();
            yield return new WaitForSeconds(2);
            TBPP.SetBool("StartAnimation", true);
        }
    }



    //void Update()
    //{
       
    //}
}
