using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace GameBooster
{

    public enum ActionGroupPlace { Anywhere, Self, Children, Parent }

    [Comment(
        @"Stores actions that can be executed

Methods:
	void Execute()
    void Execute(string id)"
    )]
    public class ActionGroup : GameBoosterBehaviour
    {

        [Tooltip("Actions identifier")]
        public string id;

        [Tooltip("Actions to be executed")]
        public UnityEvent actions;

        [Button]
        public void Execute()
        {
            actions.Invoke();
        }

        public void Execute(string id)
        {
            var actionGroup = FindActionGroup(transform, ActionGroupPlace.Self, id);
            if (actionGroup)
                actionGroup.Execute();
        }

        public static ActionGroup FindActionGroup(Transform origin, ActionGroupPlace place, string id)
        {
            switch (place)
            {
                case ActionGroupPlace.Anywhere:
                    return GameObject.FindObjectsOfType<ActionGroup>().Where(e => e.id == id).FirstOrDefault();
                case ActionGroupPlace.Children:
                    return origin.GetComponentsInChildren<ActionGroup>().Where(e => e.id == id).FirstOrDefault();
                case ActionGroupPlace.Parent:
                    return origin.GetComponentsInParent<ActionGroup>().Where(e => e.id == id).FirstOrDefault();
                case ActionGroupPlace.Self:
                    return origin.GetComponents<ActionGroup>().Where(e => e.id == id).FirstOrDefault();
            }
            return null;
        }

    }
}
