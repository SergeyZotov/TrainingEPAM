using System;

namespace Entities
{
    public class Award
    {
        private string title;

        public int Id { get; set; }


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
