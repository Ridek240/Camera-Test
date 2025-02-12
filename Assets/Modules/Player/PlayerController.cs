using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    public Vector2 MovementVector;
    public Vector2 CursorVector;
    public GameObject Cursor;
    public bool ControllerConected;

    public static GameObject Player;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Player = gameObject;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is Gamepad)
        {
            if (change == InputDeviceChange.Added)
                ControllerConected = true;
            else if (change == InputDeviceChange.Removed)
                ControllerConected = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction;
        Vector3 worldPosition;
        
        /*float xMovement = rigidbody.linearVelocity.x;
        float yMovement = rigidbody.linearVelocity.z;
        if (rigidbody.linearVelocity.x * MovementVector.y < 0 && Math.Abs(rigidbody.linearVelocity.x) > 10f)
        {
            xMovement = rigidbody.linearVelocity.x + MovementVector.y*10;
            Debug.Log("A");
        }
        if (rigidbody.linearVelocity.z * (-MovementVector.x) < 0 && Math.Abs(rigidbody.linearVelocity.z)>10f)
        {
             yMovement = rigidbody.linearVelocity.z + -MovementVector.x*10;
            Debug.Log("B");
        }
        if(new Vector2(xMovement, yMovement).magnitude <MovementVector.magnitude*10) 
        {
            xMovement = MovementVector.y * 10;
            yMovement = MovementVector.x * -10;
            Debug.Log("C");
        }*/
        
        rigidbody.linearVelocity = (new Vector3(MovementVector.y, rigidbody.linearVelocity.y, -MovementVector.x)*10);
        //rigidbody.linearVelocity = (new Vector3(xMovement, rigidbody.linearVelocity.y, yMovement));
        if(!ControllerConected)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            direction = worldPosition - transform.position;
        }
        else
        {
            direction = new Vector3(CursorVector.x, 0, CursorVector.y);
            worldPosition = transform.position + new Vector3(CursorVector.x, 0, CursorVector.y);
        }
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle, 0);
        worldPosition.y = 0f;
        Cursor.transform.position = (worldPosition);
    }
    public void OnSprint()
    {
        rigidbody.AddForce(new Vector3(MovementVector.y, 0, -MovementVector.x )* 200f);
        Debug.Log("Force added");
    }


    public void OnMove(InputValue value)
    {
        MovementVector = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        CursorVector = value.Get<Vector2>();
        
    }


}
