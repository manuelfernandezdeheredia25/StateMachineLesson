using UnityEngine;

public abstract class SimBehaviourBase : ISimBehaviour
{
    protected Sim sim;
    protected bool isInterrumpible = true;
    protected float timeStart = 0;
    protected float changeWalking = 10;


    public void SetSim(Sim sim)
    {
        this.sim = sim;
    }
    public SimBehaviourBase(Sim sim)
    {
        this.sim = sim;
    }

    public SimBehaviourBase() { }

    public abstract void Awake();

    public abstract void Interact(RaycastHit hit);

    public abstract void Update();
}
