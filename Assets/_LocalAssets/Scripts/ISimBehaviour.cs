using UnityEngine;

public interface ISimBehaviour
{
    bool IsInterrumpible { get; set; }
    void Awake();

    void Asleep();

    void Update();

    void Interact(RaycastHit hit);
}
