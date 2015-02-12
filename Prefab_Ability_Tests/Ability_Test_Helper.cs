using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;

namespace Flagship
{
	public class Ability_Test_Helper {

		private string prefab_location;
		private string _name;
		private GameObject _myPrefab;
		private Ability _myAbility;

		public Ability_Test_Helper(string prefab_name)
		{

			prefab_location = "Assets/Prefabs/Abilities/" + prefab_name;
			_myPrefab = AssetDatabase.LoadAssetAtPath(prefab_location, (typeof(GameObject))) as GameObject;
			_myAbility = _myPrefab.GetComponent<Ability>();
			_name = prefab_name;

		}

		public string name
		{
			get
			{
				return _name;
			}
		}
		
		public GameObject myPrefab
		{
			get
			{
				return _myPrefab;	 
			}
		}

		public Ability ability_script_component
		{
			get
			{
				return _myAbility;
			}
		}

	}
}