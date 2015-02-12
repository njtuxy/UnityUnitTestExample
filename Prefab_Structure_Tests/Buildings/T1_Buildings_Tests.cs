// Suppress warning for "variable assigned to but never used"
#pragma warning disable 0414

using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;
using System.Collections;
using Flagship;

namespace Buildings_Prefabs 
{
	[TestFixture]
	public class T1_Buildings_Tests {
		
		static object[] prefabs = 
		{
			new object[] {"Base_Guildhouse_T1.prefab"},
			new object[] {"Base_HeroDock_T1.prefab"},
			new object[] {"Base_Lighthouse_T1.prefab"},
			new object[] {"Base_Resource_A_Silo_T1.prefab"},
			new object[] {"Base_Resource_A_T1.prefab"},
			new object[] {"Base_Resource_B_Silo_T1.prefab"},
			new object[] {"Base_Resource_B_T1.prefab"},
			new object[] {"Base_Shipyard_T1.prefab"},
			new object[] {"Base_TownHall_T1.prefab"},
			new object[] {"Base_Workshop_T1.prefab"},
		};


		static object[] prefabs_and_their_expected_base_geos =
		{
			new object[] {"Base_Guildhouse_T1.prefab", "Base_Guildhouse_Geo"},
			new object[] {"Base_HeroDock_T1.prefab", "Base_HeroDock_Geo"},
			new object[] {"Base_Lighthouse_T1.prefab", "Base_Lighthouse_Geo"},
			new object[] {"Base_Resource_A_Silo_T1.prefab", "Base_Resource_A_Silo_Geo"},
			new object[] {"Base_Resource_A_T1.prefab", "Base_Resource_A_Geo"},
			new object[] {"Base_Resource_B_Silo_T1.prefab", "Base_Resource_B_Silo_Geo"},
			new object[] {"Base_Resource_B_T1.prefab", "Base_Resource_B_Geo"},
			new object[] {"Base_Shipyard_T1.prefab", "Base_Shipyard_Geo"},
			new object[] {"Base_TownHall_T1.prefab", "Base_TownHall_Geo"},
			new object[] {"Base_Workshop_T1.prefab", "Base_Workshop_Geo"}
		};

//		static object[] base_mats =
//		{
//			new object[] {testobject01, "Base_Guildhouse_Mat"},
//			new object[] {testobject02, "Base_HeroDock_Mat"},
//			new object[] {testobject03, "Base_Lighthouse_Mat"},
//			new object[] {testobject04, "Base_Resource_A_Silo_Mat"},
//			new object[] {testobject05, "Base_Resource_A_Mat"},
//			new object[] {testobject06, "Base_Resource_B_Silo_Mat"},
//			new object[] {testobject07, "Base_Resource_B_Mat"},
//			new object[] {testobject08, "Base_Shipyard_Mat"},
//			new object[] {testobject09, "Base_TownHall_Mat"},
//			new object[] {testobject10, "Base_Workshop_Mat"}
//			
//		};
		

		static object[] prefabs_and_their_expected_base_colliders =
		{
			new object[] {"Base_Guildhouse_T1.prefab", "Base_Guildhouse_T1"},
			new object[] {"Base_HeroDock_T1.prefab", "Base_HeroDock_T1"},
			new object[] {"Base_Lighthouse_T1.prefab", "Base_Lighthouse_T1"},
			new object[] {"Base_Resource_A_Silo_T1.prefab", "Base_Resource_A_Silo_T1"},
			new object[] {"Base_Resource_A_T1.prefab", "Base_Resource_A_T1"},
			new object[] {"Base_Resource_B_Silo_T1.prefab", "Base_Resource_B_Silo_T1"},
			new object[] {"Base_Resource_B_T1.prefab", "Base_Resource_B_T1"},
			new object[] {"Base_Shipyard_T1.prefab", "Base_Shipyard_T1"},
			new object[] {"Base_TownHall_T1.prefab", "Base_TownHall_T1"},
			new object[] {"Base_Workshop_T1.prefab", "Base_Workshop_T1"}
			
		};


