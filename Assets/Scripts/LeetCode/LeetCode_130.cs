using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeetCode_130 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    // Medium https://leetcode.com/problems/surrounded-regions/description/
    // 2018/7/31
    // use BFS
    public void Solve(char[,] board) {
        Queue<Coordinate> allCoor = new Queue<Coordinate>();
        
        for(int i = 0; i < board.GetLength(0); i++){
            for(int j = 0; j < board.GetLength(1); j++){
                if(board[i, j] == 'O') allCoor.Enqueue(new Coordinate(i, j));
            }
        }
        
        bool flip = false;
        HashSet<Coordinate> flipSet = new HashSet<Coordinate>();
        HashSet<Coordinate> noFlipSet = new HashSet<Coordinate>();
        
        while(allCoor.Count > 0){
            Coordinate coor = allCoor.Dequeue();
            if(flipSet.Contains(coor) || noFlipSet.Contains(coor)) continue;
            
            Queue<Coordinate> tempQueue = new Queue<Coordinate>();
            HashSet<Coordinate> tempSet = new HashSet<Coordinate>();
            flip = true;
            tempQueue.Enqueue(coor);
            while(tempQueue.Count > 0){
                Coordinate c = tempQueue.Dequeue();
                if(tempSet.Contains(c)) continue;
                if(c.x == 0 || c.x == board.GetLength(0) - 1 || c.y == 0 || c.y == board.GetLength(1) - 1) flip = false;
                tempSet.Add(c);
                AddNeighbour(board, tempSet, c, tempQueue);
            }
            
            if(flip) {
				foreach(Coordinate c in tempSet){
					flipSet.Add(c);
				}
			}else {
				foreach(Coordinate c in tempSet){
					noFlipSet.Add(c);
				}
			}
        }
        
        foreach(Coordinate c in flipSet){
            board[c.x, c.y] = 'X';
        }
    }
    
    public void AddNeighbour(char[,] board, HashSet<Coordinate> tempSet, Coordinate c, Queue<Coordinate> queue){
        if(c.x - 1 >= 0 &&  board[c.x - 1, c.y] == 'O' && !tempSet.Contains(new Coordinate(c.x - 1, c.y))) queue.Enqueue(new Coordinate(c.x - 1, c.y));
        if(c.x + 1 < board.GetLength(0) && board[c.x + 1, c.y] == 'O' && !tempSet.Contains(new Coordinate(c.x + 1, c.y))) queue.Enqueue(new Coordinate(c.x + 1, c.y));
        if(c.y - 1 >= 0 &&  board[c.x, c.y - 1] == 'O' &&!tempSet.Contains(new Coordinate(c.x, c.y - 1))) queue.Enqueue(new Coordinate(c.x, c.y - 1));
        if(c.y + 1 < board.GetLength(1) &&  board[c.x, c.y + 1] == 'O' &&!tempSet.Contains(new Coordinate(c.x, c.y + 1))) queue.Enqueue(new Coordinate(c.x, c.y + 1));
    }

    // Fastest solution
    public void Solve_(char[,] board) 
    {
        int m=board.GetLength(0);
        int n=board.GetLength(1);
        
        for (int i=0;i<m;i++)
        {
            FloodFill(board, i, 0);
        }
        
        for (int i=0;i<m;i++)
        {
            FloodFill(board, i, n-1);
        }
        
        for (int i=0;i<n;i++)
        {
            FloodFill(board, 0, i);
        }
        
        for (int i=0;i<n;i++)
        {
            FloodFill(board, m-1, i);
        }
        
        for (int i=0;i<m;i++)
        {
            for (int j=0;j<n;j++)
            {
                if (board[i,j]=='O')
                {
                    board[i,j]='X';
                }
                else if(board[i,j]=='$')
                {
                    board[i,j]='O';
                }
            }
        }
    }
    
    private void FloodFill(char[,] board, int x, int y)
    {
        if (x<0||x>=board.GetLength(0)||y<0||y>=board.GetLength(1))
        {
            return;
        }
        
        if (board[x,y]=='O')
        {
            board[x,y]='$';
            FloodFill(board, x, y-1);
            FloodFill(board, x-1, y);
            FloodFill(board, x+1, y);
            FloodFill(board, x, y+1);
        }        
    }
}

public class Coordinate{
	public int x;
	public int y;

	public Coordinate(int x, int y){
		this.x = x;
		this.y = y;
	}

	public override bool Equals(object obj)
	{
		Coordinate coor = (Coordinate)obj;
		return coor.x == this.x && coor.y == this.y;
	}
	
	// override object.GetHashCode
	public override int GetHashCode()
	{
		return this.x * (1 << 6) + this.y;
	}
}



