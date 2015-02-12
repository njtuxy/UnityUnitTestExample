// Suppress warning for "variable assigned to but never used"
#pragma warning disable 0414

using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using System.Collections;
using System.IO;
using Flagship;



namespace Class_Unit_Tests
{

[TestFixture]
public class EntityDataStoreUnitTests {

		GameObject myTestObject;
		EntityDataStore myEntityDataStore;

		static Hashtable level_1_buildings = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/FlagShip_Unit_Tests/TestData/Building_Jsons/Level_1_Buildings.json"));
//		static Hashtable level_1_shipyard = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/FlagShip_Unit_Tests/TestData/Building_Jsons/Level_1_Shipyard.json"));
		Hashtable level_1_den = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/FlagShip_Unit_Tests/TestData/Building_Jsons/Level_1_Den.json"));
		Hashtable turretinfo  = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/Flagship_Unit_Tests/TestData/Building_Jsons/TurretInfo.json"));

		[TestFixtureSetUp]
		public void RunBeforeAllTestsOnceOnly()
		{
		}
		
		[SetUp]
		public void RunBeforeEveryTestInThisFile()
		{
			myTestObject = new GameObject("unitTestGameObject_DeleteIfYouSeeIt");
			myTestObject.AddComponent("EntityDataStore");
			myEntityDataStore = myTestObject.GetComponent<EntityDataStore>();
		}

		/**
		 * 
		 *  NUnit Test Source - Start
		 * 
		 **/

		private static object[] buildNameAndType =
		{
			new object[] {"Den", EBuildingType.DEN},
			new object[] {"ShipRepair", EBuildingType.SHIPYARD},
			new object[] {"Workshop", EBuildingType.WORKSHOP},
			new object[] {"Guildhouse", EBuildingType.GUILD_HOUSE},
			new object[] {"Lighthouse", EBuildingType.LIGHT_HOUSE},
			new object[] {"DefendingShip", EBuildingType.DEFENDING_SHIP},
			new object[] {"GoldGenerator", EBuildingType.GOLD_GENERATOR},
			new object[] {"GoldStorage", EBuildingType.GOLD_STORAGE},
			new object[] {"GrogGenerator", EBuildingType.GROG_GENERATOR},
			new object[] {"GrogStorage", EBuildingType.GROG_STORAGE},
			new object[] {"TurretCannon", EBuildingType.TURRET_CANNON},
			new object[] {"TurretSniper", EBuildingType.TURRET_LONG},
			new object[] {"TurretArtillery", EBuildingType.TURRET_MORTAR},
			new object[] {"TurretCorrosive", EBuildingType.TURRET_CORROSIVE},
			new object[] {"Trap01", EBuildingType.TRAP_ATTRACTOR},
			new object[] {"Trap02", EBuildingType.TRAP_GENERIC},
			new object[] {"Trap03", EBuildingType.TRAP_REPULSOR},
			new object[] {"Trap04", EBuildingType.TRAP_TELEPORTER},
		};

		private static object[] assertBuildPropertyValues =
		{
			new object[] {level_1_buildings, EBuildingType.DEN, 1},
			new object[] {level_1_buildings, EBuildingType.SHIPYARD, 1},
			new object[] {level_1_buildings, EBuildingType.WORKSHOP, 1},
			new object[] {level_1_buildings, EBuildingType.GUILD_HOUSE, 1},
			new object[] {level_1_buildings, EBuildingType.LIGHT_HOUSE, 1},
			new object[] {level_1_buildings, EBuildingType.DEFENDING_SHIP, 1},
			new object[] {level_1_buildings, EBuildingType.GOLD_GENERATOR, 1},
			new object[] {level_1_buildings, EBuildingType.GOLD_STORAGE, 1},
			new object[] {level_1_buildings, EBuildingType.GROG_GENERATOR, 1},
			new object[] {level_1_buildings, EBuildingType.GROG_STORAGE, 1},
			new object[] {level_1_buildings, EBuildingType.TURRET_CANNON, 1},
			new object[] {level_1_buildings, EBuildingType.TURRET_LONG, 1},
			new object[] {level_1_buildings, EBuildingType.TURRET_MORTAR, 1},
			new object[] {level_1_buildings, EBuildingType.TURRET_CORROSIVE, 1},
			new object[] {level_1_buildings, EBuildingType.TRAP_ATTRACTOR, 1},
			new object[] {level_1_buildings, EBuildingType.TRAP_GENERIC, 1},
			new object[] {level_1_buildings, EBuildingType.TRAP_REPULSOR, 1},
			new object[] {level_1_buildings, EBuildingType.TRAP_TELEPORTER, 1},
		};

		/**
		 * 
		 *  NUnit Test Source - End
		 * 
		 **/

		[Test, TestCaseSource("buildNameAndType")]
		public void TestCanGetBuildingTypeFromAValidName(string buidingName, EBuildingType buildingType)
		{
			Assert.AreEqual(buildingType, Flagship.EntityDataStore.GetBuildingTypeFromName(buidingName));
		}

		[Test]
		public void TestWillGetInvalidBuildingTypeWhenBuildingNameIsUnknown()
		{
			myEntityDataStore.BuildEntityStore(level_1_den, turretinfo);
			Assert.AreEqual(EBuildingType.INVALID, Flagship.EntityDataStore.GetBuildingTypeFromName("invalid"));
		}


		[Test, TestCaseSource("assertBuildPropertyValues")]
		public void TestCanGetBuildForData(Hashtable data, EBuildingType buidingType, int displayLevel)
		{
			EntityData ed;
			myEntityDataStore.BuildEntityStore(data, turretinfo);
			ed = myEntityDataStore.GetBuildingForData(buidingType, 1);
			Assert.AreEqual(displayLevel, ed.DisplayLevel);
		}

		[Test]
		public void TestShouldReturnNullWhenRequestAnUnkonwnBuilding()
		{
			EntityData ed;
			myEntityDataStore.BuildEntityStore(level_1_buildings, turretinfo);
            ed = myEntityDataStore.GetBuildingForData(EBuildingType.INVALID, 1);
			Assert.IsNull(ed);
		}

		[Test]
		public void TestCanGetCostOfABuilding()
		{
			myEntityDataStore.BuildEntityStore(level_1_den, turretinfo);			
			PlayerResourceCost prc = myEntityDataStore.GetCostOfBuildingForLevel(EBuildingType.DEN, 1);
			Assert.AreEqual(20, prc.Gold);
			Assert.AreEqual(30, prc.Grog);
		}

		[Test]
		public void TestCanGetCostOfAnUnknownBuilding()
		{
			myEntityDataStore.BuildEntityStore(level_1_den, turretinfo);
			PlayerResourceCost prc = myEntityDataStore.GetCostOfBuildingForLevel(EBuildingType.INVALID, 1);
			Assert.AreEqual(0, prc.Gold);
			Assert.AreEqual(0, prc.Grog);

		}

  }
}
