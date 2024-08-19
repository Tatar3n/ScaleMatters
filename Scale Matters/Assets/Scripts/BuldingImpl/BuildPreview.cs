using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildPreview : MonoBehaviour
{
    public GameObject[] previewObject;
    public Tilemap tilemap;
    public LayerMask buildableLayer;
    public LayerMask constructionLayer;
    public GameObject actualPreviewObject;

    private Vector3Int lastTilePosition = new Vector3Int(100,100,100);

	private void Start()
	{
        actualPreviewObject = previewObject[0];
	}

	public void OnMouseOver()
    {
        if (WorldStatusData.worldStatus == WorldStatusData.WorldStatuses.BUILD)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(mousePos);

            if (cellPosition != lastTilePosition)
            {
                lastTilePosition = cellPosition;

                GameObject[] previews = GameObject.FindGameObjectsWithTag("PreviewObject");
                foreach (GameObject preview in previews)
                {
                    Destroy(preview);
                }

                if (Physics2D.OverlapBox(tilemap.GetCellCenterWorld(cellPosition), new Vector2(1, 1), 0, buildableLayer)
                    && !Physics2D.OverlapBox(tilemap.GetCellCenterWorld(cellPosition), new Vector2(1, 3), 0, constructionLayer))
                {
                    GameObject preview = Instantiate(actualPreviewObject, tilemap.GetCellCenterWorld(cellPosition) + new Vector3(0, 1, 0), Quaternion.identity);
                    preview.SetActive(true);
                }
            }
        }
    }
    public void OnMouseExit()
    {
        if (WorldStatusData.worldStatus == WorldStatusData.WorldStatuses.BUILD)
        {
            GameObject[] previews = GameObject.FindGameObjectsWithTag("PreviewObject");
            foreach (GameObject preview in previews)
            {
                Destroy(preview);
            }
        }
    }
}
