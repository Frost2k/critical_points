﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[RequireComponent( typeof(LineRenderer) )]
public class CurvedLineRenderer : MonoBehaviour 
{
	//PUBLIC
	public float lineSegmentSize = 0.15f;
	public float lineWidth = 0.1f;
	[Header("Gizmos")]
	public bool showGizmos = true;
	public float gizmoSize = 0.1f;
	public Color gizmoColor = new Color(1,0,0,0.5f);
	//PRIVATE
	private CurvedLinePoint[] linePoints = new CurvedLinePoint[0];
	private Vector3[] linePositions = new Vector3[0];
	private Vector3[] linePositionsOld = new Vector3[0];

	// Update is called once per frame
	public void Update () 
	{
		GetPoints();
		SetPointsToLine();
	}

	void GetPoints()
	{
		string text = File.ReadAllText("C://Users/Pheon/Desktop/Research/DrawLine/Assets/test.xlsx");
 
 		char[] separators = { ' ',',' };
        string[] strValues = text.Split(separators);
		List<float> floatValues;
   		floatValues = new List<float>();
   		foreach(string str in strValues)
     		{
        		float val = 0;
         		if (float.TryParse(str, out val))
           			floatValues.Add(val);
     		}
		//find curved points in children
		linePoints = this.GetComponentsInChildren<CurvedLinePoint>();

		//add positions
		linePositions = new Vector3[floatValues.Count];
		for( int i = 0; i < linePoints.Length; i++ )
		{
			linePositions[i] = linePoints[i].transform.position;
		
		}
	}

	void SetPointsToLine()
	{
		//create old positions if they dont match
		if( linePositionsOld.Length != linePositions.Length )
		{
			linePositionsOld = new Vector3[linePositions.Length];
		}

		//check if line points have moved
		bool moved = false;
		for( int i = 0; i < linePositions.Length; i++ )
		{
			//compare
			if( linePositions[i] != linePositionsOld[i] )
			{
				moved = true;
			}
		}

		//update if moved
		if( moved == true )
		{
			LineRenderer line = this.GetComponent<LineRenderer>();

			//get smoothed values
			Vector3[] smoothedPoints = LineSmoother.SmoothLine( linePositions, lineSegmentSize );

			//set line settings
			line.SetVertexCount( smoothedPoints.Length );
			line.SetPositions( smoothedPoints );
			line.SetWidth( lineWidth, lineWidth );
		}
	}

	void OnDrawGizmosSelected()
	{
		Update();
	}

	void OnDrawGizmos()
	{
		if( linePoints.Length == 0 )
		{
			GetPoints();
		}

		//settings for gizmos
		foreach( CurvedLinePoint linePoint in linePoints )
		{
			linePoint.showGizmo = showGizmos;
			linePoint.gizmoSize = gizmoSize;
			linePoint.gizmoColor = gizmoColor;
		}
	}
}
