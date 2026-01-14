using UnityEngine;

public class Sim : MonoBehaviour
{
    public ISimBehaviour simBehaviour;

    public float speed = 0.5f;
    public float minDistance = 2f;
    public GameObject[] walkingPoints;

    private void Awake()
    {
        simBehaviour = new SimBehaviourIdle(this);
        simBehaviour.Awake();
    }

    public void changeState(ISimBehaviour behaviour)
    {
        simBehaviour = behaviour;
        simBehaviour.Awake();
    }

    public void moveTo()  // Por implementar 
    {

    }

    public void Interact(RaycastHit hit)  // Por implementar 
    {
        simBehaviour.Interact(hit);
    }

    void Update()
    {
        simBehaviour.Update();
    }
}
