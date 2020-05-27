using System;

namespace Finder.Application.Domain.Entities
{
    public class Restaurant
    {
        public string Name { get; set; }

        public TimeSpan OpensAt { get; set; }

        public TimeSpan ClosesAt { get; set; }

        public Restaurant(){}

        public Restaurant(string name, TimeSpan opensAt, TimeSpan closesAt) : this()
        {
            Name = name;
            OpensAt = opensAt;
            ClosesAt = closesAt;
        }

        public bool IsOpen(TimeSpan time)
        {
            return (time >= OpensAt && time <= ClosesAt);
        }
    }
}