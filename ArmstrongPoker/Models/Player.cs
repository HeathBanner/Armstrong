using System;
using System.Diagnostics.CodeAnalysis;

namespace ArmstrongPoker.Models
{
    public class Player : IEquatable<Player>
    {
        public int Id { get; set; }
        public Card Card1 { get; set; }
        public Card Card2 { get; set; }
        public Card Card3 { get; set; }

        public bool Equals([AllowNull] Player other)
        {
            throw new NotImplementedException();
        }
    }

    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
    }
}
