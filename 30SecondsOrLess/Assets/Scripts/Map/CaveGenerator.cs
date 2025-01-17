﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CaveGenerator : BaseGenerator {
	public float initialChance = 0.48f;
	public int deathLimit = 4;
	public int birthLimit= 4;
	public int numberOfSteps = 3;
	bool fillEdges = true; 
	bool oneCave = true;//we always want a complete path to anywhere in the map
	public int yOffset = 0;
	public enum CATypes {type1,type2}; //{type1,type2}; 
	public CATypes caType;
	private int startfillindex = 999;
	public ArrayList spots;

	public struct Point
	{
		public int x, y;
		public Point(int px, int py)
		{
			x = px;
			y = py;
		}
	}
	void FillAll(){
		for (int x = 0; x < CurrentMap.GetLength(0); x++) {
			for (int y = 0; y < CurrentMap.GetLength(1); y++) {
				CurrentMap[x,y]=1;
			}
		}
	}
	public void GenerateMap(){
		for (int x = 0; x < CurrentMap.GetLength(0); x++) {
			for (int y = 0; y < CurrentMap.GetLength(1)-yOffset; y++) {
				if(Random.Range(0f,1f) > initialChance){
					CurrentMap[x,y]=0;
				}
			}
		}
		for(int i=0; i<numberOfSteps; i++){
			switch (caType) {
				case CATypes.type1:
					CurrentMap = DoSimulationStep(CurrentMap);
					break;
				case CATypes.type2:
					DoSimulationStep();
					break;
			}
		}
	}
	public void Generate(){
		FillAll();
		GenerateMap();
		if(fillEdges) FillInEdges(CurrentMap);
		if (oneCave) FillAllButLargest(CurrentMap);
		if(renderImmediate) Render ();
	}

	void DoSimulationStep(){//Type2 - more memory efficient
		for (int x = 0; x < CurrentMap.GetLength(0); x++) {
			for (int y = 0; y < CurrentMap.GetLength(1); y++) {
				int nbs = CountAliveNeighbours(CurrentMap, x, y);
				if(CurrentMap[x,y]==1){//First, if a cell is alive but has too few neighbours, kill it.
					if(nbs < deathLimit){
						CurrentMap[x,y] = 0;
					}
					else{
						CurrentMap[x,y] = 1;
					}
				}else{//Otherwise, if the cell is dead now, check if it has the right number of neighbours to be 'born'
					if(nbs > birthLimit){
						CurrentMap[x,y] = 1;
					}
					else{
						CurrentMap[x,y] = 0;
					}
				}
			}
		}
	}

	int[,] DoSimulationStep(int[,] oldMap){//Type1 - The original, uses more memory
		int[,] newMap = new int[oldMap.GetLength(0),oldMap.GetLength(1)];
		for (int x = 0; x < oldMap.GetLength(0); x++) {
			for (int y = 0; y < oldMap.GetLength(1); y++) {
				int nbs = CountAliveNeighbours(oldMap, x, y);
				if(oldMap[x,y]==1){//First, if a cell is alive but has too few neighbours, kill it.
					if(nbs < deathLimit){
						newMap[x,y] = 0;
					}
					else{
						newMap[x,y] = 1;
					}
				}else{//Otherwise, if the cell is dead now, check if it has the right number of neighbours to be 'born'
					if(nbs > birthLimit){
						newMap[x,y] = 1;
					}
					else{
						newMap[x,y] = 0;
					}
				}
				if(y > oldMap.GetLength(1)-yOffset) newMap[x,y]=oldMap[x,y];
			}
		}
		return newMap;
	}

	int CountAliveNeighbours(int[,] map, int x, int y){
		int count = 0;
		for(int i=-1; i<2; i++){
			for(int j=-1; j<2; j++){
				int neighbour_x = x+i;
				int neighbour_y = y+j;
				//If we're looking at the middle point
				if(i == 0 && j == 0){
					//Do nothing, we don't want to add ourselves in!
				}
				//In case the index we're looking at it off the edge of the map
				else if(neighbour_x < 0 || neighbour_y < 0 || neighbour_x >= map.GetLength(0) || neighbour_y >= map.GetLength(1)){
					count = count + 1;
				}
				//Otherwise, a normal check of the neighbour
				else if(map[neighbour_x,neighbour_y]==1){
					count = count + 1;
				}
			}
		}
		return count;
	}

	public void FillInEdges(int[,] map){
		for (int x = 0; x < map.GetLength(0); x++) {
			map[x,0] = 1;
			map[x,map.GetLength(1)-1-yOffset] = 1;
		}
		for (int y = 0; y < map.GetLength(1)-yOffset; y++) {
			map[0,y] = 1;
			map[map.GetLength(0)-1,y] = 1;
		}
	}

	public void FillAllBut(int[,] oldMap,int fillException,int fillWith){//Fill in every index with fillWith except the specified one which will be set to zero
		for (int x = 0; x < oldMap.GetLength(0); x++) {
			for (int y = 0; y < oldMap.GetLength(1); y++) {
				if(oldMap[x,y] == fillException){//The exception doesn't get filled so presume index wants to be zero(unfilled)
					oldMap[x,y]=0;
				}else{
					oldMap[x,y]=fillWith;
				}
			}
		}
	}

	public void FillAllButLargest(int[,] map){//Finds largest cave and fills all other caves in
		List<Point> fillCounts = FloodFill (map);
		int largestsofar = 0; int fillIndex=1;
		foreach (var fillCount in fillCounts) {
			if(fillCount.y> largestsofar){
				fillIndex = fillCount.x;
				largestsofar = fillCount.y;
			}
		}
		FillAllBut (map, fillIndex, 1);
	}



	public List<Point> FloodFill(int[,] oldMap){//startfillindex - each separate cave is given its own fillindex, this is the start of those indexes
		int fillindex = startfillindex;
		List<Point> fillCounts = new List<Point>();//x=fillindex,y=count - Counts the size of each cave, handy for getting rid of all but the largest cave
		for (int x = 0; x < oldMap.GetLength(0); x++) {
			for (int y = 0; y < oldMap.GetLength(1); y++) {
				var open = new Queue<Point>();
				var fillCount = new Point(fillindex,0);
				if(oldMap[x,y] == 0 ){//Not visited and not a wall
					open.Enqueue(new Point(x,y));
					oldMap[x,y]=fillindex;
					while(open.Count>0){
						var current = open.Dequeue();
						int currentx = current.x;
						int currenty = current.y;
						if(current.x>0){
							if(oldMap[currentx-1,currenty] == 0){
								oldMap[currentx-1,currenty]=fillindex;
								open.Enqueue(new Point(currentx-1,currenty));//Add to queue since part of cavern
							}
						}
						if(current.x<oldMap.GetLength(0)-1){
							if(oldMap[currentx+1,currenty] == 0){
								oldMap[currentx+1,currenty]=fillindex;
								open.Enqueue(new Point(currentx+1,currenty));
							}
						}
						if(current.y>0){
							if(oldMap[currentx,currenty-1] == 0){
								oldMap[currentx,currenty-1]=fillindex;
								open.Enqueue(new Point(currentx,currenty-1));
							}
						}
						if(current.y<oldMap.GetLength(1)-1){
							if(oldMap[currentx,currenty+1] == 0){
								oldMap[currentx,currenty+1]=fillindex;
								open.Enqueue(new Point(currentx,currenty+1));
							}
						}
						fillCount.y++;
					}
					fillCounts.Add(fillCount);
					fillindex++;
				}
			}
		}
		return fillCounts;
	}


	public ArrayList FindSpotForEnemy(int[,] map) {

		spots = new ArrayList();

		for (long i = map.GetLongLength(0) - 1; i >= 0; i--) {
			for (long ii = map.GetLength(1) - 1; ii >= 0; ii--) {
				if (map[i,ii] == 0){
					spots.Add(new Point((int)i,(int)ii));
		            i -= 5; //to avoid having spots near each other;
	    			ii -= 5;// same ^
					if (i < 0 || ii < 0 )
						return spots;
				}
			}
		}
		return spots;
	}


	public Point FindNearestSpace(int[,] map,Point startPoint){//Returns nearest clear space to specified point
		var open = new Queue<Point>();
		int[,] tempmap = new int[map.GetLength (0), map.GetLength (1)];//Tracks visited
		tempmap[startPoint.x,startPoint.y]=1;
		open.Enqueue(new Point(startPoint.x,startPoint.y));
		while (open.Count>0) {
			var current = open.Dequeue();
			if(map[current.x,current.y] == 0){
				return new Point(current.x,current.y);				
			}else{
				if(current.x>0){
					if(map[current.x-1,current.y] == 0){
						return new Point(current.x-1,current.y);	
					}else{
						if(tempmap[current.x-1,current.y]==0){
							tempmap[current.x-1,current.y]=1;
							open.Enqueue(new Point(current.x-1,current.y));
						}
					}
				}
				if(current.x<map.GetLength(0)-1){
					if(map[current.x+1,current.y] == 0){
						return new Point(current.x+1,current.y);	
					}else{
						if(tempmap[current.x+1,current.y]==0){
							tempmap[current.x+1,current.y]=1;
							open.Enqueue(new Point(current.x+1,current.y));
						}
					}
				}
				if(current.y>0){
					if(map[current.x,current.y-1] == 0){
						return new Point(current.x,current.y-1);	
					}else{
						if(tempmap[current.x,current.y-1]==0){
							tempmap[current.x,current.y-1]=1;
							open.Enqueue(new Point(current.x,current.y-1));
						}
					}
				}
				if(current.y<map.GetLength(1)-1){
					if(map[current.x,current.y+1] == 0){
						return new Point(current.x,current.y+1);	
					}else{
						if(tempmap[current.x,current.y+1]==0){
							tempmap[current.x,current.y+1]=1;
							open.Enqueue(new Point(current.x,current.y+1));
						}
					}
				}
				
			}
		}
		return new Point(0,0); 
	}

	


}
