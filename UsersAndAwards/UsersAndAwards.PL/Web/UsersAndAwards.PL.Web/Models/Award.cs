using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsersAndAwards.PL.Web.Models
{
    /*
     * <!----<h2>Award</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(model => model.Title)
        </th>
        <th>
            @Html.DisplayNameFor(model => model.Description)
        </th>
        <th></th>
    </tr>

@foreach (var item in Model) {
    <tr>
        <td>
            @Html.DisplayFor(modelItem => item.Title)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.Description)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id=item.AwardId }) |
            @Html.ActionLink("Details", "Details", new { id=item.AwardId }) |
            @Html.ActionLink("Delete", "Delete", new { id=item.AwardId })
        </td>
    </tr>
}

</table>
    </!-->*/
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

        public Award()
        {

        }
    }
}