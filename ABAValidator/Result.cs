namespace ABAValidator
{
    using Interfaces;

    public class Result
    {
        public IRule Rule;
        public bool Pass { get; set; }

        public Result ResultPass(IRule rule)
        {
            var r = new Result
            {
                Rule = rule,
                Pass = true
            };
            return r;
        }

        public Result ResultFail(IRule rule)
        {
            var r = new Result
            {
                Rule = rule,
                Pass = false
            };
            return r;
        }
    }
}