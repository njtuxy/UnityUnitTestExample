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
 	public class CrewDataStoreUnitTests {

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

		[Test, Description("GetCrewMemberDataFor() happy path")]
		public void TestGetCrewMemberDataForFunctionReturnsMemberDataIfCrewFoundInJsonInput()
		{

			CrewMemberData myCrewMemeberData = myTestCrew.crewDataStore.GetCrewMemberDataFor("1");
			Assert.AreEqual("Blackbeard", myCrewMemeberData.PirateName);
			Assert.AreEqual("REPAIR", myCrewMemeberData.ActiveAbilityType);
			Assert.AreEqual(5, myCrewMemeberData.Rarity);
		}

		[Test, Description("GetCrewMemberDataFor() sad path")]
		public void TestGetCrewMemberDataForFunctionReturnsNullIfCrewNotFoundInJsonInput()
		{
			CrewMemberData myCrewMemeberData = myTestCrew.crewDataStore.GetCrewMemberDataFor("100");
			Assert.IsNull(myCrewMemeberData);
		}

		[Test, Description("CreateNewCrewMember() happy path")]
		public void TestCreateNewCrewMemberFunctionShouldReturnValidCrewMember()
		{
			CrewMember myCrewMemeber = myTestCrew.crewDataStore.CreateNewCrewMember("1", "2", 200, 1);
			Assert.AreEqual("Long John Silver", myCrewMemeber.PirateName);
			Assert.AreEqual(200, myCrewMemeber.XP);
			Assert.AreEqual(1, myCrewMemeber.Rank);
			Assert.AreEqual(1, myCrewMemeber.Level);
			Assert.AreEqual(1724, myCrewMemeber.MaxXPForRank);
		}

		[Test, Description("CreateNewCrewMember() sad path")]
		public void TestCreateNewCrewMemberFunctionShouldReturnNullIfCrewNoExist()
		{
			CrewMember myCrewMemeber = myTestCrew.crewDataStore.CreateNewCrewMember("1", "100", 200, 1);
			Assert.IsNull(myCrewMemeber);
		}

		[Test, Description("CrewRandomCrewMember() happy path")]
		public void TestCrewRandomCrewMemberFunctionShouldReturnARandomCrewMemeber()
		{
			CrewMember myCrewMemer = myTestCrew.crewDataStore.CrewRandomCrewMember("1", 200, 1);
			Assert.AreEqual(200, myCrewMemer.XP);
			Assert.AreEqual(1, myCrewMemer.Rank);
		}

	}
	
}
