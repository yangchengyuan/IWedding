﻿using UnityEngine;
using System.Collections;

public class CopyCommand : HistoryCommand
{
    public override void Execute(EventObject e)
    {
        SceneEvent se = e as SceneEvent;

        SaveOldValue(se, CloneAssets(se.oldAssets));

        for (int i = 0; i < se.oldAssets.Count; i++)
        {
            ItemVO assets = se.oldAssets[i] as ItemVO;
            ItemVO newAssets = se.newAssets[i] as ItemVO;

            ObjectData data = AssetsModel.Instance.GetObjectData(newAssets.id);
            data.object3.UpdateVO();
        }

        CommitHistoryEvent((SceneEvent)e);
    }
}
