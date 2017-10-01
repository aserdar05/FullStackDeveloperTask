using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FulStackDeveloperTask.App.Models
{
    public class BaseModel
    {

        [Column("ID")]
        public int Id { get; set; }
    }
}