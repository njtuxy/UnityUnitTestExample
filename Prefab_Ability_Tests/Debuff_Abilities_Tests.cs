// Suppress warning for "variable assigned to but never used"
#pragma warning disable 0414

using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Collections;
using System.IO;
using Flagship;



namespace Ability_Prefab_Tests
{
	
	[TestFixture]
	public class Debuff_Abilities_Tests {
		
		
		static object[] prefabs = 
		{
			new object[] {"Ability_Stun.prefab"}
			
		};
		
		
		[Test, TestCaseSource("prefabs")]
		public void Has_Ability_Script (string prefab_name)
		{
			Ability_Test_Helper myTestObject = new Ability_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.ability_script_component !=null, testFailureMsg(myTestObject.name));
		}
		
		[Test, TestCaseSource("prefabs")]
		public void Has_Icon (string prefab_name)
		{
			Ability_Test_Helper myTestObject = new Ability_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.ability_script_component.Icon !=null, testFailureMsg(myTestObject.name));
		}
		
		[Test, TestCaseSource("prefabs")]
		public void Has_Cooldown_Length_Greater_Than_Zero (string prefab_name)
		{
			Ability_Test_Helper myTestObject = new Ability_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.ability_script_component.Cooldown > 0, testFailureMsg(myTestObject.name));
		}
		
		[Test, TestCaseSource("prefabs")]
		public void Has_Cooldown_Spell_Prefab (string prefab_name)
		{
			Ability_Test_Helper myTestObject = new Ability_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.ability_script_component.SpellPrefab != null, testFailureMsg(myTestObject.name));
		}
		
		[Test, TestCaseSource("prefabs")]
		public void Has_Valid_Target_Type_As_Ground (string prefab_name)
		{
			Ability_Test_Helper myTestObject = new Ability_Test_Helper(prefab_name);
			Assert.AreEqual(myTestObject.ability_script_component.ValidTargetType.ToString(),"GROUND", testFailureMsg(myTestObject.name));
		}
		
		
		private string testFailureMsg(string nameOfPrefab)
		{
			string t1 = "******************************************************************************\n";
			string t2 = "  -------------------- cannot pass the test! \n";
			return t1 + nameOfPrefab + t2 + t1;
		}
		
	}
	
}