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
    //public GameObject selectorPrefab;
    //public GameObject targetPrefab;

    //private GameObject selectorObj, targetObj;
    //private CubeActor selectedCube = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //selectorObj = Instantiate(selectorPrefab);
        //selectorObj.SetActive(false);
        //targetObj = Instantiate(targetPrefab);
        //targetObj.SetActive(false);
        
    }

    // Update is called once per frame
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
        if (Input.GetMouseButtonDown(1))
        {
            //HandleRightMouseInput();
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
        
        //selectorObj.SetActive(false);
        //selectedCube = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            TryInteract(hit);
            
            ball.GetComponent<Rigidbody>().AddExplosionForce(120, hit.point, 10);
            
        }
    }

    //private void HandleRightMouseInput()
    //{
    //    //if (selectedCube == null)
    //    //{
    //    //    return;
    //    //}
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
    //    if (Physics.Raycast(ray, out RaycastHit hit)){
            
    //        if (hit.transform.gameObject.TryGetComponent<CubeActor>(out CubeActor actor))
    //        {
                
    //            if (actor == selectedCube) return;

    //            selectedCube.MoveTo(hit.transform.gameObject);
    //            //TryFighting(actor);
    //            return;
    //        }

    //        selectedCube.MoveTo(ray.origin + hit.distance * ray.direction.normalized + Vector3.up * 0.6f);
    //    }
    //}



    private void TryInteract(RaycastHit hit)
    {
        Debug.Log("Tocando " + hit.transform.name);
        
            sim.Interact(hit);

        
    }
}
