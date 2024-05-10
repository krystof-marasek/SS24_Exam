using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    private Transform earth;

    public float rotationSpeed = 0.4f;

    private void Start()
    {
        earth = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        earth.Rotate(new Vector3(0, rotationSpeed, 0), Space.World);
    }
}
