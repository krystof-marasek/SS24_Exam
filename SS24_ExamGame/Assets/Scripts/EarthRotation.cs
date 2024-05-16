using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    private Transform earth;

    public float rotationSpeed = 0.3f;

    private void Start()
    {
        earth = GetComponent<Transform>();
    }

    public void FixedUpdate()
    {
        earth.Rotate(new Vector3(0, rotationSpeed, 0), Space.World);
    }
}
