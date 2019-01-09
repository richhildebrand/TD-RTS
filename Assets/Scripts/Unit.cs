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
    Animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(Constants.RightMouseButton))
    {
      Move(this);
    }
  }

  private static void Move(Unit unit)
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    Physics.Raycast(ray, out RaycastHit hit, 100);


    unit.AiPath.destination = hit.point;
    Debug.Log("Move");
  }
}
