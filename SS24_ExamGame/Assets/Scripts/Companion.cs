using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [Header("Movement")]
    public List<Transform> movePoints;
    [SerializeField] private float movementSpeed;
    private int nextMovementPoint = 0;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            isMoving = !isMoving;
        }
        if(isMoving)
        {
            MoveToNextPoint();
        }
    }

    private void MoveToNextPoint()
    {
        Vector3 direction = (movePoints[nextMovementPoint].position - transform.position).normalized;


        if(movePoints.Count > 0 && nextMovementPoint <= movePoints.Count - 1) 
        {
            transform.position += direction * Time.deltaTime * movementSpeed;

            if (Vector3.Distance(transform.position, movePoints[nextMovementPoint].position) < 0.1f)
            {
                transform.position = movePoints[nextMovementPoint].position;
                nextMovementPoint++;
                isMoving = !isMoving;
            }
        }
        
    }
}
