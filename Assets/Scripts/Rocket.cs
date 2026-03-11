using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class Rocket : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool _isThrusting;
    [SerializeField] private float _thrustForce = 21f;

    private Vector2 _inputVector;
    [SerializeField] private float _rotationSpeed = 21f; 

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (_isThrusting) {
            _rigidbody.AddRelativeForce(Vector3.up * _thrustForce, ForceMode.Acceleration);
        }

        _rigidbody.AddRelativeTorque(Vector3.forward * -_inputVector.x * _rotationSpeed, ForceMode.Acceleration);
    }

    void OnJump(InputValue value) {
        _isThrusting = value.isPressed;
    }

    void OnMove(InputValue value) {
        _inputVector = value.Get<Vector2>();
    }
}
