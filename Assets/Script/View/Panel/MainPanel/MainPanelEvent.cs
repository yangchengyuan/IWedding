﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelEvent : EventObject
{
	public static string CreatePlan_Click = "MainPanelEvent_CreatePlan_Click";
	public static string RealPlan_Click = "MainPanelEvent_RealPlan_Click";

	public MainPanelEvent(string types, bool bubbles = false, bool cancelable = false)
		: base(types, bubbles, cancelable)
	{
	}
}
