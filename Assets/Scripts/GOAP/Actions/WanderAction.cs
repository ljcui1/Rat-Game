using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;

namespace GOAP.Actions
{
    public class WanderAction : ActionBase<CommonData>
    {
        public override void Created() {}

        public override void End(IMonoAgent agent, CommonData data) {}
        public override ActionRunState Perform(IMonoAgent agent, CommonData data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;

            if (data.Timer > 0)
            {
                return ActionRunState.Continue;
            }
            return ActionRunState.Stop;
        }

        public override void Start(IMonoAgent agent, CommonData data) {
            data.Timer = Random.Range(1, 2);
        }
    }
}
