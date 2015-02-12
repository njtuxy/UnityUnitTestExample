using UnityEngine;
using System.Collections;
using Flagship;
using NUnit.Framework;

namespace Class_Unit_Tests
{
	public class CrewXPDataStoreUnitTests {

		TestCrew myTestCrew;
		
		[TestFixtureSetUp]
		public void RunBeforeAllTestsOnceOnly()
		{
			
		}
		
		[SetUp]
		public void RunBeforeEveryTestInThisFile()
		{
			myTestCrew = new TestCrew();
		}

		[Test, Description("GetTotalXpToAcquireLevel() happy path")]
		public void TestGetTotalXpToAcquireLevelShouldReturnXPValue()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);

			//Need 0 xp to go to level 1
			Assert.AreEqual(0, t.GetTotalXpToAcquireLevel(1));

			//Need 300 xp to get to level 2
			Assert.AreEqual(300, t.GetTotalXpToAcquireLevel(2));

			//Need 602 xp to get to level 3
			Assert.AreEqual(602, t.GetTotalXpToAcquireLevel(3));

		}

		[Test, Description("GetTotalXpToAcquireLevel() sad path")]
		public void TestGetTotalXpToAcquireLevelShouldReturnZeroIfLevelNotFound()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);
			
			//Need 0 xp to go to level 1
			Assert.AreEqual(0, t.GetTotalXpToAcquireLevel(1000));

		}

		[Test, Description("GetXPToLevelUp() happy path")]
		public void TestGetXPToLevelUpShouldReturnXPValue()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);
			
			//Need 300 xp to got to level 2
			Assert.AreEqual(302, t.GetXPToLevelUp(2));

			//Need 305 xp to got to level 2
			Assert.AreEqual(305, t.GetXPToLevelUp(3));
		}

		[Test, Description("GetXPToLevelUp() sad path")]
		public void TestGetXPToLevelUpShouldReturnZeroIfLevelNotFound()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);
			
			//Need 300 xp to got to level 2
			Assert.AreEqual(0, t.GetXPToLevelUp(1000));
		}

		[Test, Description("GetSellingXP() happy path")]
		public void TestGetSellingXPShouldReturnXPValue()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);

			//Selling xp for level 1 is 300
			Assert.AreEqual(300, t.GetSellingXP(1));			

			//Selling xp for level 2 is 600
			Assert.AreEqual(600, t.GetSellingXP(2));			

			//Selling xp for level 3 is 902
			Assert.AreEqual(902, t.GetSellingXP(3));			
		}

		[Test, Description("GetSellingXP() sad path")]
		public void TestGetSellingXPShouldReturnZeroIfLevelNotFound()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);
			
			//Need 300 xp to got to level 2
			Assert.AreEqual(0, t.GetSellingXP(1000));			
		}

		[Test, Description("GetLevelForXP() happy path")]
		public void TestGetLevelForXPShouldReturnLevel()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);
			
			//when xp is 2 then level is 1
			Assert.AreEqual(1, t.GetLevelForXP(2));			

			//when xp is 301 then level is 2
			Assert.AreEqual(2, t.GetLevelForXP(301));			

			//when xp is 603 then level is 3
			Assert.AreEqual(3, t.GetLevelForXP(603));			
		}

		[Test, Description("GetLevelForXP() sad path")]
		public void TestGetLevelForXPShouldReturnZeroIfXPExceedTheMax()
		{
			CrewXpDataStore t = new CrewXpDataStore(myTestCrew.crewXpDataStore);
			
			Assert.AreEqual(0, t.GetLevelForXP(99999999));			
			
		}

	}
	
}
