using GoogleMapSDK.Contract.Components.AutoComplete.Views;
using GoogleMapSDK.Core.Components.AutoComplete.Models;
using GoogleMapSDK.Core.Components.AutoComplete.ViewLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete.Actions
{
    internal class FindMatchedList<T>
    {
        private readonly IAutoCompleteViewLogic<T> _viewLogic;
        private readonly ActionModel<T> _actionModel;

        public FindMatchedList(IAutoCompleteViewLogic<T> viewLogic, ActionModel<T> actionModel)
        {
            _viewLogic = viewLogic;
            _actionModel = actionModel;
        }

        public async Task ExcuteAsync()
        {
            if (_actionModel.Text == string.Empty)
                return;
            
            if (_actionModel.Text == _actionModel.FormerText) 
                return;
            _actionModel.FormerText = _actionModel.Text;

            string excludeText = _actionModel.Text;

            if (_actionModel.Config.GetValueTask == null || _actionModel.Text.Length == 0)
            {
                //_viewLogic.PresenterHideAutoCompleteBox();
                _viewLogic.PresenterMatchedListNull();
                return;
            }
            _actionModel.Values = await _actionModel.Config.GetValueTask.Invoke(_actionModel.Text);
            _actionModel.Matched = _actionModel.Values.Keys.Where(x =>
            {
                // 用.Contains比對比.StartsWith比對更符合GoogleMap模糊搜尋的運作方式
                // x.StartsWith(_actionModel.Text, StringComparison.CurrentCultureIgnoreCase)
                return x.ToLower().Contains(_actionModel.Text.ToLower()) && excludeText != x;
            }).ToList();

            if (_actionModel.Matched.Count == 0)
            {
                //_viewLogic.PresenterHideAutoCompleteBox();
                _viewLogic.PresenterMatchedListNull();
                return;
            }

            _actionModel.SelectedIndex = 0;
            _viewLogic.PresenterMatchedListFound(_actionModel.Matched);
            _viewLogic.PresenterSelectedIndexChanged(_actionModel.SelectedIndex);
        }
    }
}
