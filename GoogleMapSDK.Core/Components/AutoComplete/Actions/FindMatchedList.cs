using GoogleMapSDK.Contract.Components.AutoComplete.Models;
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
        private readonly AutoCompleteViewLogic<T> _viewLogic;
        private readonly ActionModel<T> _actionModel;

        public FindMatchedList(AutoCompleteViewLogic<T> viewLogic, ActionModel<T> actionModel)
        {
            _viewLogic = viewLogic;
            _actionModel = actionModel;
        }

        public async Task ExcuteAsync()
        {
            if (_actionModel.Text == _actionModel.FormerText) 
                return;
            _actionModel.FormerText = _actionModel.Text;

            string excludeText = _actionModel.Text;

            if (_actionModel.ValuesTask == null || _actionModel.Text.Length == 0)
            {
                _viewLogic.PresenterHideAutoCompleteBox();
                return;
            }
            _actionModel.Values = await _actionModel.ValuesTask;
            _actionModel.Matched = _actionModel.Values.Keys.Where(x =>
            {
                return x.StartsWith(_actionModel.Text, StringComparison.OrdinalIgnoreCase) &&
                    excludeText != x;
            }).ToList();

            if (_actionModel.Matched.Count == 0)
            {
                _viewLogic.PresenterHideAutoCompleteBox();
                return;
            }

            _actionModel.SelectedIndex = 0;
            _viewLogic.PresenterMatchedListFound(_actionModel.Matched);
            _viewLogic.PresenterSelectedIndexChanged(_actionModel.SelectedIndex);
        }
    }
}
