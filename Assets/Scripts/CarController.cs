using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Components")]
    public WheelColliders wheelColliders;
    public WheelMeshes wheelMeshes;
    private Rigidbody carRigidbody;

    [Header("Car settings")]
    public float motorPower;
    public float wheelRotationAngle = 40f;
    private readonly float gasInput = 1f;
    private float steeringInput;

    private void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckInput();
        ApplyMotor();
        ApplySteering();
        ApplyWheelPositionsAndRotation();
    }

    void CheckInput()
    {
        steeringInput = Input.GetAxis("Horizontal");
    }

    void ApplyMotor()
    {
        wheelColliders.FLWheel.motorTorque = motorPower * gasInput;
        wheelColliders.FRWheel.motorTorque = motorPower * gasInput;
        wheelColliders.RLWheel.motorTorque = motorPower * gasInput;
        wheelColliders.RRWheel.motorTorque = motorPower * gasInput;
    }

    private void ApplySteering()
    {
        float steeringAngle = steeringInput * wheelRotationAngle;
        wheelColliders.FLWheel.steerAngle = steeringAngle;
        wheelColliders.FRWheel.steerAngle = steeringAngle;
    }

    void ApplyWheelPositionsAndRotation()
    {
        UpdateWheel(wheelColliders.FLWheel, wheelMeshes.FLWheel);
        UpdateWheel(wheelColliders.FRWheel, wheelMeshes.FRWheel);
        UpdateWheel(wheelColliders.RLWheel, wheelMeshes.RLWheel);
        UpdateWheel(wheelColliders.RRWheel, wheelMeshes.RRWheel);
    }

    void UpdateWheel(WheelCollider collider, MeshRenderer mesh)
    {
        Quaternion quaternion;
        Vector3 position;
        collider.GetWorldPose(out position, out quaternion);
        mesh.transform.position = position;
        mesh.transform.rotation = quaternion;
    }
}

[System.Serializable]
public class WheelMeshes
{
    public MeshRenderer FRWheel;
    public MeshRenderer FLWheel;
    public MeshRenderer RRWheel;
    public MeshRenderer RLWheel;
}

[System.Serializable]
public class WheelColliders
{
    public WheelCollider FRWheel;
    public WheelCollider FLWheel;
    public WheelCollider RRWheel;
    public WheelCollider RLWheel;
}