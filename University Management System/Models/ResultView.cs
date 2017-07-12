using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University_Management_System.Models
{
    public class ResultView
    {
        public ResultView(int id, string regNo)
        {
            this.Id = id;
            this.RegNo = regNo;

        }

        public ResultView()
        {
        }

        public int Id { set; get; }
        public int RegNoId { set; get; }
        [Required]
        public string RegNo { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Department { set; get; }

    }
}