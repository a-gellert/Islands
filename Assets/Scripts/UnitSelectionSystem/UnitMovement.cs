using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 point)
    {
        _agent.SetDestination(point);
    }
}
