using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GridInputActions : MonoBehaviour
{
	public event Action<Vector2Int> OnMove;
	public event Action OnReload;

	private InputAction moveUp;
	private InputAction moveDown;
	private InputAction moveLeft;
	private InputAction moveRight;
	private InputAction reload;

	private void Awake()
	{
		moveUp = new InputAction("MoveUp", binding: "<Keyboard>/w");
		moveDown = new InputAction("MoveDown", binding: "<Keyboard>/s");
		moveLeft = new InputAction("MoveLeft", binding: "<Keyboard>/a");
		moveRight = new InputAction("MoveRight", binding: "<Keyboard>/d");
		reload = new InputAction("Reload", binding: "<Keyboard>/r");
	}

	private void OnEnable()
	{
		moveUp.performed += ctx => OnMove?.Invoke(Vector2Int.up * -1);
		moveDown.performed += ctx => OnMove?.Invoke(Vector2Int.down * -1);
		moveLeft.performed += ctx => OnMove?.Invoke(Vector2Int.left);
		moveRight.performed += ctx => OnMove?.Invoke(Vector2Int.right);
		reload.performed += ctx => OnReload?.Invoke();

		moveUp.Enable();
		moveDown.Enable();
		moveLeft.Enable();
		moveRight.Enable();
		reload.Enable();
	}

	private void OnDisable()
	{
		moveUp.Disable();
		moveDown.Disable();
		moveLeft.Disable();
		moveRight.Disable();
		reload.Disable();
	}
}