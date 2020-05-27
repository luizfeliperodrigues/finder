using System;

namespace Finder.Application.Domain.Entities
{
    public class Restaurant
    {
        public string Name { get; set; }

        public TimeSpan IsOpenedAt { get; set; }

        public TimeSpan IsClosedAt { get; set; }

        public Restaurant(){}

        public Restaurant(string name, TimeSpan isOpenedAt, TimeSpan isClosedAt) : this()
        {
            Name = name;
            IsOpenedAt = isOpenedAt;
            IsClosedAt = isClosedAt;
        }

        public bool IsOpen(TimeSpan timeChecking)
        {
            return (timeChecking >= IsOpenedAt && timeChecking <= IsClosedAt);
        }
    }
}