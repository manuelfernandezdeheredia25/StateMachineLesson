using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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
        robo,
        axe
    }
    public interactTypes interactable;
    public TextMeshPro hoverTextPrefab;
    private TextMeshPro hoverText;
    public void Awake()
    {
        hoverText = Instantiate(hoverTextPrefab);
        hoverText.gameObject.SetActive(false);
        hoverText.text = interactable.ToString();

        switch (interactable)
        {
            case interactTypes.lamp:
                interactingBehaviour = new SimBehaviourLamp(this.gameObject);
                break;
            case interactTypes.ball:
                interactingBehaviour = new SimBehaviourBall(this.gameObject);
                break;
            case interactTypes.tree:
                //interactingBehaviour = new SimBehaviourTree();
                interactingBehaviour = new SimBehaviourRoboTalk("LOT OF WOOD");
                break;
             case interactTypes.coin:
                interactingBehaviour = new SimBehaviourRoboTalk("MONEY MONEY  @_@");
                break;
             case interactTypes.bench:
                interactingBehaviour = new SimBehaviourBench(this.gameObject);
                break;
            case interactTypes.robo:
                interactingBehaviour = new SimBehaviourRoboTalk("BIP BOP  <| º_º|>");
                break;
            case interactTypes.axe:
                //interactingBehaviour = new SimBehaviourAxe();
                interactingBehaviour = new SimBehaviourRoboTalk("DANGEROUS");
                break;
        }
    }
    private void Update()
    {
        hoverText.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseEnter()
    {
        if (this.isActiveAndEnabled)
        {
            hoverText.gameObject.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        if (this.isActiveAndEnabled)
        {
            hoverText.gameObject.SetActive(false);
        }
    }
}
