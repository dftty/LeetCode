﻿using System;

public struct Pair{

	public int x;
	public int y;


	public Pair(int x, int y){
		this.x = x;
		this.y = y;
	}

	public override int GetHashCode(){
		return x << 7 + y;
	}
}


