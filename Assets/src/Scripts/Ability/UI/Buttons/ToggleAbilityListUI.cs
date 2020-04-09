using Doozy.Engine;
using UnityEngine;

public class ToggleAbilityListUI : MonoBehaviour
{
  private bool UIState = false;
  private Animator animator;
  private string ANIM_PARAM = "AbilityButtonState";

  private void Start()
  {
    GameObject GO = transform.parent.gameObject;
    animator = GO.GetComponentInChildren<Animator>();
  }

  public void ToggleUI()
  {
    UIState = UIState ? false : true;
    if (UIState)
    {
      GameEventMessage.SendEvent("ShowAbilityListView");
      animator.SetBool(ANIM_PARAM, UIState);
    }
    else
    {
      GameEventMessage.SendEvent("HideAbilityListView");
      animator.SetBool(ANIM_PARAM, UIState);
    }

  }
}
