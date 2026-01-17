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

    public override void Update()
    {

        sim.transform.forward = Vector3.RotateTowards(sim.transform.forward, interactable.transform.position - sim.transform.position, 5 * Time.deltaTime, 10f * Time.deltaTime);
        //sim.transform.rotation = Quaternion.LookRotation(FinalPos - sim.transform.position);
        sim.transform.position = Vector3.MoveTowards(sim.transform.position, interactable.transform.position, sim.speed * Time.deltaTime);
        if (Vector3.Distance(sim.transform.position, interactable.transform.position) < sim.minDistance)
        {
            sim.changeState(interactable.interactingBehaviour);
        }
    }
}