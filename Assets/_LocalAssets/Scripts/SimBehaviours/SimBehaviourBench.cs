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
        StartTimer();
        IsInterrumpible = true;
        timerDuration = 10; 
    }

    public override void Asleep()
    {
        sim.transform.position = new Vector3(sim.transform.position.x, 0, sim.transform.position.z);
    }

    public override void Update()
    {
        sim.transform.rotation = Quaternion.RotateTowards(sim.transform.rotation, Quaternion.Euler(0, bench.transform.rotation.eulerAngles.y, 0),10);
        sim.transform.position = Vector3.MoveTowards(sim.transform.position,bench.transform.position + new Vector3(0, 1.5f, 0), 5*Time.deltaTime);
        if (TimerEnded)
        {
            sim.changeState(new SimBehaviourRoboTalkSitting("CHILLIN  .ω.", sim));
        }
    }
}