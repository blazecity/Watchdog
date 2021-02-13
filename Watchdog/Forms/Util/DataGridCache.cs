using ExShift.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Forms.Util
{
    public class DataGridCache<T> where T : IPersistable, new()
    {
        public HashSet<T> ItemsToUpdate { get; }
        public HashSet<T> ItemsToAdd { get; }
        public HashSet<T> ItemsToDelete { get; }

        public DataGridCache()
        {
            ItemsToUpdate = new HashSet<T>();
            ItemsToAdd = new HashSet<T>();
            ItemsToDelete = new HashSet<T>();
        }

        public void CacheItemsToAdd(params T[] items)
        {
            foreach (T item in items)
            {
                ItemsToAdd.Add(item);
            }
        }

        public void CacheItemsToUpdate(params T[] items)
        {
            foreach (T item in items)
            {
                if (ItemsToAdd.Contains(item))
                {
                    continue;
                }
                ItemsToUpdate.Add(item);
            }
        }

        public void CacheItemsToDelete(params T[] items)
        {
            foreach (T item in items)
            {
                if (ItemsToAdd.Contains(item))
                {
                    ItemsToAdd.Remove(item);
                }

                if (ItemsToUpdate.Contains(item))
                {
                    ItemsToUpdate.Remove(item);
                }

                ItemsToDelete.Add(item);
            }
        }

        public void ClearCache()
        {
            ItemsToAdd.Clear();
            ItemsToUpdate.Clear();
            ItemsToDelete.Clear();
        }

        public void ExecutePersistenceActions()
        {
            foreach (T item in ItemsToAdd)
            {
                ExcelObjectMapper.Persist(item);
            }

            foreach (T item in ItemsToUpdate)
            {
                ExcelObjectMapper.Update(item);
            }

            foreach (T item in ItemsToDelete)
            {
                ExcelObjectMapper.Delete(item);
            }
            ClearCache();
        }
    }
}
