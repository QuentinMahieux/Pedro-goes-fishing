using UnityEngine;

public class FishIA : MonoBehaviour
{
    public static FishIA instance;

    public Rigidbody rb;

    public bool isMove = false;
    public Vector3 target;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("[FishIA] More than one FishingManager in scene!");
            Destroy(gameObject);
        }
    }

    public void Move(Vector3 newTarget)
    {
        isMove = true;
        target = newTarget;
    }

    void FixedUpdate()
    {
        if (!isMove) return;
        
        float distance = Vector3.Distance(transform.position, target);
        Vector3 direction = (target - rb.position).normalized;
        rb.MovePosition(rb.position + direction * (FishingManager.instance.fishData.speed * Time.fixedDeltaTime));

        if (distance <= 0.1f)
        {
            isMove = false;
            FishingManager.instance.NewHideout();
        }
    }
}
