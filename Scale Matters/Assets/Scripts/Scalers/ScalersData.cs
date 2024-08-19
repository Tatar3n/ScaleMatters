using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalersData : MonoBehaviour
{
	public GameObject scalerPrefab;
	public List<GameObject> scalers;
	private void Start()
	{
		for (int i = 0; i < 5; ++i)
		{
			GameObject newScaler = Instantiate(scalerPrefab);
			scalers.Add(newScaler);
		}
	}

	private void Update()
	{
		if (WorldStatusData.worldStatus == WorldStatusData.WorldStatuses.BASE)
		{
			foreach (var scaler in scalers)
			{
				scaler.GetComponent<BoxCollider2D>().enabled = true;
			}
		}
		else if (WorldStatusData.worldStatus == WorldStatusData.WorldStatuses.BUILD)
		{
			foreach (var scaler in scalers)
			{
				scaler.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
}

