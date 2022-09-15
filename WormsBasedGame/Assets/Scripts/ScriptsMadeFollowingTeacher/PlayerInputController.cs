using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    // THIS SCRIPT WAS MADE FOLLOWING A TEACHER DURING A LECTURE!!

    private CharacterController _characterController;
    private Vector2 _inputValue;
    private Vector3 _moveVector;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Weapon weapon;




    void Awake()
    {

        _characterController = GetComponent<CharacterController>();

    }

    
    void FixedUpdate()
    {

        _moveVector = new Vector3(_inputValue.x, 0, _inputValue.y);
        _characterController.Move(_moveVector);

    }

    public void Shoot(InputAction.CallbackContext context)
    {

        if (context.phase != InputActionPhase.Performed)
        {

            return;

        }

        weapon.Shoot();

    }

    public void Move(InputAction.CallbackContext context)
    {

        //Debug.Log("move");
        _inputValue = context.ReadValue<Vector2>() * _movementSpeed;


    }



}
