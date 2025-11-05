using System.Collections.Generic;
using UnityEngine;

public class MaterialFactory
{
	private readonly float metallic;
	private readonly float smoothness;

	public MaterialFactory(float metallic = 0.2f, float smoothness = 0.5f)
	{
		this.metallic = metallic;
		this.smoothness = smoothness;
	}

	public Dictionary<int, Material> CreateColorMaterials(GridSettings parameters)
	{
		return new Dictionary<int, Material>
		{
			{ 1, CreateMaterial(parameters.Color1) },
			{ 2, CreateMaterial(parameters.Color2) },
			{ 3, CreateMaterial(parameters.Color3) },
			{ 4, CreateMaterial(parameters.Color4) }
		};
	}

	private Material CreateMaterial(Color color)
	{
		var mat = new Material(Shader.Find("Standard"));
		mat.color = color;
		mat.SetFloat("_Metallic", metallic);
		mat.SetFloat("_Glossiness", smoothness);
		return mat;
	}
}