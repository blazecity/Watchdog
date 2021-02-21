using ExShift.Mapping;
using System.Windows.Controls;
using Watchdog.Entities;
using Watchdog.Forms.Util;

namespace Watchdog.Forms.RuleAdministration.RuleView
{
    /// <summary>
    /// Interaktionslogik für UserControlWithOneNumericValue.xaml
    /// </summary>
    public partial class UserControlWithOneNumericValue : UserControl, IEmbeddedRuleUserControl
    {
        public bool EditMode { get; set; }
        public Rule PassedRule { get; set; }

        private readonly NumericViewModel nvm;

        public UserControlWithOneNumericValue()
        {
            InitializeComponent();
            nvm = new NumericViewModel();
            Value.DataContext = nvm;
        }

        public Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName)
        {
            
            NumericRule numericRule = new NumericRule 
            { 
                Id = uniqueId,
                RuleKind = ruleKind,
                Name = ruleName,
                NumericValue = nvm.Value 
            };
            ExcelObjectMapper.Persist(numericRule);
            return numericRule;
        }

        public Rule SubmitEdit()
        {
            if (EditMode)
            {
                ExcelObjectMapper.Update(PassedRule as NumericRule);
            }
            return PassedRule;
        }
    }
}
