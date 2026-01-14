using UnityEngine;

public class Interactable : MonoBehaviour
{
    public SimBehaviourBase interactingBehaviour;

  public enum interactTypes
    {
        lamp,
        ball,
        tree,
        coin,
        bench,
        bush,
    }
    public interactTypes interactable;

    public void Awake()
    {
        switch (interactable)
        {
            case interactTypes.lamp:
                interactingBehaviour = new SimBehaviourLamp();
                break;
             case interactTypes.ball:
                break;

        }
        
    }
}
