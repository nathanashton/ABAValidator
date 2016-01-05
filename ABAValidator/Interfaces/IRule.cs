namespace ABAValidator.Interfaces
{
    public interface IRule
    {
        Line Line { get; set; }
        string Specification { get; set; }
        IField Field { get; set; }
        Result Validate();
    }
}