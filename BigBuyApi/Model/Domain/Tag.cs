using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBuyApi.Model.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LinkRewrite { get; set; }
        public string Language { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Tag other)
            {
                return Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
