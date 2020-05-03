using Doozy.Engine;
using UnityEngine;

public class ToggleAbilityListUI : MonoBehaviour
{
    private bool UIState = false;
    private Animator animator;
    private string SHOW_ABILITY_LIST_VIEW_EVENT = "ShowAbilityListView";
    private string HIDE_ABILITY_LIST_VIEW_EVENT = "HideAbilityListView";
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
            GameEventMessage.SendEvent(SHOW_ABILITY_LIST_VIEW_EVENT);
            animator.SetBool(ANIM_PARAM, UIState);
        }
        else
        {
            GameEventMessage.SendEvent(HIDE_ABILITY_LIST_VIEW_EVENT);
            animator.SetBool(ANIM_PARAM, UIState);
        }

    }
}
