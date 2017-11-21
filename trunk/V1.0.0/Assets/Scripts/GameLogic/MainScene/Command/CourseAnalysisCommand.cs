using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseAnalysisCommand
{
    public static CourseAnalysisCommand instance; 
    /// <summary>
    /// 实例化
    /// </summary>
    ///  
    public static CourseAnalysisCommand Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CourseAnalysisCommand();
            }
            return instance;
        }
    }

    public static string cPath = "JJ1-61-V1.0-2017101800";
    /// <summary>
    /// 课程解析，返回课程对象
    /// </summary>
    public CourseModel AnalysisCourse(){
		
		string content = FileManager.getStreamingAssets (cPath+"/catalog.xml");
 		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (content);
		XmlNodeList nodeList=xmlDoc.SelectSingleNode("root").ChildNodes;
        CourseModel course = new CourseModel();
		ArrayList catList = new ArrayList ();
		course.catalogList = catList;
		course.grade = 6;
		course.term = 1;
 		foreach(XmlElement xe in nodeList){
            CatalogModel catalog = new CatalogModel();
			catalog.resList = new ArrayList ();
			catalog.id = Convert.ToInt32(xe.GetAttribute ("id"));
			catalog.name = xe.GetAttribute ("name");
			catalog.time = Convert.ToInt32(xe.GetAttribute ("time").Equals(""));
			catalog.playGame = Convert.ToBoolean(xe.GetAttribute ("playGame")) ;
			catalog.medal =xe.GetAttribute ("medal"); 
			catalog.baseWidth = Convert.ToInt32(xe.GetAttribute ("baseWidth"));
			foreach(XmlElement node in xe.ChildNodes){
                // 是题目
                if (node.Name.Equals("question")){
                    QuestionModel question = new QuestionModel();
                    question.resList = new ArrayList();
                    //questionType="choice" isMulti="false" anser="3"
                    question.questionType = node.GetAttribute("questionType");
                    question.answer = node.GetAttribute("answer");
                    foreach (XmlElement qNode in node.ChildNodes){
                        TeachResourceModel qRes  = getTeachResource(qNode);
                        question.resList.Add(qRes);
                    }
                    catalog.question = question;
                    continue;
                }
                //教与学的普通内容信息
                catalog.resList.Add (getTeachResource(node));
			}
			course.catalogList.Add (catalog);
		}
		return course;
 	}
    /// <summary>
    /// 获取元素信息
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public TeachResourceModel getTeachResource(XmlElement node) {
        TeachResourceModel res = new TeachResourceModel();
        //资源ID
        res.rid = Convert.ToInt32(node.GetAttribute("rid"));
        res.layer = Convert.ToInt32(node.GetAttribute("layer"));
        res.type = node.GetAttribute("type");
        res.path = node.GetAttribute("path");
        if (!"".Equals(res.path))
        {
            res.path = cPath + "/" + res.path;
        }
        //开始坐标
        Vector2 pointStart = new Vector2();
        pointStart.x = Convert.ToSingle(node.GetAttribute("x1"));
        pointStart.y = Convert.ToSingle(node.GetAttribute("y1"));
        res.pointStart = pointStart;
        //结束坐标
        Vector2 pointEnd = new Vector2();
        pointEnd.x = Convert.ToSingle(node.GetAttribute("x2"));
        pointEnd.y = Convert.ToSingle(node.GetAttribute("y2"));
        res.pointEnd = pointEnd;
        //文字相关的内容
        string fontSize = node.GetAttribute("fontSize");
        res.fontSize = Convert.ToInt32(fontSize.Equals("") ? "0" : fontSize);
        res.alignment = node.GetAttribute("alignment");
        res.color = node.GetAttribute("color");
        //内容
        //if(res.type.Equals("text")|| res.type.Equals("text-choice") || res.type.Equals("teachgoal")||res.type.Equals("teachguidance")){
        //	res.text = node.InnerText;
        //}
        res.text = node.InnerText;
        return res;
    }
}

