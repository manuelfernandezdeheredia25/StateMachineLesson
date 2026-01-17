using UnityEngine;

internal class SimBehaviourBall : SimBehaviourBase
{
    GameObject ball;
    GameObject coin;
    GameController gameController;

    public SimBehaviourBall(GameObject ball)
    {
        this.ball = ball;
        coin = GameObject.FindGameObjectWithTag("coin");
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        gameController = go.GetComponent<GameController>();
    }

    public override void Awake()
    {
        IsInterrumpible = true;
        gameController.moveBall = true;
        coin.GetComponent<Interactable>().enabled = true;
        sim.changeState(new SimBehaviourKick(sim, ball.GetComponent<Rigidbody>(), new SimBehaviourRoboTalk("FUNNY  ^_^", sim)));
    }

    public override void Update()
    {
       
    }
}