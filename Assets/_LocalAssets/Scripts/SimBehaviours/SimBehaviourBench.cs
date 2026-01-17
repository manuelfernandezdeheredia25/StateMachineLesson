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
        IsInterrumpible = true;
        //sim.transform.position = bench.transform.position + new Vector3(0,1.5f,0);
        //sim.transform.rotation = Quaternion.Euler(new Vector3(0,0,0) + new Vector3(0, bench.transform.rotation.eulerAngles.y, 0));
        //timerDuration = 5f;
        //StartTimer();
    }

    public override void Asleep()
    {
        sim.transform.position = new Vector3(sim.transform.position.x, 0, sim.transform.position.z);
    }

    public override void Update()
    {
        sim.transform.rotation = Quaternion.RotateTowards(sim.transform.rotation, Quaternion.Euler(0, bench.transform.rotation.eulerAngles.y, 0),10);
        sim.transform.position = Vector3.MoveTowards(sim.transform.position,bench.transform.position + new Vector3(0, 1.5f, 0), 5*Time.deltaTime);
    }
}