using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Companion : MonoBehaviour
{
    [Header("Movement")]
    public List<Transform> movePoints;
    [SerializeField] private float movementSpeed;
    private int nextMovementPoint = 0;
    public bool moveToNextPos = false;
    public UnityEvent hasMoved = new UnityEvent();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if(moveToNextPos)
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
                moveToNextPos = !moveToNextPos;
                hasMoved.Invoke();
            }
        }
        
    }

    public void StartMovement()
    {
        moveToNextPos = true;
    }
}
