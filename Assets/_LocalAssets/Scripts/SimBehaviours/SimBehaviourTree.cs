using UnityEngine;

public class SimBehaviourTree : SimBehaviourBase
{
    private GameObject gameObject;
    float freq = 20f, amp = 3;
    public SimBehaviourTree(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public override void Awake()
    {
        //sim.changeState(new SimBehaviourRoboTalk("LOT OF WOOD",this));
        IsInterrumpible = true;
        sim.GetComponent<Animator>().SetTrigger("moveTree");
        Debug.Log("moveTree! at " + sim.arm.transform.position);
        
        timerDuration = 2;
        StartTimer();

    }


    public override void Update()
    {

        if (!TimerEnded)
        {
            gameObject.transform.rotation = Quaternion.Euler(-90 + amp * Mathf.Sin(Time.time * freq), 0, 0);
            return;
        }
        Rigidbody[] AppleRgs = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody item in AppleRgs)
        {
            item.useGravity = true;
            item.excludeLayers = default;
            item.transform.SetParent(null);
        }
    }
}