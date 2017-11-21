using System;
using System.Collections;
using Vectrosity;

public class QuestionModel
{
    //questionType="choice" isMulti="false" anser="3"
    /// <summary>
    /// 题目类型
    /// </summary>
    public string questionType { get; set; }

    /// <summary>
    /// 答案
    /// </summary>
    public string answer { get; set; }
    
    /// <summary>
    /// 资源
    /// </summary>
    public ArrayList resList { get; set; }
    /// <summary>
    /// 线的信息,存放LineMatch的
    /// </summary>
    public ArrayList lineMathList = new ArrayList();
}

/// <summary>
/// 线条匹配
/// </summary>
public class LineMatchModel
{
    /// <summary>
    /// 0start,1结束
    /// </summary>
    public int lineState = -1;
    /// <summary>
    /// 线条信息
    /// </summary>
    public VectorLine line { get; set; }
    /// <summary>
    /// 开始的那个点
    /// </summary>
    public TeachResourceModel startRes { get; set; }

    /// <summary>
    /// 结束的那个点
    /// </summary>
    public TeachResourceModel endRes { get; set; }
}