using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureManager : MonoBehaviour
{
    private CaptureData captureData;
    public List<Target> levelTargets;
    public Slider slider;
    public Transform targetValeuTransform;
    public Transform targetParent;
    public GameObject targetPrefab;

    public void Instanciat()
    {
        captureData = GameManager.instance.days[GameManager.instance.currentDay].captureData;
      
        StopAllCoroutines();
        slider.maxValue = captureData.timeTotal;
        StartCoroutine(CaptureAvencement());

        foreach (Target target in levelTargets)
        {
            Destroy(target.targetObject);
        }
        
        levelTargets.Clear();
        foreach (Target target in captureData.targets)
        {
            levelTargets.Add(new Target());
            levelTargets[^1].timeTarget = target.timeTarget;
            levelTargets[^1].WindowTarget = target.WindowTarget;
            
            slider.value =  target.timeTarget;
            GameObject newTarget = Instantiate(targetPrefab, targetValeuTransform.position, targetValeuTransform.rotation,  targetParent);
            newTarget.transform.localScale = new Vector3((target.WindowTarget/captureData.timeTotal), newTarget.transform.localScale.y, newTarget.transform.localScale.z);
            
            levelTargets[^1].targetObject = newTarget;
        }
        slider.value = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TouchePress(slider.value);
        }
    }

    void TouchePress(float value)
    {
        foreach (Target target in levelTargets)
        {
            if (target.timeTarget - (target.WindowTarget/2) <= value &&
                target.timeTarget + (target.WindowTarget/2) >= value)
            {
                target.targetObject.SetActive(false);
                levelTargets.Remove(target);
                return;
            }
        }
        GameManager.instance.CaptureToFishing();
    }

    void Win()
    {
        if (levelTargets.Count == 0)
        {
            Debug.Log("Win");
        }
        else
        {
            GameManager.instance.CaptureToFishing();
        }
    }

    IEnumerator CaptureAvencement()
    {
        while (slider.value < slider.maxValue)
        {
            slider.value += 0.001f;
            yield return new WaitForSeconds(0.001f);
        }
        Win();
    }
}
