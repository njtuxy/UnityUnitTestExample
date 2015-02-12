using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;
using System.Collections;
using Flagship;

namespace Islands_Prefabs 
{
	[TestFixture]
	public class Islands_Tests 
	{

		static Island_Test_Helper testobject01 = new Island_Test_Helper("Env_Island_01.prefab");
		static Island_Test_Helper testobject02 = new Island_Test_Helper("Env_Island_02.prefab");
		static Island_Test_Helper testobject03 = new Island_Test_Helper("Env_Island_03.prefab");
		static Island_Test_Helper testobject04 = new Island_Test_Helper("Env_Island_04.prefab");
		static Island_Test_Helper testobject05 = new Island_Test_Helper("Env_Island_05.prefab");
		static Island_Test_Helper testobject06 = new Island_Test_Helper("Env_Island_06.prefab");
		static Island_Test_Helper testobject07 = new Island_Test_Helper("Env_Island_07.prefab");
		static Island_Test_Helper testobject08 = new Island_Test_Helper("Env_Island_08.prefab");
		static Island_Test_Helper testobject09 = new Island_Test_Helper("Env_Island_09.prefab");
		static Island_Test_Helper testobject10 = new Island_Test_Helper("Env_Island_10.prefab");




		static Island_Test_Helper[] testobjects = 
		{
			testobject01,
			testobject02,
			testobject03,
			testobject04,
			testobject05,
			testobject06,
			testobject07,
			testobject08,
			testobject09,
			testobject10
		};


		[Test, TestCaseSource("testobjects")]
		public void Tag_Is_Island(Island_Test_Helper myTestObject)
		{
			Assert.AreEqual("IslandRoot", myTestObject.myPrefab.tag, testFailureMsg(myTestObject.name));
		}

		[Test, TestCaseSource("testobjects")]
		public void Layer_Is_Default(Island_Test_Helper myTestObject)
		{
			Assert.AreEqual("Default",  LayerMask.LayerToName(myTestObject.myPrefab.layer), testFailureMsg(myTestObject.name));
		}

		[Ignore("Work In Progress")]
		[Test, TestCaseSource("testobjects")]
		public void Has_A_SeaPlacement(Island_Test_Helper myTestObject)
		{

		}




		private string testFailureMsg(string nameOfPrefab)
		{
			string t1 = "******************************************************************************\n";
			string t2 = "  -------------------- cannot pass the test! \n";
			return t1 + nameOfPrefab + t2 + t1;
		}
	}
}