using System;

namespace Entities
{
    public class Award
    {
        public string Title { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
