using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
  public NavMeshAgent Agent { get; set; }

  void Start()
  {
    Agent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(Constants.RightMouseButton))
    {
      Move(Agent);
    }
  }

  private static void Move(NavMeshAgent agent)
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    Physics.Raycast(ray, out RaycastHit hit, 100);
    agent.destination = hit.point;
  }
}
