using UnityEngine;

public static class GridCubeFactory
{
	public static GameObject[,] CreateCubeGrid(Transform parent, GridSettings parameters)
	{
		var cubes = new GameObject[parameters.WindowSize, parameters.WindowSize];

		for (var y = 0; y < parameters.WindowSize; y++)
		{
			for (var x = 0; x < parameters.WindowSize; x++)
			{
				var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.parent = parent;
				cube.transform.localScale = Vector3.one * parameters.CubeSize;
				cube.name = $"Cube_{x}_{y}";
				cubes[x, y] = cube;
			}
		}

		return cubes;
	}
}