using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public GameObject actionButtonsPrefab; 
    private GameObject actionButtonsInstance; 
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        HideActionButtons();
    }

    private void OnMouseDown()
    {
        ShowActionButtons();
    }

    private void OnMouseExit()
    {
        HideActionButtons();
    }

    private void ShowActionButtons()
    {
        if (actionButtonsInstance == null)
        {
            actionButtonsInstance = Instantiate(actionButtonsPrefab);
            actionButtonsInstance.transform.SetParent(mainCamera.transform, false);
            PositionActionButtons();
        }
        actionButtonsInstance.SetActive(true);
    }

    private void HideActionButtons()
    {
        if (actionButtonsInstance != null)
            actionButtonsInstance.SetActive(false);
    }

    private void PositionActionButtons()
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        actionButtonsInstance.transform.position = screenPosition + new Vector3(0, 50, 0); 
    }
}
