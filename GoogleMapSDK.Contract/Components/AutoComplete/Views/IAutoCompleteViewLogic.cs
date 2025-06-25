using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.Components.AutoComplete.Models;

namespace GoogleMapSDK.Contract.Components.AutoComplete.Views
{
    public interface IAutoCompleteViewLogic<T>
    {
        IAutoCompleteConfig<T> Config { set; }

        // 這裡清除了將View的request轉送Presenter的轉接層
        // 因為這樣的話寫View還要透過Intellisece才知道有哪些東西可以送到presenter，還有可能漏掉。
        // 所以這邊改成ViewLogic用InitializeComponent帶參數的方式
        // 將Presenter可以用的data input全部封裝成Action並傳給View
        // 然後讓View自行決定如何用UI將這些Action接上去

        // Response from presenter
        void PresenterMatchedListFound(List<string> matched);
        void PresenterMatchedListNull();
        void PresenterSelectedIndexChanged(int index);
        void PresenterAutoCompleteExcuted(string text, T value);
    }
}
