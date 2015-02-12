using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;

namespace Flagship 
{
	public class Island_Test_Helper 
	{

		private string prefab_location;
		private string _name;
		private GameObject _myPrefab;
		private Entity _myEntity;
		private GridPlacement _myBuilding;
		private BoxCollider _myBoxCollider;
		private Rigidbody _myRigidbody;
		private Turret _myTurret;

		public Island_Test_Helper(string prefab_name) 
		{
			prefab_location = Flagship_Unit_Tests_Helper.ISLANDS_PREFABS_DIR + prefab_name;
			_myPrefab = AssetDatabase.LoadAssetAtPath(prefab_location, (typeof(GameObject))) as GameObject;
			_myEntity = _myPrefab.GetComponent<Entity>();
			_myBoxCollider = _myPrefab.GetComponent<BoxCollider>();
			_myRigidbody = _myPrefab.GetComponent<Rigidbody>();
			_myBuilding = _myPrefab.GetComponent<GridPlacement>();
			_myTurret = _myPrefab.GetComponent<Turret>();
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
			
			
			public string meshRendererOfIsland
			{
				get
				{
					
					FieldInfo myField = typeof(GridPlacement).GetField("m_meshRendererParent", BindingFlags.NonPublic | BindingFlags.Instance);
					return myField.GetValue(_myBuilding).ToString();
				}
			}
			
			public string colliderOfIsland
			{
				get
				{
					FieldInfo myField = typeof(GridPlacement).GetField("m_collider", BindingFlags.NonPublic | BindingFlags.Instance);
					return myField.GetValue(_myBuilding).ToString();
				}
			}
			
			public string orginalMateiralOfIslant
			{
				get
				{
					FieldInfo myField = typeof(GridPlacement).GetField("m_originalMaterial", BindingFlags.NonPublic | BindingFlags.Instance);
					return myField.GetValue(_myBuilding).ToString();
				}
			}
			
			public string selectMaterialOfIsland
			{
				get
				{
					FieldInfo myField = typeof(GridPlacement).GetField("m_selectMaterial", BindingFlags.NonPublic | BindingFlags.Instance);
					return myField.GetValue(_myBuilding).ToString();
				}
			}
			
			public string confilictMaterialOfIsland
			{
				get
				{
					FieldInfo myField = typeof(GridPlacement).GetField("m_conflictMaterial", BindingFlags.NonPublic | BindingFlags.Instance);
					return myField.GetValue(_myBuilding).ToString();
				}
			}
			
			public Entity entity_script_component	
			{
				get
				{
					return _myEntity;
				}
			}
			
			public GridPlacement building_component
			{
				get
					
				{
					return _myBuilding;
				}
			}
			
			public BoxCollider boxCollider
			{
				get
				{
					
					return _myBoxCollider;
				}
			}
			
			public Rigidbody rigidbody
			{
				get
				{
					return _myRigidbody;
				}
			}
			
			
		}
	}