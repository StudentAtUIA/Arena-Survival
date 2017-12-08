using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class clickToMove : MonoBehaviour {

    private Animator mAnimator;

    private NavMeshAgent mNavMeshAgent;

    private bool mRunning = false;

	// Use this for initialization
	void Start () {

        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(1))
        {
            if (mNavMeshAgent.velocity == Vector3.zero)
            {
                mRunning = false;
            }

            if (Physics.Raycast(ray, out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
            }

            if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
            {
                mRunning = false;
            }

            else
            {
                mRunning = true;
            }
        }

        mAnimator.SetBool("Running", mRunning);
	}
}
