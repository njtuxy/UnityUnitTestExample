using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;

public static class Flagship_Unit_Tests_Helper {

	public const string PREFABS_ROOT_DIR = "Assets/Resources/";
	public const string BUILDING_PREFABS_DIR = PREFABS_ROOT_DIR + "Buildings/";
	public const string TURRETS_PREFABS_DIR = PREFABS_ROOT_DIR + "Turrets/";
	public const string SHIP_PREFABS_DIR = PREFABS_ROOT_DIR + "Ships/";
	public const string ISLANDS_PREFABS_DIR = PREFABS_ROOT_DIR + "Islands/Tropical/";
	//The abilities and spells aren't in the correct prefab folder currently Hard coding the incorrect folder in Ability_Test_Helper
	//public const string ABILITY_PREFABS_DIR = PREFABS_ROOT_DIR + "Abilities";
	//public const string SPELL_PREFABS_DIR = PREFABS_ROOT_DIR + "Spells";


	public static int Get_Int_Value(object input)	
	{
		return System.Convert.ToInt32(input);
	}

	public static string testFailureMsg(string nameOfPrefab)
	{
		string t1 = "******************************************************************************\n";
		string t2 = "  -------------------- cannot pass the test! \n";
		return t1 + nameOfPrefab + t2 + t1;
	}

	//Get all prefabs of each testobjects, return them by an array.
//	public static object[] get_test_prefabs(Building_Test_Helper[] testobjects)
//	{
//		List<GameObject> l = new List<GameObject>();
//		for( int i=0; i<testobjects.Length; i++)
//		{
//			l.Add(testobjects[i].myPrefab);
//		}
//		return l.ToArray();
//	}
//	
//	//Get all get entity compoenents of each testobjects, return them by an array.
//	public static object[] get_entity_compoenents(Building_Test_Helper[] testobjects)
//	{
//		List<Entity> l = new List<Entity>();
//		for( int i=0; i<testobjects.Length; i++)
//		{
//			l.Add(testobjects[i].entity_script_component);
//		}
//		return l.ToArray();
//	}
//
//	//Get all get building compoenents of each testobjects, return them by an array.
//	public static object[] get_building_compoenents(Building_Test_Helper[] testobjects)
//	{
//		List<GridPlacement> l = new List<GridPlacement>();
//		for( int i=0; i<testobjects.Length; i++)
//		{
//			l.Add(testobjects[i].building_component);
//		}
//		return l.ToArray();
//	}
//
//	//Get all get rigidbody compoenents of each testobjects, return them by an array.
//	public static object[] get_rigidbody_compoenents(Building_Test_Helper[] testobjects)
//	{
//		List<Rigidbody> l = new List<Rigidbody>();
//		for( int i=0; i<testobjects.Length; i++)
//		{
//			l.Add(testobjects[i].rigidbody);
//		}
//		return l.ToArray();
//	}
//
//	//Get all get rigidbody compoenents of each testobjects, return them by an array.
//	public static object[] get_box_collider_compoenents(Building_Test_Helper[] testobjects)
//	{
//		List<BoxCollider> l = new List<BoxCollider>();
//		for( int i=0; i<testobjects.Length; i++)
//		{
//			l.Add(testobjects[i].boxCollider);
//		}
//		return l.ToArray();
//	}
//
////	Get all get building select material of each testobjects, return them by an array.
//	public static object[] get_select_material_of_building(Building_Test_Helper[] testobjects)
//	{
//		List<string> l = new List<string>();
//		for( int i=0; i<testobjects.Length; i++)
//		{
//			l.Add(testobjects[i].selectMaterialOfBuilding);
//		}
//		return l.ToArray();
//	}
}
