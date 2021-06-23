using System;
using System.Collections.Generic;
using System.Globalization;
using Parquet.Properties;

namespace Parquet
{
    /// <summary>
    /// Provides extension methods to <see cref="IDictionary{K, V}"/>.
    /// </summary>
    internal static class IDictionaryExtensions
    {
        /// <summary>Clears the dictionary, then attempts to add all the given elements.</summary>
        /// <param name="dictionaryToAlter">The <see cref="IDictionary{K, V}"/> being altered.</param>
        /// <param name="keyValuePairs">The new content for the <see cref="IDictionary{K, V}"/>.</param>
        /// <returns><c>true</c> if every add succeeded; <c>false</c> otherwise.</returns>
        public static bool TryReplaceWith<TKey, TValue>(this IDictionary<TKey, TValue> dictionaryToAlter, IDictionary<TKey, TValue> keyValuePairs)
        {
            try
            {
                dictionaryToAlter.ReplaceWith(keyValuePairs);
            }
            catch (Exception replaceException)
            {
                Logger.Log(LogLevel.Error,
                           string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotReplaceDictionary, replaceException.Message),
                           replaceException);

                return false;
            }

            return true;
        }

        /// <summary>Clears the dictionary, then attempts to add all the given elements.</summary>
        /// <param name="dictionaryToAlter">The <see cref="IDictionary{K, V}"/> being altered.</param>
        /// <param name="keyValuePairs">The new content for the <see cref="IDictionary{K, V}"/>.</param>
        /// <returns><c>true</c> if every add succeeded; <c>false</c> otherwise.</returns>
        public static bool TryReplaceWith<TKey, TValue>(this IDictionary<TKey, TValue> dictionaryToAlter,
                                                        IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            try
            {
                dictionaryToAlter.ReplaceWith(keyValuePairs);
            }
            catch (Exception replaceException)
            {
                Logger.Log(LogLevel.Error,
                           string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotReplaceDictionary, replaceException.Message),
                           replaceException);

                return false;
            }

            return true;
        }

        /// <summary>Clears the dictionary, then adds all the given elements.</summary>
        /// <param name="dictionaryToAlter">The <see cref="IDictionary{K, V}"/> being altered.</param>
        /// <param name="keyValuePairs">The new content for the <see cref="IDictionary{K, V}"/>.</param>
        /// <returns><c>true</c> if every add succeeded; <c>false</c> otherwise.</returns>
        internal static void ReplaceWith<TKey, TValue>(this IDictionary<TKey, TValue> dictionaryToAlter, IDictionary<TKey, TValue> keyValuePairs)
        {
            dictionaryToAlter.Clear();
            foreach (KeyValuePair<TKey, TValue> kvp in keyValuePairs ?? new Dictionary<TKey, TValue>())
            {
                dictionaryToAlter[kvp.Key] = kvp.Value;
            }
        }

        /// <summary>Clears the dictionary, then adds all the given elements.</summary>
        /// <param name="dictionaryToAlter">The <see cref="IDictionary{K, V}"/> being altered.</param>
        /// <param name="keyValuePairs">The new content for the <see cref="IDictionary{K, V}"/>.</param>
        /// <returns><c>true</c> if every add succeeded; <c>false</c> otherwise.</returns>
        internal static void ReplaceWith<TKey, TValue>(this IDictionary<TKey, TValue> dictionaryToAlter,
                                                       IEnumerable<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            dictionaryToAlter.Clear();
            foreach (KeyValuePair<TKey, TValue> kvp in keyValuePairs ?? new Dictionary<TKey, TValue>())
            {
                dictionaryToAlter[kvp.Key] = kvp.Value;
            }
        }
    }
}
