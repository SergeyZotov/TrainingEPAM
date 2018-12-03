using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAndAwards.PL.Web.Models
{
    public class Award
    {
        private string _title;

        private string _description;

        public int Id { get; set; }

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
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty");
                }

                _description = value;
            }
        }

        public bool IsAssigned { get; set; }

        public Award(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Award()
        {

        }
    }
}