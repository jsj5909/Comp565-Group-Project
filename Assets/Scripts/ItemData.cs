using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "New Store Item")]
public class ItemData : ScriptableObject
{
	[SerializeField] Sprite itemImage;

	[SerializeField] int cost;

	[SerializeField] string itemName;



	public int GetCost()
	{
		return cost;
	}

	public string GetName()
	{
		return itemName;
	}

	public Sprite GetImage()
	{
		return itemImage;
	}


}