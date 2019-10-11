using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    GameObject target;

    public int spawnPoint;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player"); //Determinar o alvo a partir da Tag de Player
    }

    // Update is called once per frame
    void Update()
    {
        followTarget();
    }

    void followTarget()
    {
        navMeshAgent.SetDestination(target.transform.position); //Muda o destino do inimigo para a posição do Player
    }
}
