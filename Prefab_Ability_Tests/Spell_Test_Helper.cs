using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;

namespace Flagship
{
	public class Spell_Test_Helper {
		
		private string prefab_location;
		private string _name;
		private GameObject _myPrefab;
		private Spell _mySpell;
		private SpellTargeter _myTargeter;
		//private SpellEffect_SpawnCompanion _mySpawn;
		private SpellEffect_SpawnEntity _mySpawn;
		
		public Spell_Test_Helper(string prefab_name)
		{
			
			prefab_location = "Assets/Prefabs/Spells/" + prefab_name;
			_myPrefab = AssetDatabase.LoadAssetAtPath(prefab_location, (typeof(GameObject))) as GameObject;
			_mySpell = _myPrefab.GetComponent<Spell>();
			_myTargeter = _myPrefab.GetComponent<SpellTargeter>();
			_mySpawn = _myPrefab.GetComponent<SpellEffect_SpawnEntity>();
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
		
		public Spell spell_script_component
		{
			get
			{
				return _mySpell;
			}
		}

		public SpellTargeter spell_target_component
		{
			get
			{
				return _myTargeter;
			}
		}

		public SpellEffect_SpawnEntity spell_spawn_component
		{
			get
			{
				return _mySpawn;
			}
		}

	}
}