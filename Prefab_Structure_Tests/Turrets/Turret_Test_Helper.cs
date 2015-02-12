using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;

namespace Flagship
{
	public class Turret_Test_Helper {

		private string prefab_location;
		private string _name;
		private GameObject _myPrefab;
		private Entity _myEntity;
		private GridPlacement _myBuilding;
		private BoxCollider _myBoxCollider;
		private Rigidbody _myRigidbody;
		private Turret _myTurret;

		public Turret_Test_Helper(string prefab_name)
		{
			prefab_location = Flagship_Unit_Tests_Helper.TURRETS_PREFABS_DIR + prefab_name;
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

		public Turret turret_script_component
		{
			get
			{

				return _myTurret;
			}
		}

		public int minRangeOfTurret
		{
			get
			{
				FieldInfo myField = typeof(CombatEntity).GetField("m_minRange", BindingFlags.NonPublic | BindingFlags.Instance);
				return Flagship_Unit_Tests_Helper.Get_Int_Value(myField.GetValue(_myEntity));
			}
		}

		public int maxRangeOfTurret
		{
			get
			{
				FieldInfo myField = typeof(CombatEntity).GetField("m_maxRange", BindingFlags.NonPublic | BindingFlags.Instance);
				return Flagship_Unit_Tests_Helper.Get_Int_Value(myField.GetValue(_myEntity));
			}
		}

		public int fireArcValue
		{
			get
			{
				FieldInfo myField = typeof(CombatEntity).GetField("m_fireArc", BindingFlags.NonPublic | BindingFlags.Instance);
				return Flagship_Unit_Tests_Helper.Get_Int_Value(myField.GetValue(_myEntity)); 

			}
		}

		public int fireDelayValue
		{
			get
			{
				FieldInfo myField = typeof(CombatEntity).GetField("m_fireDelay", BindingFlags.NonPublic | BindingFlags.Instance);
				return Flagship_Unit_Tests_Helper.Get_Int_Value(myField.GetValue(_myEntity));

			}
		}

		public string meshRenderOfBuiding
		{
			get
			{
				FieldInfo myField = typeof(GridPlacement).GetField("m_meshRendererParent", BindingFlags.Public | BindingFlags.Instance);
				return myField.GetValue(_myBuilding).ToString();
			}
		}


		public string cannoOfTurret
		{
			get
			{
				FieldInfo myField = typeof(Turret).GetField("m_cannon", BindingFlags.NonPublic | BindingFlags.Instance);
				return myField.GetValue(_myTurret).ToString();
			}
		}

	}
}