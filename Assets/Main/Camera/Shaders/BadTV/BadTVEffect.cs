using System.Collections;
using UnityEngine;

public class BadTVEffect : MonoBehaviour 
{
	public bool on = false;

	[Range(0.1f, 10f)]
	public float thickDistort = 3f;
	public Material material;

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		if(on)
		{
			Graphics.Blit(src, dest, material);
		}

		else
		{
			Graphics.Blit(src, dest);
		}
	}

	void Update()
	{
		if(on)
		{
			material.SetFloat("_ThickDistort", thickDistort);
		}
	}
}