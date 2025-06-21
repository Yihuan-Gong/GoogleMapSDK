using GoogleMapSDK.Contract.AutoComplete.Models;
using GoogleMapSDK.Core.AutoComplete.ViewLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.AutoComplete.Actions
{
    internal class DecreaseSelectedIndex<T> : AAutoCompleteAction<T>
    {
        public DecreaseSelectedIndex(AutoCompleteViewLogic<T> viewLogic, ActionModel<T> actionModel) : base(viewLogic, actionModel)
        {
        }

        public override void Excute()
        {
            if (actionModel.SelectedIndex == -1)
            {
                return;
            }

            if (actionModel.SelectedIndex > 0)
                actionModel.SelectedIndex--;

            viewLogic.PresenterSelectedIndexChanged(actionModel.SelectedIndex);
        }
    }
}
