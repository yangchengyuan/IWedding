using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneToolbarPanel : BasePanel
{
	public GameObject tooLineAddItemBtn;
    public GameObject tooLineAddHomeBtn;

	private GameObject toolLineUndoBtn;
	private GameObject toolLineRedoBtn;
    private GameObject toolLineCopyBtn;
    private GameObject toolLinePasteBtn;
    private GameObject toolLineDeleteBtn;

    private GameObject toolLineChangeViewBtn;

    private GameObject toolLineAlignBtn;

    private GameObject toolLinePhotoBtn;
    private GameObject toolLineFilterBtn;
    private GameObject toolLineRenderBtn;
    private GameObject toolLineSaveBtn;
    private GameObject toolLineLoadBtn;
    private GameObject toolLineLightBtn;
    private GameObject toolLineVRBtn;
    private GameObject toolLineShortBtn;

    private bool lightFlag = true;

    private bool viewFlag = false;
    private List<GameObject> toolBtnList = new List<GameObject>();

    private void Awake()
    {
		tooLineAddItemBtn = transform.Find("ToolLineBg").Find("ToolLineAddItem").gameObject;
		tooLineAddHomeBtn = transform.Find("ToolLineBg").Find("ToolLineAddHome").gameObject;

        toolLineUndoBtn = transform.Find("ToolLineBg").Find("ToolLineUndoBtn").gameObject;
        toolLineRedoBtn = transform.Find("ToolLineBg").Find("ToolLineRedoBtn").gameObject;
        toolLineCopyBtn = transform.Find("ToolLineBg").Find("ToolLineCopyBtn").gameObject;
        toolLinePasteBtn = transform.Find("ToolLineBg").Find("ToolLinePasteBtn").gameObject;
        toolLineDeleteBtn = transform.Find("ToolLineBg").Find("ToolLineDeleteBtn").gameObject;
        toolLinePhotoBtn = transform.Find("ToolLineBg").Find("ToolLinePhotoBtn").gameObject;
        toolLineChangeViewBtn = transform.Find("ToolLineBg").Find("ToolLineChangeView").gameObject;

        toolLineAlignBtn = transform.Find("ToolLineBg").Find("ToolLineAlignBtn").gameObject;

        toolLineFilterBtn = transform.Find("ToolLineBg").Find("ToolLineFilterBtn").gameObject;
        toolLineRenderBtn = transform.Find("ToolLineBg").Find("ToolLineRenderBtn").gameObject;
        toolLineSaveBtn = transform.Find("ToolLineBg").Find("ToolLineSaveBtn").gameObject;
        toolLineLoadBtn = transform.Find("ToolLineBg").Find("ToolLineLoadBtn").gameObject;
        toolLineLightBtn = transform.Find("ToolLineBg").Find("ToolLineLightBtn").gameObject;

        toolLineVRBtn = transform.Find("ToolLineBg").Find("ToolLineVRBtn").gameObject;

		toolBtnList.Add(tooLineAddItemBtn);
		toolBtnList.Add(tooLineAddHomeBtn);

        toolBtnList.Add(toolLineUndoBtn);
        toolBtnList.Add(toolLineRedoBtn);
        toolBtnList.Add(toolLineCopyBtn);
        toolBtnList.Add(toolLinePasteBtn);
        toolBtnList.Add(toolLineDeleteBtn);
        toolBtnList.Add(toolLinePhotoBtn);

        toolBtnList.Add(toolLineChangeViewBtn);
        toolBtnList.Add(toolLineFilterBtn);
        toolBtnList.Add(toolLineRenderBtn);
        toolBtnList.Add(toolLineSaveBtn);
        toolBtnList.Add(toolLineLoadBtn);
        toolBtnList.Add(toolLineLightBtn);

        toolBtnList.Add(toolLineAlignBtn);

        toolBtnList.Add(toolLineVRBtn);

		for (int i = 0; i < toolBtnList.Count; i++) {
			AddEventClick (toolBtnList [i]);
            AddEventDown(toolBtnList[i]);
            AddEventUp(toolBtnList[i]);
        }

        viewFlag = true;

        Open();
    }

    public override void Open()
    {
        base.Open();
        init();
        SetButtonColor(tooLineAddItemBtn);
    }

    protected override void OnDown(GameObject obj)
    {
        if (obj != tooLineAddItemBtn && obj != tooLineAddHomeBtn)
        {
            SetButtonColor(obj);
        }
    }

    protected override void OnUp(GameObject obj)
    {
        if (obj != tooLineAddItemBtn && obj != tooLineAddHomeBtn)
        {
            IntButtonColor(obj);
        }
    }

    protected override void OnClick(GameObject obj)
    {
		if (obj == tooLineAddItemBtn) {
            SetButtonColor(tooLineAddItemBtn);
            IntButtonColor(tooLineAddHomeBtn);
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.ADDITEM));
        }
        if (obj == tooLineAddHomeBtn) {
            SetButtonColor(tooLineAddHomeBtn);
            IntButtonColor(tooLineAddItemBtn);
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.ADDHOME));
        }
        if (obj == toolLineUndoBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.UNDO));
        }
        if (obj == toolLineRedoBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.REDO));
        }
        if (obj == toolLineCopyBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.COPY));
        }
        if(obj == toolLinePasteBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.PASTE));
        }
        if (obj == toolLineDeleteBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.DELETE));
        }
        if (obj == toolLinePhotoBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.PHOTO));
        }

        if (obj == toolLineChangeViewBtn)
        {
            if (viewFlag)
            {
                toolLineChangeViewBtn.transform.Find("Text").GetComponent<Text>().text = "切 换 2 D";
                toolLineChangeViewBtn.GetComponent<Image>().overrideSprite = Resources.Load("UI/CorePanel/ToolLine/2d", typeof(Sprite)) as Sprite;
                transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.TO3D));
                viewFlag = false;
            }
            else {
                toolLineChangeViewBtn.transform.Find("Text").GetComponent<Text>().text = "切 换 3 D";
                toolLineChangeViewBtn.GetComponent<Image>().overrideSprite = Resources.Load("UI/CorePanel/ToolLine/3d", typeof(Sprite)) as Sprite;
                transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.TO2D));
                viewFlag = true;
            }
        }

        if (obj == toolLineFilterBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.FILTER));
        }

        if (obj == toolLineRenderBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.RENDER));
        }

        if (obj == toolLineSaveBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.SAVE));
        }

        if (obj == toolLineLoadBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.LOAD));
        }

        if (obj == toolLineAlignBtn)
        {
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.ALIGN));
        }

        if (obj == toolLineLightBtn)
		{
            ToggleLight();
            transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.LIGHT));
		}
		if (obj == toolLineVRBtn)
		{
			transform.parent.GetComponent<BasePanel>().dispatchEvent(new SceneToolbarEvent(SceneToolbarEvent.CAMERA));
		}
    }

    private void ToggleLight()
    {
        if (lightFlag)
        {
            lightFlag = false;
            toolLineLightBtn.transform.Find("Text").GetComponent<Text>().text = "开 启 灯 光";
        }
        else
        {
            lightFlag = true;
            toolLineLightBtn.transform.Find("Text").GetComponent<Text>().text = "关 闭 灯 光";
        }
    }

    public void SetButtonColor(GameObject e) {
        e.transform.Find("Text").GetComponent<Text>().color = new Color(0.952F, 0.706F, 0.2902F, 1);
        e.GetComponent<Image>().color = new Color(0.952F, 0.706F, 0.2902F, 1);
    }

    public void IntButtonColor(GameObject e)
    {
        e.transform.Find("Text").GetComponent<Text>().color = Color.white;
        e.GetComponent<Image>().color = Color.white;
    }

    private void HideToolBtn()
    {
        for (int i = 0; i < toolBtnList.Count; i++)
        {
            toolBtnList[i].SetActive(false);
        }
    }

    private void ShowToolBtn()
    {
        for (int i = 0; i < toolBtnList.Count; i++)
        {
            toolBtnList[i].SetActive(true);
        }
    }

    private void init()
    {
    }

    void Update()
    {
    }
}
