using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [Header("Camera")]
    public float cameraPanSpeed = 0.01f;
    public float zoomSpeed = 0.01f, maxZoom = 20f, minZoom = 4f;
    public float minX = -16f, minY = -23f, maxX = 2f, maxY = -3f;

    [Header("Prefabs")]
    public Sim sim;
    public GameObject ball;

    public bool moveBall = false;

    void Update()
    {
        HandleMouseInput();
    }


    private void HandleMouseInput()
    {
        
        if (Input.GetMouseButtonDown(0))
        {   
            HandleLeftMouseInput();
            
        }

        if (Input.GetMouseButton(2))
        {
            HandleMiddleMouseInput();
        }
        HandleMouseScrollInput();
     
    }

    private void HandleMouseScrollInput()
    {
        
        (float dx,float dy) = (Input.mouseScrollDelta.x, Input.mouseScrollDelta.y);
        float newScroll = Camera.main.orthographicSize - dy * zoomSpeed * Time.deltaTime;
        Camera.main.orthographicSize = Mathf.Clamp(newScroll, minZoom, maxZoom);

    }

    private void HandleMiddleMouseInput()
    {
        (float dx, float dy, float dz) = (Input.mousePositionDelta.x, Input.mousePositionDelta.y, Input.mousePositionDelta.z);
        Camera.main.transform.position += (dx*new Vector3(-1,0,1).normalized + dy * new Vector3(-1, 0, -1).normalized) * cameraPanSpeed;
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(Mathf.Clamp(camPos.x, minX, maxX), camPos.y, Mathf.Clamp(camPos.z, minY, maxY));
    }

    private void HandleLeftMouseInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            TryInteract(hit);

            if (moveBall) { 
            ball.GetComponent<Rigidbody>().AddExplosionForce(120, hit.point, 5);
            }
        }
    }

    private void TryInteract(RaycastHit hit)
    {
        Debug.Log("Tocando " + hit.transform.name);
        
            sim.Interact(hit);
    }
}
