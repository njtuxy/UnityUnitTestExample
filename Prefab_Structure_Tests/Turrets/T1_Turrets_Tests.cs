// Suppress warning for "variable assigned to but never used"
#pragma warning disable 0414

using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;
using System.Collections;
using Flagship;

namespace Turret_Prefabs 
{
	[TestFixture]
	public class T1_Turrets_Tests {

		static Turret_Test_Helper testobject01 = new Turret_Test_Helper("Base_Turret_Cannon_T1.prefab");
		static Turret_Test_Helper testobject02 = new Turret_Test_Helper("Base_Turret_Corrosive_T1.prefab");
		static Turret_Test_Helper testobject03 = new Turret_Test_Helper("Base_Turret_Long_T1.prefab");
		static Turret_Test_Helper testobject04 = new Turret_Test_Helper("Base_Turret_Mortar_T1.prefab");
		static Turret_Test_Helper[] testobjects = {testobject01, testobject02, testobject03, testobject04};

		static object[] base_geos =
		{
			new object[] {testobject01, "Base_Turret_Cannon_Geo"},
			new object[] {testobject02, "Base_Turret_Corrosive_T1_Geo"},
			new object[] {testobject03, "Base_Turret_Long_Geo"},
			new object[] {testobject04, "Base_Turret_Mortar_Geo"}
		};

		static object[] turret_cannon_targets =
		{
			new object[] {testobject01, "Base_Turret_Cannon_T1 (Weapon)"},
			new object[] {testobject02, "Base_Turret_Corrosive_T1 (Weapon)"},
			new object[] {testobject03, "Base_Turret_Long_T1 (Weapon)"},
			new object[] {testobject04, "Base_Turret_Mortar_T1 (Weapon)"}
		};



		// Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name)

		[Test, TestCaseSource("testobjects")]
		public void Tag_Is_Building(Turret_Test_Helper myTestObject)
		{
			Assert.AreEqual("Building", myTestObject.myPrefab.tag);
		}
		
		[Test, TestCaseSource("testobjects")]
		public void Layer_Is_Footprint_Building(Turret_Test_Helper myTestObject)
		{
			Assert.AreEqual("Footprint_Building", LayerMask.LayerToName(myTestObject.myPrefab.layer), Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("testobjects")]
		public void Component_Entity_Attached(Turret_Test_Helper myTestObject)
		{
			Assert.IsTrue(myTestObject.entity_script_component !=null, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}	

		[Test, TestCaseSource("testobjects")]
		public void Turret_Min_Range_Should_Greater_Than_Or_Equal_To_0(Turret_Test_Helper myTestObject)
		{
			Assert.IsFalse( myTestObject.minRangeOfTurret < 0, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("testobjects")]
		public void Turret_Max_Range_Should_Greater_Than_0(Turret_Test_Helper myTestObject)
		{
			Assert.IsTrue( myTestObject.maxRangeOfTurret > 0, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("testobjects")]
		public void Turret_Max_Range_Should_Greater_Than_Min_Range(Turret_Test_Helper myTestObject)
		{
			Assert.IsTrue(myTestObject.minRangeOfTurret < myTestObject.maxRangeOfTurret, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("testobjects")]
		public void Turret_Fire_Arc_Should_Greater_Than_0_And_Less_Or_Equals_to_360(Turret_Test_Helper myTestObject)
		{
			Assert.IsTrue(0 < myTestObject.fireArcValue, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
			Assert.IsTrue(myTestObject.fireArcValue <= 360, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));

		}

		[Test, TestCaseSource("testobjects")]
		public void Turret_Fire_Delay_Should_Be_Greater_Than_0(Turret_Test_Helper myTestObject)
		{
			Assert.IsTrue(myTestObject.fireDelayValue > 0, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}


		[Test, TestCaseSource("testobjects")]
		public void Component_Turret_Script_Is_Attached(Turret_Test_Helper myTestObject)
		{
			Assert.IsNotNull(myTestObject.turret_script_component, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}

		[Ignore("Need to wait for artists' fix!")]
		[Test, TestCaseSource("base_geos")]
		public void Component_Building_MeshRenderer_Parent_Set_To_Base_Geo(Turret_Test_Helper myTestObject, string base_geo)
		{
			Assert.AreEqual(base_geo + " (UnityEngine.GameObject)", myTestObject.meshRenderOfBuiding, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("turret_cannon_targets")]
		public void Component_Turret_Cannon_Field_Set_To_Correct_Target(Turret_Test_Helper myTestObject, string weapon)
		{
			Assert.AreEqual(weapon, myTestObject.cannoOfTurret, Flagship_Unit_Tests_Helper.testFailureMsg(myTestObject.name));
		}
	}
}