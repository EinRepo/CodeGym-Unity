using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TargetEnum NextTarget;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = GetTargetPosition();
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0; // Ignore the y-component of the direction
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
    }

    private Vector3 GetTargetPosition()
    {
        switch (NextTarget)
        {
            case TargetEnum.TopLeft:
                return new Vector3(-108, 0, 0);
            case TargetEnum.TopRight:
                return new Vector3(-108, 0, 120);
            case TargetEnum.BottomLeft:
                return new Vector3(0, 0, 0);
            case TargetEnum.BottomRight:
                return new Vector3(0, 0, 120);
            default:
                return transform.position;
        }

    }
}

public enum TargetEnum
{
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}
