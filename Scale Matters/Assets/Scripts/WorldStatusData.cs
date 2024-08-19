using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStatusData : MonoBehaviour
{
    public enum WorldStatuses
    {
        BASE = 0,
        BUILD = 1
    }

    public static WorldStatuses worldStatus = WorldStatuses.BASE;
    public LayerMask[] layersToIgnore;

	private void Update()
    {
		//if (worldStatus == WorldStatuses.BASE)
		//{
		//	foreach (var layer in layersToIgnore)
		//	{
		//		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), layer - 256, false);
		//	}
		//}
		//else if (worldStatus == WorldStatuses.BUILD)
		//{
		//	foreach (var layer in layersToIgnore)
		//	{
		//		Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), layer - 256, true);
		//	}
		//}
	}
}
