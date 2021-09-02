using System;
using System.Collections.Generic;
using TaskApp.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TaskApp.Models
{
    public class CorrectionCreateModel
    {
        [Display(Name = "Приложения")]
        public IEnumerable<App> Apps { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public int AppId { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата")]
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