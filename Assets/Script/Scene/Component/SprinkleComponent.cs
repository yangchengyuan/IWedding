﻿using Build3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLB;

public class SprinkleComponent : SceneComponent
{
    private GameObject _flower;

    private bool _isInit = false;

    private SprinkleVO _sprinkleVO;

    public override void Init(AssetSprite _item)
    {
        if (_isInit) return;
        _isInit = true;

        _sprinkleVO = _item.VO.GetComponentVO<SprinkleVO>();
        if (_sprinkleVO == null)
        {
            _sprinkleVO = _item.VO.AddComponentVO<SprinkleVO>();
        }

        _flower = Resources.Load("Item/Petal/Petal1") as GameObject;

        _box = new GameObject();
        _box.name = _item.transform.gameObject.name;
        _box.transform.parent = _item.parent;
    }

    private GameObject _box;

    public void Sprinkle(float value)
    {
        SprinkleData data = new SprinkleData();
        data.id = NumberUtils.GetGuid();

        for (int i = 0; i < value; i++)
        {
            Vector3 pv = new Vector3(transform.position.x + Random.Range(-.1f, .1f),
                transform.position.y + Random.Range(-.1f, .1f),
                transform.position.z + Random.Range(-.1f, .1f));
            Vector3 rv = new Vector3(360 * Random.value,
                360 * Random.value,
                360 * Random.value);

            data.points.Add(pv);
            data.rotations.Add(rv);
        }

        Sprinkle(data);
    }

    public void Sprinkle(SprinkleData data)
    {
        for (int i = 0; i < data.rotations.Count; i++)
        {
            GameObject flower = GameObject.Instantiate(_flower);
            flower.transform.localPosition = data.points[i];
            flower.transform.localRotation = Quaternion.Euler(data.rotations[i]);
            flower.transform.parent = _box.transform;
            flower.layer = gameObject.layer;
            foreach (Transform t in flower.transform)
            {
                t.gameObject.layer = gameObject.layer;
            }
            Rigidbody rigid = flower.AddComponent<Rigidbody>();
            rigid.collisionDetectionMode = CollisionDetectionMode.Continuous;
            flower.name = data.id;

            _sprinkleVO.list.Add(flower);
            Destroy(rigid, 3f);
        }

        _sprinkleVO.SetData(data);
    }

    public void Clear()
    {
        foreach (GameObject obj in _sprinkleVO.list)
        {
            Destroy(obj);
        }

        _sprinkleVO.list = new List<GameObject>();
        _sprinkleVO.dataList = new List<SprinkleData>();
    }

    private void Update()
    {
        //if (Input)
        //{

        //}
    }

    public SprinkleVO vo;

    override public AssetVO VO
    {
        set
        {
            vo = value.GetComponentVO<SprinkleVO>();

            for (int i = 0; i < _sprinkleVO.list.Count; i++)
            {
                bool has = false;
                foreach (SprinkleData data in vo.dataList)
                {
                    if (_sprinkleVO.list[i].name == data.id)
                    {
                        has = true;
                        continue;
                    }
                }

                if (!has)
                {
                    Destroy(_sprinkleVO.list[i]);
                    _sprinkleVO.list.Remove(_sprinkleVO.list[i]);
                    i--;
                }
            }

            for (int i = 0; i < vo.dataList.Count; i++)
            {
                bool has = false;
                foreach (GameObject obj in _sprinkleVO.list)
                {
                    if (vo.dataList[i].id == obj.name)
                    {
                        has = true;
                        continue;
                    }
                }

                if (!has)
                {
                    Sprinkle(vo.dataList[i]);
                }
            }
        }
        get { return vo; }
    }
}
