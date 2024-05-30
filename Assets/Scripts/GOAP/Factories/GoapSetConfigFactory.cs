using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Resolver;
using CrashKonijn.Goap.Enums;
using GOAP.Actions;
using GOAP.Goals;
using GOAP.Sensors;
using GOAP.Targets;
using GOAP.WorldKeys;
using UnityEngine;

namespace GOAP.Factories
{
    public class GoapSetConfigFactory : GoapSetFactoryBase
    {
        public override IGoapSetConfig Create()
        {
            GoapSetBuilder builder = new(name:"Rat3_Set");

            BuildGoals(builder);
            BuildActions(builder);
            BuildSensor(builder);

            return builder.Build();
        }
        private void BuildGoals(GoapSetBuilder builder)
        {
            builder.AddGoal<WanderGoal>()
                .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, amount: 1);
        }

        private void BuildActions(GoapSetBuilder builder)
        {
            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(EffectType.Increase)
                .SetBaseCost(5)
                .SetInRange(10);
        }

        private void BuildSensor(GoapSetBuilder builder)
        {
            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();
        }

    }
}