		[Test, TestCaseSource("prefabs")]
		public void Tag_Is_Building(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.AreEqual("Building", myTestObject.myPrefab.tag, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Layer_Is_Footprint_Building(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.AreEqual("Footprint_Building", LayerMask.LayerToName(myTestObject.myPrefab.layer), testFailureMsg(myTestObject.name));
		}
		
		[Test, TestCaseSource("prefabs")]
		public void Component_Entity_Attached(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.entity_script_component !=null, testFailureMsg(myTestObject.name));
		}	

		[Test, TestCaseSource("prefabs")]
		public void Component_Entity_Health_Is_Greater_Than_0 (string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.healthOfEntity > 0, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Entity_Team_ID_Is_Defender (string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.AreEqual(myTestObject.entity_script_component.TeamId.ToString(), "DEFENDER", testFailureMsg(myTestObject.name));
		}


		[Test, TestCaseSource("prefabs")]
		public void Component_Entity_Death_FX_Points_To_FX_Fire_VFX(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.AreEqual("FX_Fire (VFX)", myTestObject.deathFXOfEntity, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Box_Collider_Attached(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.boxCollider != null, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Box_Collider_Size_X_Is_Divisible_By_10(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.boxCollider.size.x % 10 == 0, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Box_Collider_Size_Y_Is_Greater_Than_0(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.boxCollider.size.y > 0, testFailureMsg(myTestObject.name));
		}
		
		[Test, TestCaseSource("prefabs")]
		public void Component_Box_Collider_Size_Z_Is_Divisible_By_10(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.boxCollider.size.z % 10 == 0, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Rigidbody_Attached(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.rigidbody!=null, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Rigidbody_Doesnot_Use_Gravity(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsFalse(myTestObject.rigidbody.useGravity, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Rigidbody_Is_Kinematic(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.rigidbody.isKinematic , testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs")]
		public void Component_Grid_Placment_Attached (string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.gridPlacement != null, testFailureMsg(myTestObject.name));
		}


		/*
		 * I guess we don't have the conflictMat for gridplacement anymore,will remove this test later
		[Test, TestCaseSource("prefabs")]
		public void Component_Building_Conflict_Material_Set_To_BuildingConfilctMat(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.AreEqual("BuildingConflictMat (UnityEngine.Material)", myTestObject.confilictMaterialOfBuilding);
		}


		[Test, TestCaseSource("prefabs")]
		public void Component_Building_Select_Material_Set_To_BuildingSelectMat(string prefab_name)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.AreEqual("BuildingSelectMat (UnityEngine.Material)", myTestObject.selectMaterialOfBuilding);
		}
		*/

		[Ignore("Need to wait for artists' fix!")]
		[Test, TestCaseSource("base_mats")]
		public void Component_Building_OriginalMaterial_Set_To_Base_Mat(Building_Test_Helper myTestObject, string base_mat)
		{
			Assert.AreEqual(base_mat + " (UnityEngine.Material)", myTestObject.orginalMateiralOfBuilding, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("prefabs_and_their_expected_base_colliders")]
		public void Component_Building_Collider_Is_Set_To_Base_Collider(string prefab_name, string base_collider)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Assert.AreEqual(base_collider + " (UnityEngine.BoxCollider)", myTestObject.gridPlacementCollider, testFailureMsg(myTestObject.name));
		}

		[Ignore("Need to wait for artists' fix!")]
		[Test, TestCaseSource("prefabs_and_their_expected_base_geos")]
		public void Component_Building_MeshRenderer_Parent_Set_To_Base_Geo (string prefab_name, string base_geo)
		{
			Building_Test_Helper myTestObject = new Building_Test_Helper(prefab_name);
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>");
			Debug.Log(myTestObject);
			Debug.Log(myTestObject.myPrefab);
			Debug.Log(myTestObject.meshRendererOfBuilding);
			Debug.Log(">>>>>>>>>>>>>>>>>>>>>");
			Assert.AreEqual(base_geo + " (UnityEngine.GameObject)", myTestObject.meshRendererOfBuilding, testFailureMsg(myTestObject.name));
		}

		private string testFailureMsg(string nameOfPrefab)
		{
			string t1 = "******************************************************************************\n";
			string t2 = "  -------------------- cannot pass the test! \n";
			return t1 + nameOfPrefab + t2 + t1;
		}


	}
}