using Assets.Scripts;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
  public NavMeshAgent Agent { get; set; }
  public Animator Animator { get; set; }
  public Constants.UnitState UnitState;

  void Start()
  {
    Agent = GetComponent<NavMeshAgent>();
    Animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(Constants.RightMouseButton))
    {
      Move(this);
    }

    if (Agent.velocity == Vector3.zero && Constants.UnitState.Idle != UnitState)
    {
      UnitAnimator.Idle(Animator);
      UnitState = Constants.UnitState.Idle;
    }

    if (Agent.velocity != Vector3.zero && Constants.UnitState.Moving != UnitState)
    {
      UnitAnimator.Move(Animator);
      UnitState = Constants.UnitState.Moving;
    }
  }

  private static void Move(Unit unit)
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    Physics.Raycast(ray, out RaycastHit hit, 100);
    unit.Agent.destination = hit.point;
    Debug.Log("Move");
  }
}
