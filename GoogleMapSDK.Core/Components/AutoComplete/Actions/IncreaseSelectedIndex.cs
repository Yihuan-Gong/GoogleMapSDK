using GoogleMapSDK.Core.Components.AutoComplete.Models;
using GoogleMapSDK.Core.Components.AutoComplete.ViewLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete.Actions
{
    internal class IncreaseSelectedIndex<T> : AAutoCompleteAction<T>
    {
        public IncreaseSelectedIndex(AutoCompleteViewLogic<T> viewLogic, ActionModel<T> actionModel) : base(viewLogic, actionModel)
        {
        }

        public override void Excute()
        {
            if (actionModel.SelectedIndex == -1)
            {
                return;
            }

            if ( actionModel.SelectedIndex < actionModel.Matched.Count -1)
                actionModel.SelectedIndex++;

            viewLogic.PresenterSelectedIndexChanged(actionModel.SelectedIndex);
        }
    }
}
