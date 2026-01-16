using UnityEngine;

public class SimBehaviourGoTo : SimBehaviourBase
{
    protected Interactable interactable;
    protected Vector3 FinalPos;

    public SimBehaviourGoTo(Sim sim, Interactable inter) : base(sim)
    {
        interactable = inter;
    }

    public override void Awake()
    {
        IsInterrumpible = true;
        FinalPos = interactable.transform.position;
    }

    public override void Interact(RaycastHit hit)
    {

    }

    public override void Update()
    {

        sim.transform.forward = Vector3.RotateTowards(sim.transform.forward, FinalPos - sim.transform.position, 5 * Time.deltaTime, 10f * Time.deltaTime);
        //sim.transform.rotation = Quaternion.LookRotation(FinalPos - sim.transform.position);
        sim.transform.position = Vector3.MoveTowards(sim.transform.position, FinalPos, sim.speed * Time.deltaTime);
        if (Vector3.Distance(sim.transform.position, FinalPos) < sim.minDistance)
        {
            sim.changeState(interactable.interactingBehaviour);
        }
    }
}