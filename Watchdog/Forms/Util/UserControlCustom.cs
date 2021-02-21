using ExShift.Mapping;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Watchdog.Forms.Util
{
    public class UserControlCustom<T> : UserControl where T : IPersistable, new()
    {
        protected ObservableCollection<T> observableCollection;
        protected readonly DataGridCache<T> dataGridCache;
        protected DataGrid dataGrid;

        public UserControlCustom()
        {
            dataGridCache = new DataGridCache<T>();
            
        }

        public void BindData(DataGrid controlToBind, bool loadEntries = true, bool disableCollectionChanged = false)
        {
            dataGrid = controlToBind;
            if (!disableCollectionChanged)
            {
                if (loadEntries)
                {
                    observableCollection = new ObservableCollection<T>(ExcelObjectMapper.GetAllObjects<T>());
                }
                observableCollection.CollectionChanged += CollectionChanged;
            }
            else
            {
                observableCollection = new ObservableCollection<T>();
            }
            controlToBind.ItemsSource = observableCollection;
        }

        public virtual void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            if (observableCollection.Count == 0)
            {
                return;
            }

            T item = (T) dataGrid.SelectedItem;
            dataGridCache.CacheItemsToDelete(item);
            observableCollection.Remove(item);
        }

        public void DgRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            T selectedAssetClass = (T) dataGrid.SelectedItem;
            dataGridCache.CacheItemsToUpdate(selectedAssetClass);
        }

        public void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                dataGridCache.CacheItemsToAdd(e.NewItems.Cast<T>().ToArray());
            }
        }

        public virtual void ButtonSubmitClick(object sender, RoutedEventArgs e)
        {
            dataGridCache.ExecutePersistenceActions();
        }

    }
}
