using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Flagship;


namespace Class_Unit_Tests
{
	
	[TestFixture]
	public class CrewBaseStatsDataStoreUnitTests {

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

		[Test, Description("TestGetAttack() happy path")]
		public void TestGetAttackShouldReturAttackRarity()
		{
			CrewBaseStatsDataStore t = new CrewBaseStatsDataStore(myTestCrew.crewBaseStatsDataStore);

			//Get attack_rarity_1 when pirate level = 1
			Assert.AreEqual(15, t.GetAttack(1,1));

			//Get attack_rarity_1 when pirate level = 2
			Assert.AreEqual(16, t.GetAttack(1,2));
		}

		[Test, Description("GetHealth() happy path")]
		public void TestGetHealthShouldReturHealthRarity()
		{
			CrewBaseStatsDataStore t = new CrewBaseStatsDataStore(myTestCrew.crewBaseStatsDataStore);
			
			//Get health_rarity_1 when pirate level = 1
			Assert.AreEqual(225, t.GetHealth(1,1));
			
			//Get health_rarity_1 when pirate level = 2
			Assert.AreEqual(227, t.GetHealth(1,2));
		}



	}


	
}
