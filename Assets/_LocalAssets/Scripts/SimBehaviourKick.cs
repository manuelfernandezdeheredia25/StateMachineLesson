using UnityEngine;

public class SimBehaviourKick : SimBehaviourBase
{
    private Rigidbody ballRg;
    private ISimBehaviour previousState;


    public SimBehaviourKick(Sim sim, Rigidbody rg, ISimBehaviour previousState) : base(sim)
    {
        ballRg = rg;
        this.previousState = previousState;
        IsInterrumpible = false;
    }
    public override void Awake()
    {
        //Vector3.RotateTowards
        Vector3 aux = ballRg.transform.position - sim.transform.position;
        sim.transform.rotation = Quaternion.LookRotation(new Vector3(aux.x,0,aux.z));
        sim.GetComponent<Animator>().SetTrigger("kick");
        Debug.Log("kick! at " + sim.arm.transform.position);
        Debug.Log(ballRg.transform.gameObject.name);
        ballRg.AddExplosionForce(120, sim.transform.position - new Vector3(0,sim.transform.position.y,0), 5);

        timerDuration = 4;
        StartTimer();
    }

    public override void Interact(RaycastHit hit)
    {
        
    }

    public override void Update()
    {
        if (TimerEnded)
        {
            sim.changeState(previousState);
        }
    }
}