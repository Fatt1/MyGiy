namespace Demo.Contract.Abstractions.Shared
{
    public abstract class QueryStringParameter
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
