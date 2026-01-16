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
             case interactTypes.tree:
                interactingBehaviour = new SimBehaviourTree();
                break;
             case interactTypes.coin:
                interactingBehaviour = new SimBehaviourCoin();
                break;
             case interactTypes.bench:
                interactingBehaviour = new SimBehaviourBench();
                break;
            case interactTypes.robo:
                interactingBehaviour = new SimBehaviourRobo();
                break;
            case interactTypes.axe:
                interactingBehaviour = new SimBehaviourAxe();
                break;



        }


    }
    private void Update()
    {
        hoverText.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseEnter()
    {
       hoverText.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        hoverText.gameObject.SetActive(false);
    }
}
