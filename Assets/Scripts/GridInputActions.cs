using UnityEngine;
using UnityEngine.InputSystem;

public class GridInputActions : MonoBehaviour
{
	[SerializeField] private GridVisualizerManager gridManager;
	
	private InputAction moveUpAction;
	private InputAction moveDownAction;
	private InputAction moveLeftAction;
	private InputAction moveRightAction;
	private InputAction reloadAction;

	private void Awake()
	{
		moveUpAction = new InputAction("MoveUp", binding: "<Keyboard>/w");
		moveDownAction = new InputAction("MoveDown", binding: "<Keyboard>/s");
		moveLeftAction = new InputAction("MoveLeft", binding: "<Keyboard>/a");
		moveRightAction = new InputAction("MoveRight", binding: "<Keyboard>/d");
		reloadAction = new InputAction("Reload", binding: "<Keyboard>/r");

		// Set up action callbacks
		moveUpAction.performed += ctx => OnMoveUp();
		moveDownAction.performed += ctx => OnMoveDown();
		moveLeftAction.performed += ctx => OnMoveLeft();
		moveRightAction.performed += ctx => OnMoveRight();
		reloadAction.performed += ctx => OnReload();
	}

	void OnEnable()
	{
		moveUpAction?.Enable();
		moveDownAction?.Enable();
		moveLeftAction?.Enable();
		moveRightAction?.Enable();
		reloadAction?.Enable();
	}

	void OnDisable()
	{
		moveUpAction?.Disable();
		moveDownAction?.Disable();
		moveLeftAction?.Disable();
		moveRightAction?.Disable();
		reloadAction?.Disable();
	}

	void OnDestroy()
	{
		moveUpAction?.Dispose();
		moveDownAction?.Dispose();
		moveLeftAction?.Dispose();
		moveRightAction?.Dispose();
		reloadAction?.Dispose();
	}

	private void OnMoveUp()
	{
		if (gridManager != null)
			gridManager.MoveWindow(new Vector2Int(0, 1));
	}

	private void OnMoveDown()
	{
		if (gridManager != null)
			gridManager.MoveWindow(new Vector2Int(0, -1));
	}

	private void OnMoveLeft()
	{
		if (gridManager != null)
			gridManager.MoveWindow(new Vector2Int(-1, 0));
	}

	private void OnMoveRight()
	{
		if (gridManager != null)
			gridManager.MoveWindow(new Vector2Int(1, 0));
	}

	private void OnReload()
	{
		if (gridManager != null)
			gridManager.ReloadGrid();
	}
}