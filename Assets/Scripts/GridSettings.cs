using UnityEngine;

[CreateAssetMenu]
public class GridSettings: ScriptableObject
{
	public string GridFileName => gridFileName;
	public int WindowSize => windowSize;
	public float CubeSize => cubeSize;
	public float CubeSpacing => cubeSpacing;
	public Color Color1 => color1;
	public Color Color2 => color2;
	public Color Color3 => color3;
	public Color Color4 => color4;
	
	[Header("Grid Settings")]
	[SerializeField] private string gridFileName = "grid.txt";
	[SerializeField] private int windowSize = 3;
	[SerializeField] private float cubeSize = 1f;
	[SerializeField] private float cubeSpacing = 1.1f;

	[Header("Colors")]
	[SerializeField] private Color color1 = Color.red;
	[SerializeField] private Color color2 = Color.yellow;
	[SerializeField] private Color color3 = Color.blue;
	[SerializeField] private Color color4 = new Color(0.5f, 0f, 0.5f);
}
