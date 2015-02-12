// Suppress warning for "variable assigned to but never used
#pragma warning disable 0414

using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Reflection;
using System.Collections;
using NSubstitute;
using Flagship;
using System.IO;

namespace Class_Unit_Tests
{
	[TestFixture]

    public class BuildingRequirementsStoreUnitTests {

		GameObject myTestObject;
		BuildingRequirementsStore myBuildingRequirementsStore;


		[TestFixtureSetUp]
		public void RunBeforeAllTestsOnceOnly()
		{
		}
		
		[SetUp]
		public void RunBeforeEveryTestInThisFile()
		{			
			myTestObject = new GameObject("tempObjectForBuildingStoreUnitTests");
			myTestObject.AddComponent("BuildingRequirementsStore");
			myBuildingRequirementsStore = myTestObject.GetComponent<BuildingRequirementsStore>();
		}


		[Test, Description("Testing BuildingConstructionMeetsRequirements method, it should return false if requested builing type is not Den and current Den level is -1")]
		public void ShouldReturnFalseIfBuildingTypeIsNotDenAndDenLevelIsNegativeOne()
		{
			bool b = myBuildingRequirementsStore.BuildingConstructionMeetsRequirements(EBuildingType.SHIPYARD, -1, 1);
			Assert.IsFalse(b);
		}

		[Test, Description("Testing BuildingConstructionMeetsRequirements method, it should return true if Den is exist and its level is 0 or bigger and request to build a Gold Generator")]
		public void ShouldReturnTrueIfDenisExisitAndRequestToBuildAGoldGenerator()
		{
			myBuildingRequirementsStore.BuildBuildingRequirements(null);
			bool b = myBuildingRequirementsStore.BuildingConstructionMeetsRequirements(EBuildingType.GOLD_GENERATOR, 1, 0);
			Assert.IsTrue(b);
		}

//		private static object[] testDataForNumAllowedBuildingsForDenLevel =
//		{
//			new object[] {EBuildingType.SHIPYARD, 0, 0},
//			new object[] {EBuildingType.SHIPYARD, 1, 1},
//			new object[] {EBuildingType.WORKSHOP, 0, 0},
//			new object[] {EBuildingType.WORKSHOP, 1, 1},
//			new object[] {EBuildingType.GUILD_HOUSE, 0, 0},
//			new object[] {EBuildingType.GUILD_HOUSE, 1, 1},
//			new object[] {EBuildingType.GOLD_GENERATOR, 0, 1},
//			new object[] {EBuildingType.GOLD_GENERATOR, 1, 2},
//			new object[] {EBuildingType.GOLD_STORAGE, 0, 0},
//			new object[] {EBuildingType.GOLD_STORAGE, 1, 1},
//			new object[] {EBuildingType.GROG_GENERATOR, 0, 1},
//			new object[] {EBuildingType.GROG_GENERATOR, 1, 2},
//			new object[] {EBuildingType.GROG_STORAGE, 0, 0},
//			new object[] {EBuildingType.GROG_STORAGE, 1, 1},
//			new object[] {EBuildingType.LIGHT_HOUSE, 0, 0},
//			new object[] {EBuildingType.LIGHT_HOUSE, 1, 1},
//			new object[] {EBuildingType.TURRET_CANNON, 0, 0},
//			new object[] {EBuildingType.TURRET_CANNON, 1, 1},
//			new object[] {EBuildingType.TURRET_CORROSIVE, 0, 0},
//			new object[] {EBuildingType.TURRET_CORROSIVE, 1, 1},
//			new object[] {EBuildingType.TURRET_LONG, 0, 0},
//			new object[] {EBuildingType.TURRET_LONG, 1, 1},
//			new object[] {EBuildingType.TURRET_MORTAR, 0, 0},
//			new object[] {EBuildingType.TURRET_MORTAR, 1, 1},
//		};

//		[Test, TestCaseSource("WorkShopNumAllowedForDenLevel")]
//		public void Test_Num_Of_Allowed_WorkShop_For_Den_Level(int numOfBuildingsAllowed, int denLevel)
//		{
//			myBuildingRequirementsStore.BuildBuildingRequirements(null);
//			Assert.AreEqual(numOfBuildingsAllowed, myBuildingRequirementsStore.GetNumAllowedBuildingsForDenLevel(EBuildingType.WORKSHOP, denLevel));
//		}



		private static object[] GrogStorageNumAllowedForDenLevel =
		{
			new object[] {0, 0},
			new object[] {0, 1},
			new object[] {1, 2},
			new object[] {1, 3},
			new object[] {2, 4},
			new object[] {2, 5},
			new object[] {3, 6},
			new object[] {3, 7},
			new object[] {4, 8},
			new object[] {4, 9},
		};
		
		[Test, TestCaseSource("GrogStorageNumAllowedForDenLevel")]
		public void Test_Num_Of_Allowed_GrogStorage_For_Den_Level(int numOfBuildingsAllowed, int denLevel)
		{
			myBuildingRequirementsStore.BuildBuildingRequirements(null);
			Assert.AreEqual(numOfBuildingsAllowed, myBuildingRequirementsStore.GetNumAllowedBuildingsForDenLevel(EBuildingType.GROG_STORAGE, denLevel));
		}

		[Test, Description("Testing BuildingUpgradeMeetsRequirements() method, it should return true if buildingType is Den")]
		public void ShouldBeAbleToUpgradBuilingIsTypeIsDen()
		{
			TestBuilding tb = new TestBuilding(EBuildingType.DEN);
			Assert.IsTrue(myBuildingRequirementsStore.BuildingUpgradeMeetsRequirements(tb.entity));
		}

		[Ignore("need to figure out how to make BaseController.Instance.GetDenLevel() works locally!")]
		[Test, Description("Testing BuildingUpgradeMeetsRequirements() method, it should return true if buildingType is Den")]
		public void TestToBeNamed()
		{
			TestBuilding tb = new TestBuilding(EBuildingType.GOLD_GENERATOR);
			Assert.IsTrue(myBuildingRequirementsStore.BuildingUpgradeMeetsRequirements(tb.entity));
		}



	}

}
