using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Companion : MonoBehaviour
{
    [Header("Movement")]
    public List<Transform> movePoints;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private int nextMovementPoint = 0;
    public bool moveToNextPos = false;
    private bool isWaiting = false;
    [SerializeField] private float WaitForNextMoveStart = 6f;
    [SerializeField] private float WaitForNextMoveEnd = 8f;

    private bool isPlayingAnimation = false;
    private Animator animator;

    public bool grabbedRightObject = false;


    // Start is called before the first frame update
    void Start()
    {
        isWaiting = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveToNextPos)
        {
            MoveToNextPoint();
        } else if(!moveToNextPos && isWaiting)
        {
            StartCoroutine(MovementTimeout());
        } else if(!moveToNextPos && !isWaiting) 
        {
            LookAtPlayer();
        }

        if(nextMovementPoint >= movePoints.Count)
        {
            nextMovementPoint = 0;
        }

        if(grabbedRightObject)
        {
            StartCoroutine(PickedRightObject());
        }
    }

    private void MoveToNextPoint()
    {
        Vector3 direction = (movePoints[nextMovementPoint].position - transform.position).normalized;
        animator.SetInteger("AnimationInt", 3);

        if(movePoints.Count > 0 && nextMovementPoint <= movePoints.Count - 1) 
        {
            transform.position += direction * Time.deltaTime * movementSpeed;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (Vector3.Distance(transform.position, movePoints[nextMovementPoint].position) < 0.1f)
            {
                transform.position = movePoints[nextMovementPoint].position;
                nextMovementPoint++;
                animator.SetInteger("AnimationInt", 2);
                moveToNextPos = !moveToNextPos;
                isWaiting = true;
            }
        }
        
    }

    private void LookAtPlayer() {
        Vector3 lookAtPlayerDirection = Camera.main.transform.position - transform.position;
        Quaternion lookAtPlayerRotation = Quaternion.LookRotation(lookAtPlayerDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookAtPlayerRotation, Time.deltaTime * 2f);
    }

    public void StartMovement()
    {
        moveToNextPos = true;
    }

    private IEnumerator MovementTimeout()
    {
        isWaiting = false;
        float delay = Random.Range(WaitForNextMoveStart, WaitForNextMoveEnd);
        yield return new WaitForSeconds(delay);
        StartMovement();
    }
    public IEnumerator PickedRightObject()
    {
        isPlayingAnimation = true;
        moveToNextPos = false;
        isWaiting = false;
        grabbedRightObject = false;

        
        animator.SetInteger("AnimationInt", 5);
        
        //float animationDuration = animator.GetCurrentAnimatorStateInfo(5).length;
        float animationDuration = 4f;
        yield return new WaitForSeconds(animationDuration);

        isPlayingAnimation = false;
        moveToNextPos = true; 
        
    }
}
