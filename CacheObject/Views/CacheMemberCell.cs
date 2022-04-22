using System.Linq;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.UI;
using UniverseLib.UI;
using UniverseLib.UI.Models;

namespace UnityExplorer.CacheObject.Views
{
    public class CacheMemberCell : CacheObjectCell
    {
        public CacheMember MemberOccupant => Occupant as CacheMember;

        public void XRef()
        {
            ExplorerCore.Log($"Xref For Method: {(Occupant as CacheMethod)?.MethodInfo.Name}: {string.Join(", ", XrefScanner.XrefScan((Occupant as CacheMethod)?.MethodInfo).Where(a => a.Type == XrefType.Global).Select(o => o.ReadAsObject().ToString()))}");
        }

        public void UsedBy()
        {
            ExplorerCore.Log($"UsedBy For Method: {(Occupant as CacheMethod)?.MethodInfo.Name}: {string.Join(", ", XrefScanner.UsedBy((Occupant as CacheMethod)?.MethodInfo).Where(a => a.Type == XrefType.Global).Select(o => o.TryResolve().ToString()))}");
        }

        public GameObject EvaluateHolder;
        public ButtonRef EvaluateButton;

        public ButtonRef XRefButton;
        public ButtonRef UsedByButton;

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
            UIFactory.SetLayoutElement(EvaluateButton.Component.gameObject, 100, 25);
            EvaluateButton.OnClick += EvaluateClicked;

            XRefButton = UIFactory.CreateButton(EvaluateHolder, "XRefButton", "XRef", new Color(0.15f, 0.15f, 0.15f));
            UIFactory.SetLayoutElement(XRefButton.Component.gameObject, 100, 25);
            XRefButton.OnClick += XRef;

            UsedByButton = UIFactory.CreateButton(EvaluateHolder, "UsedByButton", "Used By", new Color(0.15f, 0.15f, 0.15f));
            UIFactory.SetLayoutElement(UsedByButton.Component.gameObject, 100, 25);
            UsedByButton.OnClick += UsedBy;
        }
    }
}
