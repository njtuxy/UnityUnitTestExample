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


public class Test_Entity_PersistantDamange_State {

	private GameObject _myGameObjectForTest;
	private JobManager _myJobManager;
	private Entity _myEntity;
	private int _damangeStatesSize;
	private float _element0_min_percent_damange;
	private float _element1_min_percent_damange;
	private float _element2_min_percent_damange;

	private float _element0_max_percent_damange;
	private float _element1_max_percent_damange;
	private float _element2_max_percent_damange;

	private string _element0_vfx;
	private string _element1_vfx;
	private string _element2_vfx;

	private string _element0_vfx_root;
	private string _element1_vfx_root;
	private string _element2_vfx_root;

	public Test_Entity_PersistantDamange_State(string GameObjectName) {
		
		_myGameObjectForTest = GameObject.Find(GameObjectName);
		_myEntity = _myGameObjectForTest.GetComponent<Entity>();
		FieldInfo myField = typeof(Entity).GetField("m_persistantDamageStates", BindingFlags.NonPublic | BindingFlags.Instance);
		PersistantDamageStateSet myPersistantDamageStateSet =  myField.GetValue(_myEntity) as PersistantDamageStateSet;
		FieldInfo myField1 = typeof(PersistantDamageStateSet).GetField("m_states", BindingFlags.NonPublic | BindingFlags.Instance);
		List<PersistantDamageStateSet.PersistantDamageState> myPersistantDamageStateList = myField1.GetValue(myPersistantDamageStateSet) as List<PersistantDamageStateSet.PersistantDamageState>;
		PersistantDamageStateSet.PersistantDamageState[] myPersistantDamageStateArray = myPersistantDamageStateList.ToArray();
		
		_damangeStatesSize = myPersistantDamageStateArray.Length;

		_element0_min_percent_damange = myPersistantDamageStateArray[0].minPercentDamage;
		_element0_max_percent_damange = myPersistantDamageStateArray[0].maxPercentDamage;

		_element1_min_percent_damange = myPersistantDamageStateArray[1].minPercentDamage;
		_element1_max_percent_damange = myPersistantDamageStateArray[1].maxPercentDamage;
	
		_element2_min_percent_damange = myPersistantDamageStateArray[2].minPercentDamage;
		_element2_max_percent_damange = myPersistantDamageStateArray[2].maxPercentDamage;

		_element0_vfx = myPersistantDamageStateArray[0].vfx.ToString();
		_element1_vfx = myPersistantDamageStateArray[1].vfx.ToString();
		_element2_vfx = myPersistantDamageStateArray[2].vfx.ToString();

		_element0_vfx_root = myPersistantDamageStateArray[0].vfxRoot.ToString();
		_element1_vfx_root = myPersistantDamageStateArray[1].vfxRoot.ToString();
		_element2_vfx_root = myPersistantDamageStateArray[2].vfxRoot.ToString();


	}
	
	public int damangeStatesSize
	{
		get
		{
			return _damangeStatesSize;
		}
	}
	
	public float element0_min_percent_damange
	{
		get
		{
			return _element0_min_percent_damange;
		}
	}

	public float element1_min_percent_damange
	{
		get
		{
			return _element1_min_percent_damange;
		}
	}

	public float element2_min_percent_damange
	{
		get
		{
			return _element2_min_percent_damange;
		}
	}

	public float element0_max_percent_damange
	{
		get
		{
			return _element0_max_percent_damange;
		}
	}

	public float element1_max_percent_damange
	{
		get
		{
			return _element1_max_percent_damange;
		}
	}

	public float element2_max_percent_damange
	{
		get
		{
			return _element2_max_percent_damange;
		}
	}

	public string element0_vfx
	{
		get
		{
			return _element0_vfx;
		}
	}

	public string element1_vfx
	{
		get
		{
			return _element1_vfx;
		}
	}

	public string element2_vfx
	{
		get
		{
			return _element2_vfx;
		}
	}

	public string element0_vfx_root
	{
		get
		{
			return _element0_vfx_root;
		}
	}

	public string element1_vfx_root
	{
		get
		{
			return _element1_vfx_root;
		}
	}

	public string element2_vfx_root
	{
		get
		{
			return _element2_vfx_root;
		}
	}
}
