using GoogleMapSDK.Core.Components.AutoComplete.Actions;
using GoogleMapSDK.Core.Components.AutoComplete.Models;
using GoogleMapSDK.Core.Components.AutoComplete.ViewLogic;
using GoogleMapSDK.Contract.Components.AutoComplete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete.Presenters
{
    public class AutoCompletePresenter<T> : IAutoCompletePresenter<T>
    {
        protected readonly AutoCompleteViewLogic<T> viewLogic;
        private readonly ActionModel<T> _actionModel;

        public virtual Dictionary<Keys, AutoCompleteAction> KeyAction =>
            new Dictionary<Keys, AutoCompleteAction>()
            {
                { Keys.Tab, AutoCompleteAction.ExcuteAutoComplete },
                { Keys.Enter, AutoCompleteAction.ExcuteAutoComplete },
                { Keys.Up, AutoCompleteAction.DecreaseSelectedIndex },
                { Keys.Down, AutoCompleteAction.IncreaseSelectedIndex },
            };

        public IAutoCompleteConfig<T> Config { set => _actionModel.Config = value; }

        public AutoCompletePresenter(AutoCompleteViewLogic<T> viewLogic)
        {
            this.viewLogic = viewLogic;
            _actionModel = new ActionModel<T>();
        }

        public void ChangeSelectedIndex(int index)
        {
            _actionModel.SelectedIndex = index;
            viewLogic.PresenterSelectedIndexChanged(_actionModel.SelectedIndex);
        }

        public async Task KeyUpAsync(string text)
        {
            _actionModel.Text = text;
            var action = new FindMatchedList<T>(viewLogic, _actionModel);
            await action.ExcuteAsync();
        }

        public void KeyDown(Keys key)
        {
            if (!KeyAction.ContainsKey(key))
                return;
            
            string className = $"{KeyAction[key]}";

            var types = Assembly.GetExecutingAssembly().DefinedTypes;  // .DefinedTypes or .GetTypes()
            var type = types
                .FirstOrDefault(x => x.FullName.Contains(className))
                .MakeGenericType(typeof(T));

            var action = Activator.CreateInstance(type, viewLogic, _actionModel)
                as AAutoCompleteAction<T>;
            action.Excute();
        }
    }
}
