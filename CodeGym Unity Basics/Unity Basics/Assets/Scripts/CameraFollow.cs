using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float distance;
    [SerializeField] private float height;
    

    // Update is called once per frame
    void LateUpdate()
    {
        // Get the player's position
        Vector3 targetPosition = Player.transform.position;

        // Calculate the desired position behind the player
        Vector3 back = -Player.transform.forward * distance;
        
        

        transform.position = targetPosition + back + height * Vector3.up;  
        

        // Look at the PLAYER
        transform.LookAt(targetPosition);




    }

}
