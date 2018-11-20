using System;

namespace Entities
{
    public class Award
    {
        private string title;
        private string description;

        public int Id { get; set; }

        public string Description
        {
            get => description;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Description cannot be empty");
                }

                description = value;
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty");
                }

                title = value;
            }
        }

        public Award(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
