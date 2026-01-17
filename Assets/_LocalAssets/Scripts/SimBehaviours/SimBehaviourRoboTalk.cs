using TMPro;
using UnityEngine;

public class SimBehaviourRoboTalk : SimBehaviourBase
{

    public TextMeshPro dialoguePrefab;
    private TextMeshPro dialogue;
    public string dialogueText;


    public SimBehaviourRoboTalk(TextMeshPro dialoguePrefab, string dialogueText)
    {
        this.dialoguePrefab = dialoguePrefab;
        
        this.dialogueText = dialogueText;
    }

    public override void Awake()
    {
        if (started) return;
        started = true;
        dialogue = Object.Instantiate(dialoguePrefab);
        dialogue.text = dialogueText;
        dialogue.transform.position = sim.transform.position + new Vector3(0,4,0);
        timerDuration = 8;
        StartTimer();
        dialogue.gameObject.SetActive(true);
    }

    public override void Update()
    {

        if (TimerEnded)
        {
            dialogue.gameObject.SetActive(false);
            sim.changeState(new SimBehaviourIdle(sim));
            started = false;

        }
    }
}