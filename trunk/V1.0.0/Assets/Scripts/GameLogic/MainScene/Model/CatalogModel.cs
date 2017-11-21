using System;
using System.Collections;
using System.Collections.Generic;

public class CatalogModel
{
	public int id{ get; set;}
	public string name{ get; set;}
	public int time{ get; set;}
	public bool playGame{ get; set;}
  	public string medal{ get; set;}
	//这个catalog所对应的内容是在什么分辨率下编辑完成的
	public int baseWidth{ get; set;}
	//存放resource的
	public ArrayList resList{ get; set;}
    //
    public QuestionModel question { get; set; }
}