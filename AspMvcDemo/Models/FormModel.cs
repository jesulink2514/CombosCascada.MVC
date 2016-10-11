using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspMvcDemo.Models
{
    public class FormModel
    {
        [Display(Name = "Tipo:")]
        public int? TypeId { get; set; }
        [Display(Name = "SubTipo:")]
        public int? SubTypeId { get; set; }
    }

    public class SubTipo
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
    }
}