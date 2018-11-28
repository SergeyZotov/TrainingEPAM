using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAndAwards.PL.Web.Models
{
    /*
     * <!--><p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Birthdate)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Age)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.FirstName)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.LastName)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Birthdate)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Age)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.Id }) |
            @Html.ActionLink("Details", "Details", new { id=item.Id }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.Id })
        </td>
    </tr>
}

</table>
    </!-->*/
    public class User
    {
        private string _lastName;
        private string _firstName;
        private DateTime _birthday;

        public User(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthday;
        }

        public User()
        {

        }

        public int Id { get; set; }

        public void AddAward(Award award) => Awards.Add(award);

        public void RemoveAward(Award award) => Awards.Remove(award);

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be empty!");
                }

                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be empty!");
                }

                _lastName = value;
            }
        }

        public DateTime Birthdate
        {
            get => _birthday;
            set
            {
                if (value > DateTime.Now || (DateTime.Now.Year - value.Year) > 150)
                {
                    throw new ArgumentException("Birthday cannot be more or less then (date now - 150 years)");
                }

                _birthday = value;
            }
        }

        public int Age => DateTime.Today.Year - Birthdate.Year - GetCorrectAgeShift();

        private int GetCorrectAgeShift()
        {

            if (Birthdate.Month > DateTime.Today.Month)
            {
                return 1;
            }
            else if (Birthdate.Month == DateTime.Today.Month)
            {
                if (Birthdate.Day <= DateTime.Today.Day)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            return 0;
        }

        public List<Award> Awards = new List<Award>();

    }
}