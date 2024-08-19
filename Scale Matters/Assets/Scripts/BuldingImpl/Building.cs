using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
	public enum BuildingType
	{
		RESIDENTIAL = 0,
		WORKING = 1
	}

	public BuildingType type;
	public int fullness;
	public int capacity;
}
