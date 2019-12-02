using System;
using System.Diagnostics.CodeAnalysis;

namespace ArmstrongPoker.Models
{
    public class Pair : IEquatable<Pair>
    {
        public int PlayerId { get; set; }
        public int Total { get; set; }

        public bool Equals([AllowNull] Pair other)
        {
            throw new NotImplementedException();
        }
    }
}
