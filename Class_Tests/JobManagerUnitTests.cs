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
	public class JobManagerUnitTests{

		GameObject myGameObjectForTest;
		JobManager myJobManager;
		TestBuilding testBuilding;

		[TestFixtureSetUp]
		public void RunBeforeAllTestsOnceOnly()
		{
		}
		
		[SetUp]
		public void RunBeforeEveryTestInThisFile()
		{			
			myGameObjectForTest = new GameObject("testobjectforjobmanager");
			myGameObjectForTest.AddComponent("JobManager");
			myJobManager = myGameObjectForTest.GetComponent<JobManager>();
			testBuilding = new TestBuilding(EBuildingType.DEN);
			myJobManager.Awake();
		}

		[Test]
		public void TestJobManagerCanSpawnBuildJob()
		{
			Assert.AreEqual("Flagship.BuildJob", myJobManager.SpawnJobClassFromType(EJobType.build).ToString());
		}

		[Test]
		public void TestJobManagerCanSpawnUpgradeJob()
		{
			Assert.AreEqual("Flagship.UpgradeJob", myJobManager.SpawnJobClassFromType(EJobType.upgrade).ToString());
		}

		[Ignore("There is no Repair job yet!")]
		[Test]
		public void TestJobManagerCanSpawnRepairJob()
		{
			Assert.AreEqual("RepairJob", myJobManager.SpawnJobClassFromType(EJobType.repair).ToString());
		}

		[Test]
		public void TestCannotEnqueuMoreThan1BuildJob()
		{
			myJobManager.CreateBuilding(testBuilding.entity, false, false);
			Assert.IsFalse(myJobManager.CanEnqueueJob(EJobType.build));
		}

		[Test]
		public void TestCannotEnqueuMoreThan1UpgradeJob()
		{
			myJobManager.UpgradeBuilding(testBuilding.entity, false, false);
			Assert.IsFalse(myJobManager.CanEnqueueJob(EJobType.upgrade));
		}

		[Test]
		public void TestCannotEnqueue1UpgradeJobThenEnqueue1BuildJob()
		{
			myJobManager.CreateBuilding(testBuilding.entity, false, false);
			Assert.IsFalse(myJobManager.CanEnqueueJob(EJobType.upgrade));
		}

		[Test]
		public void TestCannotEnqueue1BuildJobThenEnqueue1UpgradeJob()
		{
			myJobManager.UpgradeBuilding(testBuilding.entity, false, false);
			Assert.IsFalse(myJobManager.CanEnqueueJob(EJobType.build));
		}

		[Test]
		public void Test_Create_A_Building()
		{
			myJobManager.CreateBuilding(testBuilding.entity, false, false);
			Assert.AreEqual("JobProxy.BuildJob", Logger.log_for_unit_test);
		}

		[Test] 
		public void Test_Upgrade_A_Building()
		{
			myJobManager.UpgradeBuilding(testBuilding.entity, false, false);
			Assert.AreEqual("JobProxy.UpgradeJob", Logger.log_for_unit_test);	
		}

	}
}
