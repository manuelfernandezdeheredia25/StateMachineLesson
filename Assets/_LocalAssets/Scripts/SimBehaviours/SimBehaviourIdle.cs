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

    public override void Interact(RaycastHit hit)
    {
        
        if (hit.transform.gameObject.TryGetComponent(out Interactable inter))
        {
            
            inter.interactingBehaviour.SetSim(sim);
                
             sim.changeState(new SimBehaviourGoTo(sim,inter));
            
        }
    }

    public override void Update()
    { 
        if(TimerEnded)
        {
            
            sim.changeState(new SimBehaviourWalking(sim));
        }
    }
}
