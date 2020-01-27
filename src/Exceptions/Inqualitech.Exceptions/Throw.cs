using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the given value is null.
        /// </summary>
        public static void IfNull<TValue>(TValue value, string parameterName)
        {
            Throw<ArgumentNullException>.If(value == null, parameterName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the given value is null.
        /// </summary>
        public static void IfNullOrEmpty<TValue>(IEnumerable<TValue> value, string parameterName)
        {
            Throw<ArgumentException>.If(value == null || !value.Any(), string.Format(Inqualitech.Exceptions.Resources.CollectionCannotBeNullOrEmpty, parameterName));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the given value is null, empty or whitespace.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        public static void IfNullOrEmptyOrWhitespace(string value, string parameterName)
        {
            Throw<ArgumentException>.If(string.IsNullOrWhiteSpace(value), string.Format(Inqualitech.Exceptions.Resources.StringCannotBeNullOrEmpty, parameterName));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the given condition is true.
        /// </summary>
        public static void If(bool condition, string message)
        {
            Throw<ArgumentException>.If(condition, message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the given condition is true.
        /// </summary>
        public static void ThrowIf<TValue>(this TValue source, Func<TValue, bool> predicate, string message)
        {
            Throw<ArgumentException>.If(predicate(source), message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the given value is outside of the specified range.
        /// </summary>
        public static void IfOutOfRange<TValue>(TValue value, string paramName, TValue? min = null, TValue? max = null)
            where TValue : struct, IComparable<TValue>
        {
            if (min.HasValue && value.CompareTo(min.Value) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format("Expected: >= {0}, but was {1}", min, value));
            }

            if (max.HasValue && value.CompareTo(max.Value) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format("Expected: <= {0}, but was {1}", max, value));
            }
        }
    }
}
