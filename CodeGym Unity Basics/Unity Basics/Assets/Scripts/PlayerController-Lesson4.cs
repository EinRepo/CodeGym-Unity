using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController_Lesson4 : MonoBehaviour
{
    //[SerializeField] private TargetEnum NextTarget;
    //[SerializeField] private DriveMode mode = DriveMode.Manual;
    //[SerializeField] private float speed;
    //[SerializeField] private float rotationSpeed;
    
    

    //// Update is called once per frame
    //void Update()
    //{
    //    if(mode == DriveMode.Automatic)
    //    {
    //        Vector3 targetPosition = GetTargetPosition();
    //        Vector3 direction = targetPosition - transform.position;
    //        direction.y = 0; // Ignore the y-component of the direction

    //        // Calculate the rotation needed to face the target
    //        Quaternion targetRotation = Quaternion.LookRotation(direction);

    //        // Rotate the player gradually towards the target rotation
    //        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    //        // Move the player towards the target position
    //        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    //    }
    //    else if(mode == DriveMode.Manual)
    //    {
    //        float horizontalInput = Input.GetAxisRaw("Horizontal");
    //        float verticalInput = Input.GetAxisRaw("Vertical");

    //        if (horizontalInput != 0 || verticalInput != 0)
    //        {
    //            // Calculate the direction the player is moving
    //            Vector3 direction = transform.forward * verticalInput;

    //            // Normalize the direction vector
    //            direction.Normalize();

    //            // Apply rotation based on horizontal input
    //            float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
    //            transform.Rotate(0, rotation, 0);

    //            // Move the player in the direction it is moving
    //            transform.position += direction * speed * Time.deltaTime;
    //        }
    //    }
    //}

    //private Vector3 GetTargetPosition()
    //{
    //    switch (NextTarget)
    //    {
    //        case TargetEnum.TopLeft:
    //            return new Vector3(-108, 0, 0);
    //        case TargetEnum.TopRight:
    //            return new Vector3(-108, 0, 120);
    //        case TargetEnum.BottomLeft:
    //            return new Vector3(0, 0, 0);
    //        case TargetEnum.BottomRight:
    //            return new Vector3(0, 0, 120);
    //        default:
    //            return transform.position;
    //    }

    //}
}

//public enum TargetEnum
//{
//    TopLeft,
//    TopRight,
//    BottomLeft,
//    BottomRight
//}

//public enum DriveMode
//{
//    Manual,
//    Automatic

//}