using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WalkManager : MonoBehaviour
{
    public static WalkManager instance;

    public WalkData walkData;
    public float maxRotation = 45f;
    
    public Rigidbody objectToMove;
    public Transform bucketToRotate;
    
    [Header("Information")]
    public Direction currentDirection;
    public float currentRotation;
    public float timerChangeDirection;
    public float targetTimeChangeDirection;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("[WalkManager] More than one FishingManager in scene!");
            Destroy(gameObject);
        }
    }

    void ChangeDirection(Direction newDir)
    {
        currentDirection = newDir;
    }

    void Fall()
    {
            var rotation = bucketToRotate.rotation;

            if (Math.Abs(rotation.z) >= maxRotation  ) return;
            
            if (rotation.z == 0)
            {
                int randomInt = Random.Range(0, 2);
                if(randomInt == 0) currentDirection = Direction.right;
                else currentDirection = Direction.left;
            }
            else if (rotation.z > 0)
            {
                currentDirection = Direction.right;
            }
            else if (rotation.z < 0)
            {
                currentDirection = Direction.left;
            }
            
            if (currentDirection == Direction.right)
            {
                rotation.z += walkData.rotationIntensity;
            }
            else
            {
                rotation.z -= walkData.rotationIntensity;

            }
            
            bucketToRotate.rotation = rotation;
    }

    void Raise(Direction newDir)
    {
        if (newDir == Direction.right)
        {
            var rotation = bucketToRotate.rotation;
            rotation.z += walkData.playerIntensity;
            bucketToRotate.rotation = rotation;
        }
        else
        {
            var rotation = bucketToRotate.rotation;
            rotation.z -= walkData.playerIntensity;
            bucketToRotate.rotation = rotation;
        }
    }

    void Update()
    {
        Fall();
        currentRotation = bucketToRotate.transform.localRotation.eulerAngles.z;
        
        Debug.Log(currentRotation);
        
        if(currentRotation < 1) currentRotation = 1;
        var vector3 = objectToMove.transform.position;
        vector3.z =- walkData.speed;
        objectToMove.transform.position = vector3;
        //objectToMove.AddForce(new Vector3(0,0,-(walkData.speed / Math.Abs(currentRotation)) ), ForceMode.Force);
        
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Raise(Direction.left);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Raise(Direction.right);
        }
    }
}

public enum Direction
{
    left,
    right
}
