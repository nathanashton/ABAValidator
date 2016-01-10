namespace ABAValidator.Interfaces
{
    public interface IRule
    {
        string Input { get; set; }
        string Specification { get; set; }
        Result Validate();
    }
}