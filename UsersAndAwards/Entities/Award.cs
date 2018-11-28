using System;

namespace Entities
{
    public class Award
    {
        private string _title;

        public int AwardId { get; set; }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty");
                }

                _title = value;
            }
        }

        public string Description
        {
            get; set;
        }

        public Award(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
