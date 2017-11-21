using System.Collections;
using UnityEngine;
using UnityEngine.UI; 
using System.Collections.Generic;
using Vectrosity;
using U3DEventFrame;
/// 
/// <summary>
/// Menu bar view.
/// </summary>
/// 
public class MenuBarView : MonoBehaviour {
	private static MenuBarView menuBarView;
	private Dropdown lessonCatagoryDropDown; 
	private Text pageTip;
	private Transform contentArea; 
    
    //当前的课程
    private CourseModel course;
    //
    private NotifyEvent evt;
    /// <summary>
    /// 实例化
    /// </summary>
    /// 
    public static MenuBarView Instance; 

    private void Awake()
    {
        Instance = this;
    } 

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start(){ 
        evt = new NotifyEvent(NotifyType.UPDATE, this);
        //课程的列表
        lessonCatagoryDropDown = transform.Find("LessonListDropDown_n").GetComponent<Dropdown>();
		//页面的提示
 		pageTip = transform.Find("ButtonBar/PageTip_n").GetComponent<Text>();
		//内容页面
		contentArea = GameObject.Find("ContentArea/Scroll View/Viewport/Content_n").transform;
		//事件初始化
		InitEvents ();
		//更新目录列表
		UpdateLessonCatagory (); 
        //单选题 
    } 

    /// <summary>
    /// 
    /// </summary>
    void Update()
    { 
        NotifacitionCenter.Instance.postNotification(evt);
    }

    /// <summary>
    /// 事件初始化
    /// </summary>
    void InitEvents(){
 		lessonCatagoryDropDown.onValueChanged.AddListener ((int args)=>{
             CatalogModel cat = course.catalogList[args] as CatalogModel; 
			//
 			rendering(ref cat);
             ChangePageTip();
         });
	} 
    /// <summary>
    /// 内容的渲染
    /// </summary>
    /// <param name="resList">Res list.</param>
    private void rendering(ref CatalogModel cat){

		//移除所有元素
		for(int i=0;i<contentArea.childCount;i++){
            contentArea.GetChild(i).gameObject.SetActive(false);
            //Destroy (contentArea.GetChild(i).gameObject);
        }
        Transform tra = contentArea.Find("page"+cat.id);
        if (tra != null) {
            tra.gameObject.SetActive(true);
            SetPageSize(tra.gameObject);
            return;
        }

        //算出资源制作平台的宽度比例和最终显示的宽度比，然后作出调整
        float aspectRatio = (float)GameObject.Find("ContentArea/Scroll View").GetComponent<RectTransform>().rect.size.x / cat.baseWidth;
        //添加元素
        //GameObject pageTemplate = GameObject.Instantiate(Resources.Load("ContentTemplate/PageTemplate", typeof(GameObject))) as GameObject;
        GameObject pageTemplate = GameObject.Instantiate(ComponentTemplate.Instance.TemplateDic["PageTemplate"]) as GameObject;
        pageTemplate.AddComponent<ComponentManager>();
        ContentImmediate content = pageTemplate.AddComponent<ContentImmediate>();
        //Transform contentTransform = pageTemplate.transform.Find("Content");
        pageTemplate.name = "page"+cat.id;
        pageTemplate.transform.SetParent(contentArea);
        pageTemplate.transform.localPosition = Vector3.zero;
        //设置缩放比例
        pageTemplate.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        RectTransform contentTransform = pageTemplate.transform.GetComponent<RectTransform>();

        //需要计算需要滚动的区域差，最小的Y+最大的Y减去content的高度就是了
        for (int i = 0; i < cat.resList.Count; i++)
        {
            TeachResourceModel res = cat.resList[i] as TeachResourceModel;
            //普通的教学内容的渲染
            AbsTeachComponent c = getComponent(res, contentTransform);
            //有些元素不需要渲染，比如说teachgoal和teachguidance
            if (c != null)
            {
                c.render(cat, res, aspectRatio);
            }
        }
        //题目元素的渲染
        if (cat.question != null)
        {
            for (int j = 0; j < cat.question.resList.Count; j++)
            {
                TeachResourceModel qRes = cat.question.resList[j] as TeachResourceModel;
                //添加到显示区域
                AbsTeachComponent c = getComponent(qRes, contentTransform);
                //有些元素不需要渲染，比如说teachgoal和teachguidance
                if (c != null)
                {
                     c.render(cat,qRes, aspectRatio);
                 }
            }
        }

        SetPageSize(pageTemplate);
    }


