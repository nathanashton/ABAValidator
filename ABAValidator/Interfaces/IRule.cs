namespace ABAValidator.Interfaces
{
    public interface IRule
    {
        Line Line { get; set; }
        string Specification { get; set; }
        int CharacterPositionStart { get; set; }
        int CharacterPositionEnd { get; set; }
        Result Validate();
    }
}