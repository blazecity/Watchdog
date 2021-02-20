using ExShift.Mapping;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Watchdog.Entities;

namespace Watchdog.Forms.Util
{
    public class UserControlCustomAllowBanList<T> : UserControl, IEmbeddedRuleUserControl where T: IPersistable, new()
    {
        protected readonly ObservableCollection<AllowBanListChildViewModel<T>> viewModelCollection;
        public bool EditMode { get; set; }
        public Rule PassedRule { get; set; }

        public UserControlCustomAllowBanList()
        {
            viewModelCollection = new ObservableCollection<AllowBanListChildViewModel<T>>();
            foreach (T item in ExcelObjectMapper.GetAllObjects<T>())
            {
                AllowBanListChildViewModel<T> viewModelItem = new AllowBanListChildViewModel<T>
                {
                    IsChecked = false,
                    BoundObject = item
                };
                viewModelCollection.Add(viewModelItem);
            }
        }

        public void BindData(DataGrid dataGrid)
        {
            dataGrid.ItemsSource = viewModelCollection;
        }

        public List<T> GetCheckedItems()
        {
            List<T> checkedItems = new List<T>();
            foreach (AllowBanListChildViewModel<T> item in viewModelCollection)
            {
                if (item.IsChecked)
                {
                    checkedItems.Add(item.BoundObject);
                }
            }
            return checkedItems;
        }

        public virtual Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
        {
            Rule rule = new Rule
            {
                Id = uniqueId,
                RuleKind = ruleKind,
                Name = ruleName
            };
            return rule;
        }
    }
}
