using GoogleMapSDK.Contract.AutoComplete.Models;
using GoogleMapSDK.Core.AutoComplete.ViewLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.AutoComplete.Actions
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

            string selected = actionModel.Matched[actionModel.SelectedIndex];
            actionModel.FormerText = selected;
            viewLogic.PresenterAutoCompleteExcuted(selected, actionModel.Values[selected]);
            viewLogic.PresenterHideAutoCompleteBox();
        }
    }
}
