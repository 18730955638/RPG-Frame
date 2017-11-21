using System;
using UnityEngine;


/// 
/// <summary>
/// 资源类型
/// layer="3" type="text" x1y1="100,200" x2y2="200,400" fontSize="14" alignment="left" color="#fff000"
/// </summary>
/// 
public class TeachResourceModel
{
    public int rid;
	public int layer;
	public string type;
	public Vector2 pointStart;
	public Vector2 pointEnd;
	public int fontSize;
	public string path;
	public string alignment;
	public string color; 
	//当type=text，teachgoal，teachguidance的时候，这个text存放的是text的内容
	public string text;
}