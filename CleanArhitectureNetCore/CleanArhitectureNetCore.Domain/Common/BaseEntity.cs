using System.Text.RegularExpressions;

namespace CleanArhitectureNetCore.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        protected virtual bool _Match(string pattern, string value) => new Regex(pattern).IsMatch(value);
    }
}
