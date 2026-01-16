using UnityEngine;

public abstract class SimBehaviourBase : ISimBehaviour
{
    protected Sim sim;
 
    protected float timerStart = 0;
    protected float timerDuration = 10;

    protected bool started = false;
    public bool IsInterrumpible { get; set; }

    public void SetSim(Sim sim)
    {
        this.sim = sim;
    }
    public SimBehaviourBase(Sim sim)
    {
        this.sim = sim;
        IsInterrumpible = true;
    }

    protected void StartTimer()
    {
        if (TimerEnded)
            timerStart = Time.time;
    }

    protected bool TimerEnded
    {
        get { return Time.time - timerStart >= timerDuration; }
    }

    public SimBehaviourBase() { }

    public abstract void Awake();

    public abstract void Interact(RaycastHit hit);

    public abstract void Update();
}
