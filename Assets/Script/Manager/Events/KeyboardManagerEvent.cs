﻿public class KeyboardManagerEvent : EventObject
{
    public static string REDO = "KeyboardManagerEvent_REDO";
    public static string UNDO = "KeyboardManagerEvent_UNDO";
    public static string LOAD_PROJECT = "KeyboardManagerEvent_LOAD_PROJECT";
    public static string SAVE_PROJECT = "KeyboardManagerEvent_SAVE_PROJECT";
    public static string NEW_PROJECT = "KeyboardManagerEvent_NEW_PROJECT";
    public static string DELETE = "KeyboardManagerEvent_DELETE";
    public static string ESC = "KeyboardManagerEvent_ESC";
    public static string COPY = "KeyboardManagerEvent_COPY";
    public static string PASTE = "KeyboardManagerEvent_PASTE";
    public static string CUT = "KeyboardManagerEvent_CUT";
    public static string COMBINATION = "KeyboardManagerEvent_Combination";
    public static string CANCEL_COMBINATION = "KeyboardManagerEvent_Cancel_Combination";
    public static string FOCUSON_SELECTION = "KeyboardManagerEvent_FocusOn_Selection";

    public static string OPEN_DRAWLINEPANEL = "OPEN_DRAWLINEPANEL";

    public static string LOAD_COMBINATION = "LOAD_COMBINATION";

    public ObjectSprite objectSprite;

    public KeyboardManagerEvent(string types, ObjectSprite objectSprite = null, bool bubbles = false, bool cancelable = false)
        : base(types, bubbles, cancelable)
    {
        this.objectSprite = objectSprite;
    }
}
