namespace ABAValidator.Interfaces
{
    using System.Collections.Generic;

    public interface IField
    {
        List<IRule> Rules { get; set; }
        int CharacterPositionStart { get; set; }
        int CharacterPositionEnd { get; set; }
        string FieldDescription { get; set; }
        Line Line { get; set; }
        List<Result> RuleResults { get; set; }
        void RunRules();
        int Length { get; set; }

    }
}