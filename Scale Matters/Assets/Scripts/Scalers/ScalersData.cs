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
}