    void SetPageSize(GameObject pageTemplate)
    {
        pageTemplate.GetComponent<ContentSizeFitter>().SetLayoutHorizontal();
        pageTemplate.GetComponent<ContentSizeFitter>().SetLayoutVertical();

        float maxWidth = 0;
        float maxHeight = 0;
        for (int i = 0; i < pageTemplate.transform.childCount; i++)
        {
            RectTransform childTra = pageTemplate.transform.GetChild(i).GetComponent<RectTransform>();

            if (maxHeight < childTra.rect.height - childTra.localPosition.y)
            {
                maxHeight = childTra.rect.height - childTra.localPosition.y;
            }
        }
        Debug.Log("ContentSizeFitter size  = " + " " + maxWidth + " " + maxHeight);
        contentArea.GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth, maxHeight);
    }
 

    /// <summary>
    /// 获取渲染组件
    /// </summary>
    public AbsTeachComponent getComponent(TeachResourceModel res, Transform contentTransform) {
        //
        AbsTeachComponent component = null;
        //
        if (res.type.Equals("text"))
        {
            component = new TextComponent(contentTransform);
            //图片
        }
        else if (res.type.Equals("image"))
        {
            component = new ImageComponent(contentTransform);
            //音频
        }
        else if (res.type.Equals("audio"))
        {
            component = new AudioComponent(contentTransform);
            //视频播放
        }
        else if (res.type.Equals("video"))
        {
            component = new VideoComponent(contentTransform);
        }
        //文字选择题
        else if (res.type.Equals("text-choice"))
        {
            component = new TextChoiceComponent(contentTransform);
        }
        //图片选择题 
        else if (res.type.Equals("image-choice"))
        {
            component = new ImageChoiceComponent(contentTransform);
        }
        else if (res.type.Equals("line-match"))
        {
            component = new LineMatchingComponent(contentTransform);
        }
        else if (res.type.Equals("judgement"))
        {
            component = new JudgementComponent(contentTransform);
        }
        else if (res.type.Equals("typeSentence"))
        {
            component = new TypeSentenceComponent(contentTransform);
        }
        else if (res.type.Equals("sorting"))
        {
            component = new SortingComponent(contentTransform);
        }
        //容器
        else if (res.type.Equals("container"))
        {
            component = new ContainerComponent(contentTransform);
        }
        else if (res.type.Equals("singlecontainer"))
        {
            component = new SingleContainerComponent(contentTransform);
        }
        else if (res.type.Equals("singlesorting"))
        {
            component = new SingleSortingComponent(contentTransform);
        }
        return component;
    } 
    /// <summary>
    /// 上一个
    /// </summary>
    public void PrePage(){
		if(lessonCatagoryDropDown.value >0){
			lessonCatagoryDropDown.value--;
			ChangePageTip ();
		}
	}

	/// <summary>
	/// 下一个
	/// </summary>
	public void NextPage(){
		if(lessonCatagoryDropDown.value < lessonCatagoryDropDown.options.Count-1){
			lessonCatagoryDropDown.value++;
			ChangePageTip ();
		}
	}

	/// <summary>
	/// 更新PageTip
	/// </summary>
	private void ChangePageTip(){
		int dpValue = lessonCatagoryDropDown.value;
		int currentPage = (dpValue <= 0) ? 1 : (dpValue + 1);
		pageTip.text = currentPage + "/" + lessonCatagoryDropDown.options.Count;
	}

	/// <summary>
	/// 更新上一页，下一页，还有课程目录
	/// </summary>
	public void UpdateLessonCatagory(){

        course = CourseAnalysisCommand.Instance.AnalysisCourse(); 
        Debug.Log("course:"+ course);
//		pageTip.text = "1/" + course.catalogList.Count;
 		ChangePageTip();
		lessonCatagoryDropDown.options.Clear ();
 		Dropdown.OptionData optionData;
 		for (int i = 0; i < course.catalogList.Count; i++)
		{
            CatalogModel catalog = course.catalogList [i] as CatalogModel;
			optionData = new Dropdown.OptionData();
			optionData.text = catalog.name;  
			lessonCatagoryDropDown.options.Add(optionData);
 		} 
 		lessonCatagoryDropDown.value = -1;
 	}
}