using UnityEngine;
using System.Collections;
using Flagship;
using NUnit.Framework;

namespace Class_Unit_Tests
{
	
	[TestFixture]
	public class CrewRankDataStoreUnitTests{
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

		[Test, Description("GetRankForLevel() happy path")]
		public void TestGetRankForLevelShouldReturRank()
		{
			CrewRankDataStore t = new CrewRankDataStore(myTestCrew.crewRankDataStore);
			Assert.AreEqual(1, t.GetRankForLevel(10));
			Assert.AreEqual(2, t.GetRankForLevel(40));
		}

		[Test, Description("GetRankForLevel() sad path")]
		public void TestGetRankForLevelShouldReturnZeroWhenLevelIsExceedTheMax()
		{
			CrewRankDataStore t = new CrewRankDataStore(myTestCrew.crewRankDataStore);
			Assert.AreEqual(0, t.GetRankForLevel(1000));
		}

		[Test, Description("GetMaxLevelForRank() happy path")]
		public void TestGetMaxLevelForRankShouldRetureRank()
		{
			CrewRankDataStore t = new CrewRankDataStore(myTestCrew.crewRankDataStore);
			Assert.AreEqual(20, t.GetMaxLevelForRank(1));
			Assert.AreEqual(60, t.GetMaxLevelForRank(2));
		}

		[Test, Description("GetMaxLevelForRank() happy path")]
		public void TestGetMaxLevelForRankShouldRetureZeroWhenRankIsNotExist()
		{
			CrewRankDataStore t = new CrewRankDataStore(myTestCrew.crewRankDataStore);
			Assert.AreEqual(0, t.GetMaxLevelForRank(100));
		}


	}
}
