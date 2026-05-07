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
                //Souleve un cailloux
                if (hit.transform.gameObject.CompareTag("Hideout"))
                {
                    Hideout hideout = hit.transform.gameObject.GetComponent<Hideout>();
                    if (FishingManager.instance.isCurrentLanding)
                    {
                        FishingManager.instance.PlaceLanding(hideout); 
                        return;
                    }
                    
                    hideout.Raising();
                }
            }
        }
    }
}