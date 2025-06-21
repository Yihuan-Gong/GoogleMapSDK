using GoogleMapSDK.Contract.Components.AutoComplete.Models;
using GoogleMapSDK.Core.Components.AutoComplete.ViewLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete.Actions
{
    internal abstract class AAutoCompleteAction<T>
    {
        protected AutoCompleteViewLogic<T> viewLogic;
        protected ActionModel<T> actionModel;
        

        protected AAutoCompleteAction(AutoCompleteViewLogic<T> viewLogic, ActionModel<T> actionModel)
        {
            this.viewLogic = viewLogic;
            this.actionModel = actionModel;
        }

        public abstract void Excute();
    }
}
