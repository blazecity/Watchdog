using ExShift.Mapping;
using System.Windows.Controls;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlMaxRatingRatio.xaml
    /// </summary>
    public partial class UserControlMaxRatingRatio : UserControl, IEmbeddedRuleUserControl
    {
        private readonly RatingRatioRuleViewModel viewModel;

        public UserControlMaxRatingRatio()
        {
            InitializeComponent();
            viewModel = new RatingRatioRuleViewModel();
            DataContext = viewModel;
        }

        public bool EditMode { get; set; }
        public Rule PassedRule { get; set; }

        public Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
        {
            RatingRatioRule newRule = new RatingRatioRule
            {
                Id = uniqueId,
                RuleKind = ruleKind,
                Name = ruleName,
                RatingClass = viewModel.RatingClass,
                MaxRatio = viewModel.Ratio
            };
            ExcelObjectMapper.Persist(newRule);
            return newRule;
        }
    }
}
