using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBooster
{

    [Comment(
        @"Execute actions on some ActionGroup reference

Methods:
	void Execute()
    void Execute(string id)"
    )]
    public class ActionGroupReference : GameBoosterBehaviour
    {

        [Tooltip("ActionGroup identifier")]
        public string actionGroupId;

        protected ActionGroup m_actionGroup;

        [Tooltip("ActionGroup identifier")]
        public ActionGroupPlace place;

        void OnEnable()
        {
            if (!m_actionGroup)
            {
                m_actionGroup = ActionGroup.FindActionGroup(transform, place, actionGroupId);
            }
        }

        [Button]
        public void Execute()
        {
            if (m_actionGroup)
                m_actionGroup.Execute();
        }
        public void Execute(string id)
        {
            var actionGroup = ActionGroup.FindActionGroup(transform, place, id);
            if (actionGroup)
                actionGroup.Execute();
        }

    }
}