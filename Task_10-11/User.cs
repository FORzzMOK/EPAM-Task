using System;
using System.Collections.Generic;

namespace Entities
{
    public class User//Нужно вернуть ID из DAL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Avatar { get; set; }
        public int Age => (int)(DateTime.Now - DateOfBirth).TotalDays / 365;
        public List<string> Awards = new List<string>();//Добавить как то авардс
        public override string ToString()
        {
                return $"{Id}\t{Name}\t{Surname}\t{DateOfBirth.ToString("yyyy-MM-dd")}\t{Age}\t{String.Join(", ", Awards.ToArray())}";
        }

    }
}
