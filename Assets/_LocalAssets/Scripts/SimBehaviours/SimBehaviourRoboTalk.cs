using TMPro;
using UnityEngine;

public class SimBehaviourRoboTalk : SimBehaviourBase
{
    public string rutaTexto = "HoverText";
    protected TextMeshPro dialogue;
    public string dialogueText;


    public SimBehaviourRoboTalk(string dialogueText, ISimBehaviour nextState = null)
    {
        this.dialogueText = dialogueText;
        this.nextState = nextState;
    }

    public SimBehaviourRoboTalk(string dialogueText, Sim sim,ISimBehaviour nextState = null) : base(sim, nextState) 
    {
        this.dialogueText = dialogueText;
        this.sim = sim;
    }

    public SimBehaviourRoboTalk()
    {
    }

    public override void Awake()
    {
        if (started) return;
        started = true;
        if (dialogue == null)
        {
            GameObject go = Object.Instantiate(Resources.Load(rutaTexto) as GameObject);
            dialogue = go.GetComponent<TextMeshPro>();
        }
        dialogue.text = dialogueText;
        dialogue.transform.position = sim.transform.position + new Vector3(-1, 5, -1);
        timerDuration = 8;
        StartTimer();
        dialogue.gameObject.SetActive(true);
    }

    public override void Update()
    {
        if (Time.time - timerStart >= 2)
        {
            IsInterrumpible = true;
        }

        if (TimerEnded)
        {
            started = false;
            if (nextState != null)
            {
                sim.changeState(nextState);
                return;
            }
            sim.changeState(new SimBehaviourIdle(sim));
        }
    }

    public override void Asleep()
    {
        dialogue.gameObject.SetActive(false);
    }
}