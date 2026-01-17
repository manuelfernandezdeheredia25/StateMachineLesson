using System.Linq;
using System.Threading;
using UnityEngine;

public class SimBehaviourIdle : SimBehaviourBase
{
    public SimBehaviourIdle(Sim sim) : base(sim)
    {
    }

    public override void Awake()
    {
       StartTimer();
    }


    public override void Update()
    { 
        if(TimerEnded)
        {
            sim.changeState(new SimBehaviourWalking(sim));
        }
    }
}
