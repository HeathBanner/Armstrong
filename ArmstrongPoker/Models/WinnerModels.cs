using System;
using System.Diagnostics.CodeAnalysis;

namespace ArmstrongPoker.Models
{
    public class WinnerModels : IEquatable<WinnerModels>
    {
        public int playerId { get; set; }

        public bool Equals([AllowNull] WinnerModels other)
        {
            throw new NotImplementedException();
        }
    }
}
