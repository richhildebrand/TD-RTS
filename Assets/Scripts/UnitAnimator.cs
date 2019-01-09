using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
  public static class UnitAnimator
  {
    public static void Idle(Animator uniAnimator)
    {
      ClearAll(uniAnimator);
      uniAnimator.SetBool("idle", true);
    }

    public static void Move(Animator uniAnimator)
    {
      ClearAll(uniAnimator);
      uniAnimator.SetBool("walk", true);
    }

    private static void ClearAll(Animator unitAnimator)
    {
      unitAnimator.SetBool("idle", false);
      unitAnimator.SetBool("walk", false);
      unitAnimator.SetBool("attack_01", false);
      unitAnimator.SetBool("die", false);
    }
  }
}
