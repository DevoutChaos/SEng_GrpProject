﻿using UnityEngine;
using System.Collections;


public class TerrainManager : MonoBehaviour {
	public Transform terrain;
	public Transform player;
	public Transform enemy;
	public int noOfenemies;
	public GameObject gameMaster;
	public GameMaster gM; 

	//public PlayerController player;
	//private HillGenerator hillGenerator = null;
	//private RoomGenerator roomGenerator = null;
	//private AnimationCurve defaultCurve;

	void Awake(){
		//hillGenerator = terrain.GetComponent<HillGenerator>();
		//roomGenerator = terrain.GetComponent<RoomGenerator>();
		//if(hillGenerator) defaultCurve = hillGenerator.contourCurve;
	}
	void Start () {
	
		//player.position = new Vector3 (1, 1, 0);
		GenerateCave();

		noOfenemies = 1;

		if (gameMaster == null) {
			gameMaster = GameObject.FindGameObjectWithTag ("GM");
		} 
		if (gameMaster != null) {
			gM = gameMaster.GetComponent<GameMaster>();
		}
		if (gM != null) {
			gM.enemiesRemaining = noOfenemies;
		}
		//GenerateRoom();
	}

	public void GenerateCave(){
		CaveGenerator caveGenerator = terrain.GetComponent<CaveGenerator> ();
		caveGenerator.Generate ();
		//playerObject = GameObject.FindGameObjectWithTag ("Player");

		CaveGenerator.Point? point = caveGenerator.FindNearestSpace (caveGenerator.CurrentMap, new CaveGenerator.Point (0, 0));//Find nearest clear point to bottom corner of map
		if (point.HasValue){
			player.position = new Vector3 (point.Value.x, point.Value.y, 0) + terrain.position;//Terrain transform may not be at zero so map coordinates will be offset by its position
		}	
		ArrayList points = caveGenerator.FindSpotForEnemy(caveGenerator.CurrentMap);
		int size = points.Count;
		int loc = Random.Range(0, size);
		CaveGenerator.Point? enemLocation = (CaveGenerator.Point)points[loc];
		enemy.position = new Vector3 (enemLocation.Value.x, enemLocation.Value.y, 0) + terrain.position;

	
	}
	/**
	void GenerateRoom(){
		roomGenerator.Generate();
		Rect rectFirstRoom = roomGenerator.FirstRoom();
		player.position = new Vector3(rectFirstRoom.center.x,rectFirstRoom.center.y,player.position.z) + terrain.position;//Place player in the centre of the first room (offset by the terrain transform position)
	}

	void GenerateHillsAndCaves(){
		CaveGenerator caveGenerator = terrain.GetComponent<CaveGenerator>();
		caveGenerator.renderImmediate = false;
		caveGenerator.Generate();
		hillGenerator.yNoise = Random.Range(0f,1f);
		hillGenerator.xScale = Random.Range(6f,16f);
		hillGenerator.renderImmediate = false;
		hillGenerator.contourCurve =defaultCurve;//Only necessary if changed by another routine
		hillGenerator.Append();
		OreGenerator oreGenerator = terrain.GetComponent<OreGenerator>();
		oreGenerator.Append();

		player.position = new Vector3(hillGenerator.MapWidth/2,hillGenerator.MapHeight,player.position.z) + terrain.position;
	}

	void GenerateHillsAndCavesWithRandomContour(){
		CaveGenerator caveGenerator = terrain.GetComponent<CaveGenerator>();
		caveGenerator.renderImmediate = false;
		caveGenerator.Generate();
		hillGenerator.yNoise = Random.Range(0f,1f);
		hillGenerator.xScale = Random.Range(6f,16f);
		hillGenerator.renderImmediate = false;
		hillGenerator.contourCurve = new AnimationCurve(new Keyframe(0, Random.Range(0f,1f)), new Keyframe(0.25f, Random.Range(0f,1f)), new Keyframe(0.5f, Random.Range(0f,1f)), new Keyframe(1, Random.Range(0f,1f)));		
		hillGenerator.Append();
		OreGenerator oreGenerator = terrain.GetComponent<OreGenerator>();
		oreGenerator.Append();

		player.position = new Vector3(hillGenerator.MapWidth/2,hillGenerator.MapHeight,player.position.z) + terrain.position;
	}

*/
	/**
	void OnGUI(){
		if(roomGenerator){
			if(GUILayout.Button("GenerateCave"))
		{
				GenerateCave();
		}
		}

		if(hillGenerator){
			if(GUILayout.Button("GenerateHillsAndCaves")){
				GenerateHillsAndCaves();
			}
			if(GUILayout.Button("GenerateHillsAndCavesWithRandomContour")){
				GenerateHillsAndCavesWithRandomContour();
			}
			if(GUILayout.Button("Zoom In")){
				Camera.main.orthographicSize = 10;
			}
		}
*/
	}


