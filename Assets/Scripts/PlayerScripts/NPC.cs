using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NPC file", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
private DialogueManager dialogueManager;
  public string NPCname;
  [TextArea(3, 15)]
  public string[] dialogue;
  [TextArea(3, 15)]
  public string[] playerDialogue;

}

