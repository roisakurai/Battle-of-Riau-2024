using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour
{
    public static CannonController instance;
    public Transform cannonBody;
    public Transform cannonWheel;
    public Transform shotPoint;
    public ParticleSystem smokeEffect;
    public GameObject cannonballPrefab;
    public LineRenderer aimProjectionLine;
    public int numAimProjectionPoints = 100;
    public float aimProjectionDistance = 0f;

    private float currentRotationX = 0f;
    private float currentRotationY = 0f;
    private float lastFireTime = 0f;
    private AudioSource audioSource;

    private float rotationSpeed => VariableManager.instance.rotationSpeed;
    private float maxRotationX => VariableManager.instance.maxRotationX;
    private float minRotationX => VariableManager.instance.minRotationX;
    private float maxRotationY => VariableManager.instance.maxRotationY;
    private float minRotationY => VariableManager.instance.minRotationY;
    private float cannonballForce => VariableManager.instance.cannonballForce;
    public float fireCooldown => VariableManager.instance.fireCooldown;
    private float cannonballLifetime => VariableManager.instance.cannonballLifetime;

    void Start()
    {
        instance = this;
        InitializeAimProjectionLine();
        audioSource = GetComponent<AudioSource>();
    }

    void InitializeAimProjectionLine()
    {
        aimProjectionLine.positionCount = numAimProjectionPoints;
        aimProjectionLine.startWidth = 0.1f;
        aimProjectionLine.endWidth = 0.1f;
    }

    void Update()
    {
        RotateCannon();
        HandleInput();
        UpdateAimProjectionLine();
    }

    void UpdateAimProjectionLine()
    {
        Vector3 fireDirection = cannonBody.forward;
        Vector3 shotPointPosition = shotPoint.position;

        for (int i = 0; i < numAimProjectionPoints; i++)
        {
            float t = i / (float)(numAimProjectionPoints - 1);
            Vector3 pointPosition = shotPointPosition + fireDirection * aimProjectionDistance * t;

            float time = t * cannonballLifetime;
            Vector3 displacement = cannonballForce * time * fireDirection + 0.5f * time * time * Physics.gravity;
            pointPosition += displacement;

            aimProjectionLine.SetPosition(i, pointPosition);
        }
    }

    void RotateCannon()
    {
        float rotationInputHorizontal = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
        float rotationInputVertical = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");

        float rotationAmountHorizontal = rotationInputHorizontal * rotationSpeed * Time.deltaTime;
        float rotationAmountVertical = rotationInputVertical * rotationSpeed * Time.deltaTime;

        currentRotationX = Mathf.Clamp(currentRotationX - rotationAmountVertical, minRotationX, maxRotationX);
        currentRotationY = Mathf.Clamp(currentRotationY + rotationAmountHorizontal, minRotationY, maxRotationY);

        cannonBody.localEulerAngles = new Vector3(currentRotationX, 0, 0);
        cannonWheel.localEulerAngles = new Vector3(0, currentRotationY, 0);
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastFireTime >= fireCooldown)
        {
            ShootCannonball();
        }
    }

    public void ShootCannonball()
    {
        GameObject cannonballInstance = Instantiate(cannonballPrefab, shotPoint.position, Quaternion.identity);

        if (cannonballInstance != null)
        {
            Rigidbody cannonballRigidbody = cannonballInstance.GetComponent<Rigidbody>();
            if (cannonballRigidbody != null)
            {
                Vector3 fireDirection = cannonBody.forward;
                cannonballRigidbody.velocity = fireDirection * cannonballForce;
            }

            lastFireTime = Time.time;

            StartCoroutine(ReturnCannonballToPool(cannonballInstance));
        }

        audioSource.Play();
        smokeEffect.Play();
    }

    private IEnumerator ReturnCannonballToPool(GameObject cannonballInstance)
    {
        yield return new WaitForSeconds(cannonballLifetime);
        Destroy(cannonballInstance);
    }
}
