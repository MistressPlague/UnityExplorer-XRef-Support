using UnityEngine;
using UnityEngine.UI;
using UniverseLib.UI;
using UniverseLib.UI.Models;

namespace UnityExplorer.CacheObject.Views
{
    public class CacheMemberCell : CacheObjectCell
    {
        public CacheMember MemberOccupant => Occupant as CacheMember;

        public GameObject EvaluateHolder;
        public ButtonRef EvaluateButton;
        public ButtonRef XRefButton;
        public ButtonRef UsedByButton;
        public bool Init;

        protected virtual void EvaluateClicked()
        {
            this.MemberOccupant.OnEvaluateClicked();
        }

        protected override void ConstructEvaluateHolder(GameObject parent)
        {
            // Evaluate vert group

            EvaluateHolder = UIFactory.CreateUIObject("EvalGroup", parent);
            UIFactory.SetLayoutGroup<VerticalLayoutGroup>(EvaluateHolder, false, false, true, true, 3);
            UIFactory.SetLayoutElement(EvaluateHolder, minHeight: 25, flexibleWidth: 9999, flexibleHeight: 775);

            EvaluateButton = UIFactory.CreateButton(EvaluateHolder, "EvaluateButton", "Evaluate", new Color(0.15f, 0.15f, 0.15f));
            UIFactory.SetLayoutElement(EvaluateButton.Component.gameObject, minWidth: 100, minHeight: 25);
            EvaluateButton.OnClick += EvaluateClicked;

            XRefButton = UIFactory.CreateButton(EvaluateHolder, "XRefButton", "XRef", new Color(0.15f, 0.15f, 0.15f));
            UIFactory.SetLayoutElement(XRefButton.Component.gameObject, minWidth: 100, minHeight: 25);

            UsedByButton = UIFactory.CreateButton(EvaluateHolder, "UsedByButton", "Used By", new Color(0.15f, 0.15f, 0.15f));
            UIFactory.SetLayoutElement(UsedByButton.Component.gameObject, minWidth: 100, minHeight: 25);
        }
    }
}
