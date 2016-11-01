using UnityEngine;
using System.Collections;

[System.Serializable]
//Little helper class for storing integer coordinates.
public class IntVector2{

	public int x, y;

	public IntVector2(int X, int Y){
		this.x = X;
		this.y = Y;
	}

	public IntVector2(float X, float Y){
		this.x = (int)X;
		this.y = (int)Y;
	}

	public Vector3 AsVector3(){
		return new Vector3(this.x, this.y, 0);
	}

	public override string ToString(){
		return "IntVector2: (X: " + x + ", Y: " + y + ")";
 	}

 	public static IntVector2 operator +(IntVector2 a, IntVector2 b){
 		return new IntVector2(a.x + b.x, a.y + b.y);
 	}

 	public static IntVector2 operator -(IntVector2 a, IntVector2 b){
 		return new IntVector2(a.x - b.x, a.y - b.y);
 	}

}
