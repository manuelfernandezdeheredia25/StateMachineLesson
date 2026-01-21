using UnityEngine;

public class SimBehaviourWalking : SimBehaviourBase
{
    int count = 0;

    public SimBehaviourWalking(Sim sim) : base(sim)
    {

    }

    public override void Awake()
    {
    }

    public override void Interact(RaycastHit hit)
    {
        if (hit.transform.gameObject.TryGetComponent(out Interactable inter))
        {

            inter.interactingBehaviour.SetSim(sim);

            sim.changeState(new SimBehaviourGoTo(sim, inter));

        }
    }

    public override void Update()
    {
        sim.transform.position = Vector3.MoveTowards(sim.transform.position, sim.walkingPoints[count].transform.position, sim.speed * 0.5f * Time.deltaTime);
        //sim.transform.rotation = Quaternion.LookRotation(sim.walkingPoints[count].transform.position - sim.transform.position);
        sim.transform.forward = Vector3.RotateTowards(sim.transform.forward, sim.walkingPoints[count].transform.position - sim.transform.position, 5 * Time.deltaTime, 1);

        if (Vector3.Distance(sim.transform.position, sim.walkingPoints[count].transform.position) < 0.01f)
        {
            count++;
        }
        if (count >= sim.walkingPoints.Length)
        {

            sim.changeState(new SimBehaviourIdle(sim));
        }
    }
}

