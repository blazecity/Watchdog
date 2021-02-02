using ExShift.Mapping;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.Settings
{
    /// <summary>
    /// Interaktionslogik für UserControlSettingsRatingAgencies.xaml
    /// </summary>
    public partial class UserControlSettingsRatingAgencies : UserControl
    {
        private readonly ObservableCollection<RatingAgency> ratingAgencies;
        private ObservableCollection<Rating> ratings;
        private readonly DataGridCache<RatingAgency> ratingAgenciesCache;
        private readonly Dictionary<RatingAgency, DataGridCache<Rating>> ratingsCache;
        private bool lockedRow;
        private bool commitSuccessful;

        public UserControlSettingsRatingAgencies()
        {
            ratingAgencies = new ObservableCollection<RatingAgency>();
            ratingAgencies.CollectionChanged += RatingAgenciesCollectionChanged;
            ratings = new ObservableCollection<Rating>();
            ratingAgenciesCache = new DataGridCache<RatingAgency>();
            ratingsCache = new Dictionary<RatingAgency, DataGridCache<Rating>>();
            InitializeComponent();
            LoadRatingAgencies();
            DgRatingAgencies.ItemsSource = ratingAgencies;
            DgRatings.ItemsSource = ratings;
            DgRatings.IsReadOnly = true;
        }

        private void LoadRatingAgencies()
        {
            foreach (RatingAgency ratingAgency in ExcelObjectMapper.GetAllObjects<RatingAgency>())
            {
                ratingAgencies.Add(ratingAgency);
            }
        }

        private void RatingAgenciesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(DgRatingAgencies.SelectedItem is RatingAgency selectedAgency) || selectedAgency.ShortName == "" || selectedAgency.Name == null)
            {
                DgRatings.IsReadOnly = true;
                return;
            } 

            ResetRatingsCollection(GetRatingsByAgency(selectedAgency));
            if (ratingsCache.TryGetValue(selectedAgency, out DataGridCache<Rating> ratingCache))
            {
                ResetRatingsCollection(ratings.Except(ratingCache.ItemsToDelete));
            }
            DgRatings.IsReadOnly = false;
        }

        private void RatingsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RatingAgency selectedAgency = DgRatingAgencies.SelectedItem as RatingAgency;
            if (e.NewItems != null)
            {
                IEnumerable<Rating> newRatings = e.NewItems.Cast<Rating>();
                if (ratingsCache.TryGetValue(selectedAgency, out DataGridCache<Rating> ratingCache))
                {
                    SetAgencyAndCache(selectedAgency, newRatings, ratingCache);
                }

                else
                {
                    DataGridCache<Rating> newCache = new DataGridCache<Rating>();
                    ratingsCache.Add(selectedAgency, newCache);
                    SetAgencyAndCache(selectedAgency, newRatings, newCache);
                }
            }
        }

        private void SetAgencyAndCache(RatingAgency agency, IEnumerable<Rating> ratings, DataGridCache<Rating> cache)
        {
            foreach (Rating r in ratings)
            {
                r.Agency = agency;
                cache.CacheItemsToAdd(r);
            }
        }

        private void RatingsRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (!lockedRow)
            {
                lockedRow = true;
                commitSuccessful = DgRatings.CommitEdit();
                lockedRow = false;
            }

            if (!commitSuccessful)
            {
                return;
            }

            commitSuccessful = false;
            
            Rating selectedRating = DgRatings.SelectedItem as Rating;
            if (string.IsNullOrEmpty(selectedRating.Id))
            {
                if (!string.IsNullOrEmpty(selectedRating.RatingCode))
                {
                    selectedRating.Id = string.Concat(selectedRating.RatingCode, selectedRating.Agency.ShortName);
                } 
                else
                {
                    return;
                }
            }

            if (ratingsCache.TryGetValue(selectedRating.Agency, out DataGridCache<Rating> ratingCache))
            {
                ratingCache.CacheItemsToUpdate(GetRatingsByAgency(selectedRating.Agency).ToArray());
            }

            else
            {
                DataGridCache<Rating> newCache = new DataGridCache<Rating>();
                newCache.CacheItemsToUpdate(selectedRating);
                ratingsCache.Add(selectedRating.Agency, newCache);
            }
        }

        private void RatingAgenciesRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            RatingAgency selectedAgency = DgRatingAgencies.SelectedItem as RatingAgency;
            ratingAgenciesCache.CacheItemsToUpdate(selectedAgency);
        }

        private void RatingAgenciesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                ratingAgenciesCache.CacheItemsToAdd(e.NewItems.Cast<RatingAgency>().ToArray());
            }
        }

        private void ResetRatingsCollection(IEnumerable<Rating> initalList)
        {
            ratings = new ObservableCollection<Rating>(initalList);
            ratings.CollectionChanged += RatingsCollectionChanged;
            DgRatings.ItemsSource = ratings;
        }

        private List<Rating> GetRatingsByAgency(RatingAgency ratingAgency)
        {
            List<Rating> resultRatings = Query<Rating>.Select()
                                                      .Where(string.Concat("RatingAgency = ", AttributeHelper.GetPrimaryKey(ratingAgency)))
                                                      .Run();

            if (ratingsCache.TryGetValue(ratingAgency, out DataGridCache<Rating> ratingCache))
            {
                return ratingCache.ItemsToAdd.Union(resultRatings).ToList();
            }
            
            return resultRatings;
        }

        private void RatingAgenciesMenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            if (ratingAgencies.Count == 0)
            {
                return;
            }

            RatingAgency selectedAgency = DgRatingAgencies.SelectedItem as RatingAgency;
            ratingAgenciesCache.CacheItemsToDelete(selectedAgency);
            ratingAgencies.Remove(selectedAgency);
            if (ratingsCache.TryGetValue(selectedAgency, out DataGridCache<Rating> ratingCache))
            {
                ratingCache.CacheItemsToDelete(GetRatingsByAgency(selectedAgency).ToArray());
            }
            else
            {
                DataGridCache<Rating> newCache = new DataGridCache<Rating>();
                newCache.CacheItemsToDelete(GetRatingsByAgency(selectedAgency).ToArray());
                ratingsCache.Add(selectedAgency, newCache);
            }
            ratings.Clear();        
        }

        private void RatingsMenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            if (ratings.Count == 0)
            {
                return;
            }

            Rating selectedRating = DgRatings.SelectedItem as Rating;
            if (ratingsCache.TryGetValue(selectedRating.Agency, out DataGridCache<Rating> ratingCache))
            {
                ratingCache.CacheItemsToDelete(selectedRating);
            }
            else
            {
                DataGridCache<Rating> newCache = new DataGridCache<Rating>();
                newCache.CacheItemsToDelete(selectedRating);
                ratingsCache.Add(selectedRating.Agency, newCache);
            }
            ratings.Remove(selectedRating);
        }

        private void ButtonSubmitClick(object sender, RoutedEventArgs e)
        {
            ratingAgenciesCache.ExecutePersistenceActions();
            foreach (DataGridCache<Rating> cache in ratingsCache.Values)
            {
                cache.ExecutePersistenceActions();
            }
        }
    }
}
