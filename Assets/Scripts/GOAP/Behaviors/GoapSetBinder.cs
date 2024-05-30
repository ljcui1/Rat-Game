using CrashKonijn.Goap.Behaviours;
using UnityEngine;

namespace GOAP.Behaviors
{
    public class GoapSetBinder : MonoBehaviour
    {
        [SerializeField] private GoapRunnerBehaviour GoapRunner;

        private void Awake()
        {
            AgentBehaviour agent = GetComponent<AgentBehaviour>();
            agent.GoapSet = GoapRunner.GetGoapSet(id: "Rat3_Set");
        }

    }
}