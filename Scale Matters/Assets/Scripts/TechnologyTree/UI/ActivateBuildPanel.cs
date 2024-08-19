using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateBuildPanel : MonoBehaviour
{
    public GameObject buildWindow;
    private bool isWindowOpen = false;

    public void OpenWindow()
    {
        if (!isWindowOpen)
        {
            RectTransform rectTransform = buildWindow.GetComponent<RectTransform>();
            LeanTween.moveY(rectTransform, 0f, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
                rectTransform.anchoredPosition = new Vector2(0, 0);
            });
            isWindowOpen = true;
            WorldStatusData.worldStatus = WorldStatusData.WorldStatuses.BUILD;
        }
        else
        {
            RectTransform rectTransform = buildWindow.GetComponent<RectTransform>();
            LeanTween.moveY(rectTransform, buildWindow.transform.position.y - buildWindow.GetComponent<RectTransform>().rect.height, 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() => {
                rectTransform.anchoredPosition = new Vector2(0, buildWindow.transform.position.y - buildWindow.GetComponent<RectTransform>().rect.height);
            });
            isWindowOpen = false;
            WorldStatusData.worldStatus = WorldStatusData.WorldStatuses.BASE;
        }
    }
}
