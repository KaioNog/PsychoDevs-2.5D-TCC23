using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct DialogueMulti {

    public string name;
    [TextArea(5, 10)]
    public string text;
    public Sprite imageProfile;

}

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/TalkScript", order = 1)]
public class DialogueData : ScriptableObject {

    public List<DialogueMulti> talkScript;

}