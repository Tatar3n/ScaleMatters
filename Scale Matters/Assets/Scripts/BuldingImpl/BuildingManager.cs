using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public Tilemap tilemap;
    public LayerMask buildableLayer;
    public LayerMask constructionLayer;
    public GameObject actualPrefab;

	private void Start()
	{
        actualPrefab = buildingPrefabs[0];
    }

	public void FixedUpdate()
    {
        //Debug.Log("������� ����: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void OnMouseDown()
    {
        //Debug.Log("������� ����: " + Input.mousePosition);
        if(WorldStatusData.worldStatus == WorldStatusData.WorldStatuses.BUILD)
            Build(actualPrefab, tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
    }

    public bool CanBuildAt(Vector3Int cellPosition)
    {
        // �������� ��������
        if (Physics2D.OverlapBox(tilemap.GetCellCenterWorld(cellPosition), new Vector2(1, 1), 0, buildableLayer) 
            && !Physics2D.OverlapBox(tilemap.GetCellCenterWorld(cellPosition), new Vector2(1,3), 0, constructionLayer))
        {
            return true;
        }
        return false;
    }

    public void Build(GameObject buildingPrefab, Vector3Int cellPosition)
    {
        if (CanBuildAt(cellPosition))
        {
            GameObject buildingInstance = Instantiate(buildingPrefab, tilemap.GetCellCenterWorld(cellPosition) + new Vector3(0,1,0), Quaternion.identity);
            buildingInstance.transform.SetParent(tilemap.transform);
        }
    }
}
