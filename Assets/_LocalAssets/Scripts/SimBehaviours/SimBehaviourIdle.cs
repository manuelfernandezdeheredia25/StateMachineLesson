using System.Threading;
using UnityEngine;

public class SimBehaviourIdle : SimBehaviourBase
{
    public SimBehaviourIdle(Sim sim) : base(sim)
    {
    }

    public override void Awake()
    {
       timeStart = Time.time;
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
        if(Time.time - timeStart >= changeWalking)
        {
            Debug.Log("Cambio Estado --> Walking " + Time.time);
            sim.changeState(new SimBehaviourWalking(sim));
        }
    }
}
