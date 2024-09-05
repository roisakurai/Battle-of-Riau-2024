using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isInsideTrigger = false;

    private Rigidbody weaponRigidbody;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        weaponRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isInsideTrigger)
        {
            ReturnToInitialTransform();
        }
    }

    private void ReturnToInitialTransform()
    {
        transform.SetPositionAndRotation(initialPosition, initialRotation);
        weaponRigidbody.velocity = Vector3.zero;
        weaponRigidbody.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Weapon Border")
        {
            isInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Weapon Border")
        {
            isInsideTrigger = false;
        }
    }
}
