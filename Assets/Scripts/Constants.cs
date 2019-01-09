﻿namespace Assets.Scripts
{
  public static class Constants
  {
    public static readonly int LeftMouseButton = 0;
    public static readonly int RightMouseButton = 1;

    public enum UnitState
    {
      Idle,
      Moving,
      Attacking,
      Dieing,
    }
  }
}
