using System;
using System.IO;
using UnityEngine;

public class GridVisualizerManager : MonoBehaviour
{
	[SerializeField] private GridSettings gridParameters;

	private GridInputActions inputHandler;
	private GridData gridData;
	private GameObject[,] cubeObjects;
	private GridVisualizer visualizer;
	private Vector2Int visualCenter;
	private int gridWidth, gridHeight;

	private void Awake()
	{
		inputHandler = gameObject.AddComponent<GridInputActions>();
	}

	private void OnEnable()
	{
		inputHandler.OnMove += MoveWindow;
		inputHandler.OnReload += ReloadGrid;
	}

	private void OnDisable()
	{
		inputHandler.OnMove -= MoveWindow;
		inputHandler.OnReload -= ReloadGrid;
	}
	
	private void Start()
	{
		LoadGridAndInitialize();
	}

	private void LoadGridAndInitialize()
	{
		var path = Path.Combine(Application.streamingAssetsPath, gridParameters.GridFileName);

		try
		{
			gridData = GridFileLoader.LoadGrid(path);
		}
		catch (Exception e)
		{
			Debug.LogError($"Error loading grid: {e.Message}, creating default grid...");
			gridData = GridFileLoader.CreateDefaultGrid(10, 10);
		}

		var materialFactory = new MaterialFactory();
		var materials = materialFactory.CreateColorMaterials(gridParameters);
			
		cubeObjects = GridCubeFactory.CreateCubeGrid(transform, gridParameters);

		visualizer = new GridVisualizer(materials, gridParameters, gridData, cubeObjects);
		visualCenter = new Vector2Int(UnityEngine.Random.Range(0, gridWidth), UnityEngine.Random.Range(0, gridHeight));
		
		visualizer.UpdatePosition();
		visualizer.UpdateVisualization(visualCenter);
	}

	private void MoveWindow(Vector2Int direction)
	{
		visualCenter.x += direction.x;
		visualCenter.y += direction.y;
		visualizer.UpdateVisualization(visualCenter);
	}

	private void ReloadGrid()
	{
		Debug.Log("Reloading grid...");
		foreach (Transform child in transform)
			Destroy(child.gameObject);

		LoadGridAndInitialize();
	}
		
}