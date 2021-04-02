using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Finish : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMesh1;
    [SerializeField] private GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            navMesh1.isStopped = true;
            text.SetActive(true);
        }
    }
}
