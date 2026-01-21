using TMPro;
using UnityEngine;

public class SimBehaviourRoboTalkSitting : SimBehaviourRoboTalk
{
    public SimBehaviourRoboTalkSitting(string dialogueText)
    {
        this.dialogueText = dialogueText;
    }

    public SimBehaviourRoboTalkSitting(string dialogueText, Sim sim) : base()
    {
        this.dialogueText = dialogueText;
        this.sim = sim;
    }

    public override void Awake()
    {
        sim.transform.position = new Vector3(sim.transform.position.x, 1.5f, sim.transform.position.z);
        base.Awake();
    }

    public override void Asleep()
    {
        dialogue.gameObject.SetActive(false);
        sim.transform.position = new Vector3(sim.transform.position.x, 0, sim.transform.position.z);
    }
}