using System.Collections.Generic;
using UnityEngine;



public class GridVisualizer
{
	private readonly Dictionary<int, Material> colorMaterials;
	private readonly int windowSize;
	private readonly float cubeSpacing;
	private readonly GridData gridData;
	private readonly GameObject[,] cubeObjects;

	public GridVisualizer(Dictionary<int, Material> colorMaterials, GridSettings parameters, GridData gridData, GameObject[,] cubeObjects)
	{
		this.colorMaterials = colorMaterials;
		this.windowSize = parameters.WindowSize;
		this.cubeSpacing = parameters.CubeSpacing;
		this.gridData = gridData;
		this.cubeObjects = cubeObjects;
	}

	public void UpdatePosition()
	{
		var halfWindow = windowSize / 2;

		for (var localY = 0; localY < windowSize; localY++)
		{
			for (var localX = 0; localX < windowSize; localX++)
			{
				var cube = cubeObjects[localX, localY];
				cube.transform.localPosition = new Vector3((localX - halfWindow) * cubeSpacing, 0, (localY + halfWindow) * cubeSpacing);
			}
		}
	}
	
	public void UpdateVisualization(Vector2Int visualCenter)
	{
		var halfWindow = windowSize / 2;

		for (var localY = 0; localY < windowSize; localY++)
		{
			for (var localX = 0; localX < windowSize; localX++)
			{
				var x = visualCenter.x - halfWindow + localX;
				var y = visualCenter.y - halfWindow + localY;
				var digit = gridData.GetValueWrapped(x, y);
				var renderer = cubeObjects[localX, localY].GetComponent<Renderer>();

				renderer.material = colorMaterials.ContainsKey(digit)
					? colorMaterials[digit]
					: colorMaterials[1];
			}
		}
	}
}