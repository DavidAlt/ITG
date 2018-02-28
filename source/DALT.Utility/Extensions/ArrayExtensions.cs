using System;
using System.Collections;
using System.Text;

namespace DALT.Utility.Extensions
{
    public static class ArrayExtensions
    {
        // create a subset from a range of indices
        public static T[] ExtractSubset<T>(this T[] array, int startIndex, int length)
        {
            T[] subset = new T[length];
            Array.Copy(array, startIndex, subset, 0, length);
            return subset;
        }

        // create a subset from a specific list of indices
        public static T[] ExtractSpecificSubset<T>(this T[] array, params int[] indices)
        {
            T[] subset = new T[indices.Length];
            for (int i = 0; i < indices.Length; i++)
            {
                subset[i] = array[indices[i]];
            }
            return subset;
        }

        // specifically for byte arrays
        public static string Print(this byte[] values)
        {
            var sb = new StringBuilder();
            
            for (int i = 0; i < values.Length-1; i++)
            {
                sb.Append(values[i].ToString() + " ");
            }
            sb.Append(values[values.Length-1].ToString());
            return sb.ToString();
        }

        public static byte[] ReverseByteOrder(this byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }
    }
}