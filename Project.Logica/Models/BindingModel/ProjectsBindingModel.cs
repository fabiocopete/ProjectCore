using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Logica.Models.BindingModel
{
   public  class ProjectsCreateBindingModel
    {
        [Required(ErrorMessage = "The field title is required")]
        [Display(Name ="Title")]
        public  string Title { get; set; }

        [Required(ErrorMessage = "The field details is required")]
        [Display(Name = "Details")]
        public  string Details { get; set; }

        [Required(ErrorMessage = "The field expected completion date is required")]
        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }

    }

    public class ProjectsEditBindingModel
    {
        [Required(ErrorMessage = "The field Id is required")]
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "The field title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The field expected completion date is required")]
        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }

    }
}
