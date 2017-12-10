using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{

    private Animator _anim;
    private NavMeshAgent _mNavMeshAgent;

    [SerializeField]
    private float _attackSpeed = 1f;

    // Use this for initialization
    void Start()
    {

        _mNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("a"))
        {
            _mNavMeshAgent.destination = this.transform.position;

            _anim.SetBool("Running", false);
            _anim.SetBool("Attacking", true);
        }

        _anim.speed = _attackSpeed;

    }
}
