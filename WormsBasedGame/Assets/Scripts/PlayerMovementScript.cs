using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //USED FOR MOVING
    [SerializeField] float movementSpeed;
    [SerializeField] float smoothInputSpeed;
    Vector3 playerPosition;
    Vector2 input;
    Vector2 currentInput;
    Vector2 velocity;

    MyInputManager myInputManager;

    void Awake()
    {
        myInputManager = new MyInputManager();


    }

   
    void Update()
    {
        MoveCharacterWithKeyboard();
    }

    void MoveCharacterWithKeyboard()
    {
        input = myInputManager.PlayerControlls.Movement.ReadValue<Vector2>();
        currentInput = Vector2.SmoothDamp(currentInput, input, ref velocity, smoothInputSpeed);
        playerPosition = new Vector3(currentInput.x, 0, currentInput.y);
        transform.position += playerPosition * movementSpeed * Time.deltaTime;

    }

    private void OnEnable()
    {

        myInputManager.Enable();

    }

    private void OnDisable()
    {

        myInputManager.Disable();

    }

}
