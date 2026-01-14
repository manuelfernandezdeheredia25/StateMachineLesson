using UnityEngine;

public class SimBehaviourWalking : SimBehaviourBase
{
    int count = 0;

    public SimBehaviourWalking(Sim sim) : base(sim)
    {
    }

    public override void Awake()
    {
        timeStart = Time.time;
    }

    public override void Interact(RaycastHit hit)
    {
        
    }

    public override void Update()
    {  
       sim.transform.position = Vector3.MoveTowards(sim.transform.position, sim.walkingPoints[count].transform.position, sim.speed*0.5f * Time.deltaTime);
       sim.transform.rotation = Quaternion.LookRotation(sim.walkingPoints[count].transform.position - sim.transform.position);

        if (Vector3.Distance(sim.transform.position, sim.walkingPoints[count].transform.position) < 0.01f)
       {
          count++;
       }
       if(count>= sim.walkingPoints.Length){
          Debug.Log("Cambio Estado --> Idle " + Time.time);
          sim.changeState(new SimBehaviourIdle(sim));
       }
    }
        
       
        
    }

