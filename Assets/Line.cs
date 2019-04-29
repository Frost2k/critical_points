using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Line : MonoBehaviour {

	// Creates a line renderer that follows a Sin() function
	// and animates it.

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	public int lengthOfLineRenderer = 20;

	public string allText;

	public List<float> floatValues;

	public string text;

	void Start()
	{
		// System.IO.StreamReader MyReader = new System.IO.StreamReader("C://Users/Pheon/Desktop/Research/DrawLine/Assets/cisfattyacid[2441].txt");
        // while((allText = MyReader.ReadLine()) != null)
        // {
		// 	int test;
		// 	test = allText.Length;
		// 	Debug.Log(test);
        //     Debug.Log (allText);
        // 	foreach (char line in allText)
        // 	{
        //     	Debug.Log("\t" + line);
        // 	}
        // }
        // MyReader.Close();
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		lineRenderer.widthMultiplier = 0.2f;
		lineRenderer.positionCount = lengthOfLineRenderer;

		// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lineRenderer.colorGradient = gradient;
		string text = File.ReadAllText("C://Users/Pheon/Desktop/Research/DrawLine/Assets/cisfattyacid[2441].txt");


		//ParseFile();
	}

	void Update()
	{
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		var points = new Vector3[lengthOfLineRenderer];
		lineRenderer.positionCount = floatValues.Count;
		var t = Time.time;
		for (int i = 0; i < lengthOfLineRenderer; i++)
		{
			 lineRenderer.SetPosition(i, new Vector3(floatValues[i],floatValues[i+1],floatValues[i+3]));
			i += 4;
		}
		 		char[] separators = { ' ' };
                string[] strValues = text.Split(separators);

     		floatValues = new List<float>();
     		foreach(string str in strValues)
     		{
         		float val = 0;
         		if (float.TryParse(str, out val))
             			floatValues.Add(val);
     		}

	}

	void ParseFile()
 	{
     		string text = File.ReadAllText("C://Users/Pheon/Desktop/Research/DrawLine/Assets/cisfattyacid[2441].txt");
 
 		char[] separators = { ' ' };
                string[] strValues = text.Split(separators);

     		floatValues = new List<float>();
     		foreach(string str in strValues)
     		{
         		float val = 0;
         		if (float.TryParse(str, out val))
             			floatValues.Add(val);
     		}
			// int totLen = floatValues.Count; 
			// for(int i = 0; i< totLen; i++)
			// {
			// 	Debug.Log(floatValues[i]);
			// }
	 }
}
