using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using NSubstitute;
using Flagship;
using System.IO;

namespace StatesTests
{
	[TestFixture]
	public class PersistantDamageStateTests {

		[TestFixtureSetUp]
		public void RunBeforeAllTestsOnceOnly()
		{

		}
		
		[SetUp]
		public void RunBeforeEveryTestInThisFile()
		{

		}
		
		[Test]
		public void Test_Ship_Barracuda_PersistantDamageStateSet_Values()
		{
			Test_Entity_PersistantDamange_State myEntityPDS = new Test_Entity_PersistantDamange_State("Unit_Ship_Barracuda");

			Assert.AreEqual(3, myEntityPDS.damangeStatesSize);


//			The value should be between 0 and 100
			Assert.Less(0, myEntityPDS.element0_min_percent_damange);
			Assert.GreaterOrEqual(100, myEntityPDS.element0_min_percent_damange);

			Assert.Less(0, myEntityPDS.element0_max_percent_damange);
			Assert.GreaterOrEqual(100, myEntityPDS.element0_max_percent_damange);

			Assert.AreEqual("Damage_1 (Flagship.VFX)", myEntityPDS.element0_vfx);
			Assert.AreEqual("Unit_Ship_Barracuda (UnityEngine.Transform)", myEntityPDS.element0_vfx_root);

			//			The value should be between 0 and 100
			Assert.Less(0, myEntityPDS.element1_min_percent_damange);
			Assert.GreaterOrEqual(100, myEntityPDS.element1_min_percent_damange);
			
			Assert.Less(0, myEntityPDS.element1_max_percent_damange);
			Assert.GreaterOrEqual(100, myEntityPDS.element1_max_percent_damange);
			
			Assert.AreEqual("Damage_2 (Flagship.VFX)", myEntityPDS.element1_vfx);
			Assert.AreEqual("Unit_Ship_Barracuda (UnityEngine.Transform)", myEntityPDS.element1_vfx_root);

			//			The value should be between 0 and 100
			Assert.Less(0, myEntityPDS.element2_min_percent_damange);
			Assert.GreaterOrEqual(100, myEntityPDS.element2_min_percent_damange);
			
			Assert.Less(0, myEntityPDS.element2_max_percent_damange);
			Assert.GreaterOrEqual(100, myEntityPDS.element2_max_percent_damange);
			
			Assert.AreEqual("Damage_3 (Flagship.VFX)", myEntityPDS.element2_vfx);
			Assert.AreEqual("Unit_Ship_Barracuda (UnityEngine.Transform)", myEntityPDS.element2_vfx_root);

		}
    }
}
