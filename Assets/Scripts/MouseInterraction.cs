using UnityEngine;

public class MouseInterraction : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.CompareTag("Hideout"))
                {
                    hit.transform.gameObject.GetComponent<Hideout>().Raising();
                }
            }
        }
    }
}