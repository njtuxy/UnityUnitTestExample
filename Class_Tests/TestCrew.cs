using UnityEngine;
using System.Collections;
using Flagship;
using System.IO;


public class TestCrew {

	GameObject _myGameObject;
	CrewDataStore _myCrewDataStore;
	Hashtable _myCrewData = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/FlagShip_Unit_Tests/TestData/Crew_Jsons/smallCrewData.json"));

	public TestCrew()
	{
		_myGameObject = new GameObject("testCrew_GameObject");
		_myGameObject.AddComponent("CrewDataStore");
		_myCrewDataStore = _myGameObject.GetComponent<CrewDataStore>();
		_myCrewDataStore.Seed(_myCrewData);
	}


	public GameObject gameObject
	{
		get
		{
			return _myGameObject;
		}
	}

	public CrewDataStore crewDataStore
	{
		get
		{
			return _myCrewDataStore;
		}
	}

	public Hashtable crewData
	{
		get
		{
			return _myCrewData;
		}
	}

	public ArrayList crewBaseStatsDataStore
	{
		get
		{
			return (ArrayList)_myCrewData["crew_base_stats"];
		}
	}

	public ArrayList crewXpDataStore
	{
		get
		{
			return (ArrayList)_myCrewData["crew_xp"];
		}
	} 

	public ArrayList crewRankDataStore
	{
		get
		{
			return (ArrayList)_myCrewData["crew_rank"];
		}
	} 
}
