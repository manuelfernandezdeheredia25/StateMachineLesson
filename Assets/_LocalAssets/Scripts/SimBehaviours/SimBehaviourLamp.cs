using UnityEngine;

public class SimBehaviourLamp : SimBehaviourBase
{
    public SimBehaviourLamp()
    {
    }

    public SimBehaviourLamp(Sim sim) : base(sim)
    {
    }

    public override void Awake()
    {
        Debug.Log("awake lamp");
    }

    public override void Interact(RaycastHit hit)
    {
        
    }

    public override void Update()
    {
        Debug.Log("update lamp");
    }
}
