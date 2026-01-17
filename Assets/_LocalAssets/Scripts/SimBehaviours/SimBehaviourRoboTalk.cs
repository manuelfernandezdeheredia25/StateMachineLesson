using TMPro;
using UnityEngine;

public class SimBehaviourRoboTalk : SimBehaviourBase
{
    public string rutaTexto = "HoverText";
    protected TextMeshPro dialogue;
    public string dialogueText;


    public SimBehaviourRoboTalk(string dialogueText)
    {   
        this.dialogueText = dialogueText;
    }

    public SimBehaviourRoboTalk(string dialogueText, Sim sim)
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
        if(dialogue == null)
        {
            GameObject go = Object.Instantiate(Resources.Load(rutaTexto) as GameObject);
            dialogue = go.GetComponent<TextMeshPro>();
        }
        dialogue.text = dialogueText;
        dialogue.transform.position = sim.transform.position + new Vector3(-1,5,-1);
        timerDuration = 8;
        StartTimer();
        dialogue.gameObject.SetActive(true);
    }

    public override void Update()
    {
        if(Time.time - timerStart >= 2 )
        {
            IsInterrumpible = true;
        }

        if (TimerEnded)
        {
            sim.changeState(new SimBehaviourIdle(sim));
            started = false;

        }
    }

    public override void Asleep()
    {
        dialogue.gameObject.SetActive(false);
    }
}