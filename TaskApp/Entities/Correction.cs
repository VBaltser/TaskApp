using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TaskApp.Entities
{
    public class Correction
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "ID Приложения")]
        public int AppID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Описание")]
        [DataType(DataType.MultilineText)] 
        public string Description { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EMail")]
        public string Email { get; set; }
    }
}