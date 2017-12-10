using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawHeroNavPath : MonoBehaviour
{
    private NavMeshAgent _mNavMeshAgent;

    private List<GameObject> _dots = new List<GameObject>();

    [SerializeField]
    public GameObject _pathDot;

    // Use this for initialization
    void Start()
    {

        _mNavMeshAgent = GetComponent<NavMeshAgent>();

    }


    public void SpawnDots()
    {
        for (int i = 0; i < _dots.Count; i++)
        {
            Destroy(_dots[i]);
        }
        _dots.Clear();

        int numberOfCorners = _mNavMeshAgent.path.corners.Length;
        for (int i = 0; i < numberOfCorners; i++)
        {
            if (i < numberOfCorners - 1)
            {
                Vector3 offset = _mNavMeshAgent.path.corners[i + 1] - _mNavMeshAgent.path.corners[i];
                float sqrLen = offset.sqrMagnitude;

                for (int pointNumber = 0; pointNumber < sqrLen / 10; pointNumber++)
                {
                    Vector3 newPos = _mNavMeshAgent.path.corners[i] + offset * (pointNumber * 1/(sqrLen / 10.0f));

                    _dots.Add(Instantiate(_pathDot, newPos, Quaternion.identity));

                }

            }
            else
            {
                _dots.Add(Instantiate(_pathDot, _mNavMeshAgent.path.corners[i], Quaternion.identity));
            }
        }
    }
}
