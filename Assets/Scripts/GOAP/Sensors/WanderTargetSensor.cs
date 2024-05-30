using UnityEngine;
using CrashKonijn.Goap.Sensors;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Classes;


namespace GOAP.Sensors {
    public class WanderTargetSensor : LocalTargetSensorBase
    {
        public override void Created() {}

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            Vector3 pos = GetRandomPosition(agent);
            return new PositionTarget(pos);
        }

        private Vector3 GetRandomPosition(IMonoAgent agent) 
        {
            Vector2 random = Random.insideUnitCircle * 5;
            Vector3 newPos = agent.transform.position + new Vector3(random.x, random.y, 0);
            
            return newPos;
        }
        public override void Update() {}

    
    }
}