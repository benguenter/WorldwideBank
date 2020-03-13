using System.Collections.Generic;
using System.Linq;

namespace WorldWideBank.Domain
{
    public static class Result
    {
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(Enumerable.Empty<string>(), value);
        }

        public static Result<T> Error<T>(params string[] errors)
        {
            return new Result<T>(errors, default);
        }
    }

    public class Result<T>
    {
        internal Result(IEnumerable<string> errors, T value)
        {
            this.Errors = errors;
            this.Value = value;
        }

        public IEnumerable<string> Errors { get; }
        public T Value { get; }

        public bool IsError => this.Errors.Any();
        public bool IsOk => !this.Errors.Any();
    }
}