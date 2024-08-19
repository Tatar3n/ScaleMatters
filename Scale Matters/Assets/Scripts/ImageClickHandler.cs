using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ImageClickHandler : MonoBehaviour
{
    public BuildingManager buildingScript;
    public BuildPreview previewScript;
    public BuildingMenuButtonData data;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnImageClick);
    }

    public void OnImageClick()
    {
        buildingScript.actualPrefab = data.localPrefab;
        previewScript.actualPreviewObject = data.localPreviewPrefab;
    }
}
