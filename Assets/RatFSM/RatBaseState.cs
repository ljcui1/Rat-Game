using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RatBaseState
{
    public abstract void EnterState(RatFSM rat);
    public abstract void UpdateState(RatFSM rat);
}
