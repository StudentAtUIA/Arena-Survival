using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToMove : MonoBehaviour
{

    private Animator _mAnimator;
    private NavMeshAgent _mNavMeshAgent;

    private DrawHeroNavPath _heroNavPath;

    // Use this for initialization
    void Start()
    {
        _mAnimator = GetComponent<Animator>();
        _mNavMeshAgent = GetComponent<NavMeshAgent>();

        _heroNavPath = GetComponent<DrawHeroNavPath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_mNavMeshAgent.remainingDistance <= _mNavMeshAgent.stoppingDistance)
        {
            _mAnimator.StopPlayback();
            _mAnimator.SetBool("Running", false);
        }

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                _mNavMeshAgent.destination = hit.point;
                _mAnimator.SetBool("Running", true);
                _mAnimator.SetBool("Attacking", false);

                _heroNavPath.SpawnDots();
            }
        }
    }
}
