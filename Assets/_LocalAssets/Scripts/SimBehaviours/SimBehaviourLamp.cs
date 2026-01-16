using UnityEngine;

public class SimBehaviourLamp : SimBehaviourBase
{
    GameObject lamp;

    public SimBehaviourLamp(GameObject lamp)
    {
        this.lamp = lamp;
    }

    public SimBehaviourLamp(Sim sim) : base(sim)
    {
    }

    public override void Awake()
    {
        Light lampLight = lamp.GetComponentInChildren<Light>();
        if (lampLight.enabled)
        {
            lampLight.enabled = false;
        }
        else
        {
            lampLight.enabled = true;
        }
        timerDuration = 5f;
        StartTimer();
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
        if (TimerEnded)
        {
            sim.changeState(new SimBehaviourIdle(sim));
        }
    }
}
