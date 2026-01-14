using UnityEngine;

public interface ISimBehaviour
{
    void Awake();

    void Update();

    void Interact(RaycastHit hit);
}
