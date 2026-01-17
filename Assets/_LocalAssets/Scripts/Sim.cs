using UnityEngine;

public class Sim : MonoBehaviour
{
    public ISimBehaviour simBehaviour;

    public float speed = 0.5f;
    public float minDistance = 2f;
    public float kickStrength = 120f;
    public GameObject[] walkingPoints;
    public GameObject arm;

   

    private void Awake()
    {
        simBehaviour = new SimBehaviourIdle(this);
        simBehaviour.Awake();
    }

    public void changeState(ISimBehaviour behaviour)
    {
        Debug.Log("Changing state to: " + behaviour.ToString());
        simBehaviour.Asleep();
        simBehaviour = behaviour;
        simBehaviour.Awake();
    }

    public void moveTo()  // Por implementar 
    {

    }

    public void BecomeInterrumpible()
    {
        simBehaviour.IsInterrumpible = true;
    }
    public void Interact(RaycastHit hit)
    {
        simBehaviour.Interact(hit);
    }

    void Update()
    {
        simBehaviour.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("chocando con " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("ball") && simBehaviour.IsInterrumpible)
        {
            collision.rigidbody.ResetInertiaTensor();
            changeState(new SimBehaviourKick(this, collision.rigidbody, simBehaviour));
        }
    }
}
