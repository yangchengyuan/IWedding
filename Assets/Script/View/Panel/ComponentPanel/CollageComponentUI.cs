﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollageComponentUI : BaseComponentUI
{
    override public void Init()
    {
        base.Init();

        CreateTitleName("选择材质");
    }

    protected override void UpdateUI()
    {
        base.UpdateUI();

        foreach (ButtonImageUI b in _collageBtns)
        {
            Destroy(b.gameObject);
            b.transform.parent = null;
        }

        _collageBtns = new List<ButtonImageUI>();
        _collageHashtable = new Dictionary<string, CollageStruct>();

        if (items.Count > 0)
        {
            List<CollageStruct> cslist = items[0].VO.GetComponentVO<CollageVO>().collages;
            List<string> cList = new List<string>();
            List<string> idList = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < cslist.Count; j++)
                {
                    if (cslist[j].tag.Contains(i.ToString()))
                    {
                        cList.Add(i.ToString());
                        idList.Add(cslist[j].id as string);
                        break;
                    }
                }
            }
            for (int i = 0; i < cList.Count; i++)
            {
                AddBtn(i, cslist[i].name);
            }

            UpdateHeight();

            for (int i = 0; i < _collageBtns.Count; i++)
            {
                if (idList[i] != "")
                {
                    Texture2D texture2 = TexturesManager.CreateMaterials(idList[i]).mainTexture as Texture2D;
                    if (texture2 != null) _collageBtns[i].image.sprite = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height), new Vector2(0.5f, 0.5f));
                }
            }
        }

        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }

    private void AddBtn(int value, string name)
    {
        ButtonImageUI buttonUI = CreateButtonImageUI(value.ToString(), CollageButtonClickHandle);
        _collageBtns.Add(buttonUI);
        buttonUI.buttonText.text = name;
        buttonUI.name = value.ToString();
    }

    private void CollageButtonClickHandle(ButtonImageUI ui)
    {
        _currentValue = ui.name;

        SelectTexturePanel sp = UIManager.OpenPanel(Panel.SelectTexturePanel, TexturesManager.CollageImageList,
        ui.button.transform.position - new Vector3(30, 0)) as SelectTexturePanel;
        sp.getTextue += UpdateTexture;

        foreach (CollageStruct cs in (_assets[0] as CollageVO).collages)
        {
            if (ui.name == cs.tag)
            {
                sp.selectItem = cs.id.ToString();
            }
        }
    }

    private Dictionary<string, CollageStruct> _collageHashtable = new Dictionary<string, CollageStruct>();
    private List<ButtonImageUI> _collageBtns = new List<ButtonImageUI>();
    private List<string> _collageIDs = new List<string>();
    private string _currentValue;

    private void UpdateTexture(string id)
    {
        foreach (AssetVO avo in _assets)
        {
            CollageVO vo = avo as CollageVO;
            foreach (CollageStruct c in vo.collages)
            {
                if (c.tag.Contains(_currentValue))
                {
                    c.id = id;
                }
            }
        }
    }

    override public List<ObjectSprite> items
    {
        set
        {
            base.items = value;

            foreach (ObjectSprite obj in _items)
            {
                _oldAssets.Add(obj.VO.GetComponentVO<CollageVO>().Clone());
                _assets.Add(obj.VO.GetComponentVO<CollageVO>().Clone());
            }

            FillComponent();
        }
    }
}

