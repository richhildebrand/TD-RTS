using Assets.Scripts;
using Pathfinding;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
  public AIPath AiPath { get; set; }
  public Animator Animator { get; set; }
  public Constants.UnitState UnitState;

  void Start()
  {
    AiPath = GetComponent<AIPath>();
    AiPath.constrainInsideGraph = true;

    Animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(Constants.RightMouseButton))
    {
      Move(this);
    }

    if (AiPath.remainingDistance < 2f && UnitState != Constants.UnitState.Idle)
    {
      UnitAnimator.Idle(Animator);
      UnitState = Constants.UnitState.Idle;
      Debug.Log("Stop");
    }

    if (AiPath.remainingDistance >= 2f && UnitState != Constants.UnitState.Moving)
    {
      UnitAnimator.Move(Animator);
      UnitState = Constants.UnitState.Moving;
      Debug.Log("Moving");
    }
  }

  private static void Move(Unit unit)
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    Physics.Raycast(ray, out RaycastHit hit, 100);
    unit.AiPath.destination = hit.point;

    UnitAnimator.Move(unit.Animator);
    unit.UnitState = Constants.UnitState.Moving;
    Debug.Log("Move");
  }
}