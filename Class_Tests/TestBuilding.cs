using UnityEngine;
using System.Collections;
using Flagship;
using System.IO;

public class TestBuilding {

	/**
		 * In order to create a building object with valid data for unit test, I need to
		 *  (1) Create a building gameobject, add Entity component and GridPlacement component to it.
		 * 
		 *  (2) Load data to building grid placement component.
		 *      <1> Create a new BudingData object.
		 * 			e.g.
		 * 				BuildingData bd = new BuildingData();
		 * 
		 *      <2> Create a new BuildingType object.
		 * 			e.g. 
		 * 				BuildingType bt = new BuildingType();
		 * 
		 *      <3> Set the BuidingData object.
		 * 			e.g. 
		 * 				bt.buildingType = EBuildingType.DEN;	
		 * 				bd.BuildingType = bt;
		 * 				
		 *      <4> Load BuildingData to grid placement component.
		 * 			e.g.
		 * 				gp.SetBuildingData(bd);
		 * 
		 *  (3) Load data to building entity component.
		 *      <1> Use local json file as input.
		 * 			e.g. 
		 * 				Hashtable level_1_buildings = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/FlagShip_Unit_Tests/TestData/Building_Jsons/Level_1_Buildings.json"));
		 * 
		 *      <2> Call EntityDataStore functions to generate valid EntityData:
		 *          e.g.
		 * 				myEntityDataStore.BuildEntityStore(level_1_buildings);
		 *          	ed = myEntityDataStore.GetBuildingForData(EBuildingType.DEN, 0);
		 * 
		 * 
		 *      <3> Load EntityData to entity component: 
		 *          e.g.
		 *          	e.AssignEntityDataRef(validEntityData)
		 *
		 **/

	private GameObject _myGameObjectForTest;
	private JobManager _myJobManager;
	private Entity _myEntity;
	private GridPlacement _myGridPlacement;
	private EntityDataStore _myEntityDataStore;		
	private Hashtable level_1_buildings = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/FlagShip_Unit_Tests/TestData/Building_Jsons/Level_1_Buildings.json"));
	private Hashtable turretinfo = (Hashtable)EB.JSON.Parse(File.ReadAllText("Assets/Editor/Flagship_Unit_Tests/TestData/Building_Jsons/TurretInfo.json"));

	public TestBuilding(EBuildingType buildingType) {

		_myGameObjectForTest = new GameObject("unitTestGameObject_DeleteIfYouSeeIt");

		//Add components to test object
		_myGameObjectForTest.AddComponent("Entity");
		_myGameObjectForTest.AddComponent("EntityDataStore");
		_myGameObjectForTest.AddComponent("GridPlacement");

		//Get component from test object
		_myEntityDataStore = _myGameObjectForTest.GetComponent<EntityDataStore>();
		_myEntity = _myGameObjectForTest.GetComponent<Entity>();
		_myGridPlacement = _myGameObjectForTest.GetComponent<GridPlacement>();
		
		//create a valid EntityData from EntityDataStore using local josn test data
		_myEntityDataStore.BuildEntityStore(level_1_buildings, turretinfo);
		EntityData myEntityData = _myEntityDataStore.GetBuildingForData(buildingType, 1);
		//Load data
		_myEntity.AssignEntityDataRef(myEntityData);

		
		//Create a valid buiding data.
		BuildingType myBuidingType = new BuildingType();
		myBuidingType.buildingType = buildingType;
		BuildingData myBuidingData = new BuildingData();
		myBuidingData.BuildingType = myBuidingType.buildingType;		
		//Load data
		_myGridPlacement.SetBuildingData(myBuidingData);

//		
//
//		_myEntityDataStore.Awake();

	}

	public Entity entity
	{
		get
		{
			return _myEntity;
		}
	}

	public GridPlacement gridPlacement
	{
		get
		{
			return _myGridPlacement;
		}
	}

	public GameObject gameObject
	{
		get
		{
			return _myGameObjectForTest;
		}
	}

}
