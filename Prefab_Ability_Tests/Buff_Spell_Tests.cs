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
	public class Buff_Spell_Tests {
		
		
		static object[] prefabs = 
		{
			new object[] {"Spell_Bolster.prefab"}
			
		};
		
		
		
		[Test, TestCaseSource("prefabs")]
		public void Has_A_Spell_Component (string prefab_name)
		{
			Spell_Test_Helper myTestObject = new Spell_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.spell_script_component !=null, testFailureMsg(myTestObject.name));
		}
		
		[Test, TestCaseSource("prefabs")]
		public void Has_A_Targeter_Component (string prefab_name)
		{
			Spell_Test_Helper myTestObject = new Spell_Test_Helper(prefab_name);
			Assert.IsTrue(myTestObject.spell_target_component !=null, testFailureMsg(myTestObject.name));
		}
		
		
		private string testFailureMsg(string nameOfPrefab)
		{
			string t1 = "******************************************************************************\n";
			string t2 = "  -------------------- cannot pass the test! \n";
			return t1 + nameOfPrefab + t2 + t1;
		}
		
	}
	
}