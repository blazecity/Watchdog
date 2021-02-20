using Watchdog.Entities;

namespace Watchdog.Forms.Util
{
    public interface IEmbeddedRuleUserControl
    {
        bool EditMode {get; set; }
        Rule PassedRule { get; set; }
        Rule Submit(string uniqueId, RuleKind ruleKind, string ruleName);
    }
}
