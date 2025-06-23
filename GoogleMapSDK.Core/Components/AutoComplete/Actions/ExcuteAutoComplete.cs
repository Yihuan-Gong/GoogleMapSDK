using GoogleMapSDK.Core.Components.AutoComplete.Models;
using GoogleMapSDK.Core.Components.AutoComplete.ViewLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete.Actions
{
    internal class ExcuteAutoComplete<T> : AAutoCompleteAction<T>
    {
        public ExcuteAutoComplete(AutoCompleteViewLogic<T> viewLogic, ActionModel<T> actionModel) : base(viewLogic, actionModel)
        {
        }

        public override void Excute()
        {
            if (actionModel.SelectedIndex == -1)
                return;

            string selectedString = actionModel.Matched[actionModel.SelectedIndex];
            T selectedObject = actionModel.Values[selectedString];
            actionModel.FormerText = selectedString;
            actionModel.Config.AutoCompleteSelected.Invoke(null, selectedObject);
            viewLogic.PresenterAutoCompleteExcuted(selectedString, selectedObject);
            //viewLogic.PresenterHideAutoCompleteBox();
        }
    }
}
