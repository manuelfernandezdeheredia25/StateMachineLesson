using Unity.VisualScripting;
using UnityEngine;

public class SimBehaviourBench : SimBehaviourBase
{
    GameObject bench;

    public SimBehaviourBench(GameObject bench)
    {
        this.bench = bench;
    }

    public override void Awake()
    {
        sim.transform.position = bench.transform.position + new Vector3(0,1.5f,0);
        sim.transform.rotation = Quaternion.Euler(new Vector3(0,0,0) + new Vector3(0, bench.transform.rotation.eulerAngles.y, 0));
        //timerDuration = 5f;
        //StartTimer();
    }

    public override void Interact(RaycastHit hit)
    {
        if (hit.transform.gameObject.TryGetComponent(out Interactable inter))
        {
            sim.transform.position = new Vector3(sim.transform.position.x, 0, sim.transform.position.z);
            inter.interactingBehaviour.SetSim(sim);
            sim.changeState(new SimBehaviourGoTo(sim, inter));
        }
    }

    public override void Update()
    {
        if (TimerEnded)
        {
            //sim.changeState(new SimBehaviourIdle(sim));
        }
    }
}