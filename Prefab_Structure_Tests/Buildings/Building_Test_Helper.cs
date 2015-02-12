using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;

namespace Flagship
{
	public class Building_Test_Helper {
		
		private string prefab_location;
		private string _name;
		private GameObject _myPrefab;
		private Entity _myEntity;
		private GridPlacement _myBuilding;
		private BoxCollider _myBoxCollider;
		private Rigidbody _myRigidbody;
		private Turret _myTurret;
		private PersistantDamageStateSet.PersistantDamageState[] _myPersistantDamageStateArray;


		public Building_Test_Helper(string prefab_name)
		{
			prefab_location = Flagship_Unit_Tests_Helper.BUILDING_PREFABS_DIR + prefab_name;
			_myPrefab = AssetDatabase.LoadAssetAtPath(prefab_location, (typeof(GameObject))) as GameObject;
			_myEntity = _myPrefab.GetComponent<Entity>();
			_myBoxCollider = _myPrefab.GetComponent<BoxCollider>();
			_myRigidbody = _myPrefab.GetComponent<Rigidbody>();
			_myBuilding = _myPrefab.GetComponent<GridPlacement>();
			_myTurret = _myPrefab.GetComponent<Turret>();
			_name = prefab_name;

			/*Here is the 2 layers of reflections to get the damangeStateSets value back*/
			FieldInfo myField = typeof(Entity).GetField("m_persistantDamageStates", BindingFlags.NonPublic | BindingFlags.Instance);
			PersistantDamageStateSet myPersistantDamageStateSet =  myField.GetValue(_myEntity) as PersistantDamageStateSet;
			FieldInfo myField1 = typeof(PersistantDamageStateSet).GetField("m_states", BindingFlags.NonPublic | BindingFlags.Instance);
			List<PersistantDamageStateSet.PersistantDamageState> myPersistantDamageStateList = myField1.GetValue(myPersistantDamageStateSet) as List<PersistantDamageStateSet.PersistantDamageState>;
			_myPersistantDamageStateArray = myPersistantDamageStateList.ToArray();		
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


		public string meshRendererOfBuilding
		{
			get
			{

				FieldInfo myField = typeof(GridPlacement).GetField("m_meshRendererParent", BindingFlags.Public | BindingFlags.Instance);
				return myField.GetValue(_myBuilding).ToString();
			}
		}

		public string gridPlacementCollider
		{
			get
			{
				FieldInfo myField = typeof(GridPlacement).GetField("m_collider", BindingFlags.NonPublic | BindingFlags.Instance);
				return myField.GetValue(_myBuilding).ToString();
			}
		}

		public string orginalMateiralOfBuilding
		{
			get
			{
				FieldInfo myField = typeof(GridPlacement).GetField("m_originalMaterial", BindingFlags.NonPublic | BindingFlags.Instance);
				return myField.GetValue(_myBuilding).ToString();
			}
		}


		/*
		 * // I guess we don't have those compnents anymore Yan - 11.06.14
		 * 

		public string selectMaterialOfBuilding
		{
			get
			{
				FieldInfo myField = typeof(GridPlacement).GetField("m_selectMaterial", BindingFlags.NonPublic | BindingFlags.Instance);
				return myField.GetValue(_myBuilding).ToString();
			}
		}


		public string confilictMaterialOfBuilding
		{
			get
			{
				FieldInfo myField = typeof(GridPlacement).GetField("m_conflictMaterial", BindingFlags.NonPublic | BindingFlags.Instance);
				return myField.GetValue(_myBuilding).ToString();
			}
		}
		*/

		public string deathFXOfEntity
		{
			get
			{
				FieldInfo myField = typeof(Entity).GetField("m_deathFx", BindingFlags.Public | BindingFlags.Instance);
				return myField.GetValue(_myEntity).ToString();
			}
		}

		public Entity entity_script_component	
		{
			get
			{
				return _myEntity;
			}
		}

		public int healthOfEntity
		{
			get
			{
				FieldInfo myField = typeof(Entity).GetField("m_health", BindingFlags.NonPublic | BindingFlags.Instance);
				return Flagship_Unit_Tests_Helper.Get_Int_Value(myField.GetValue(_myEntity));
			}
		}

		public GridPlacement gridPlacement
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
		
		public Turret turret_script_component
		{
			get
			{
				
				return _myTurret;
			}
		}

		public PersistantDamageStateSet.PersistantDamageState[] damageStatesSet
		{
			get
			{
				return _myPersistantDamageStateArray;
			}
		}
		
	}
}