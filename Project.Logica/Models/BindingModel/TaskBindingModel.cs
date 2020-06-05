using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProjectCore.Logica.Models.BindingModel
{
    public class TaskCreateBindingModel
    {
        
        [Display(Name ="Title")]
        [Required (ErrorMessage ="The Field Title is required")]
        public string Title { get; set; }


        [Display(Name = "Details")]
        [Required(ErrorMessage = "The Field Details is required")]

        public string Details { get; set; }


        [Display(Name = "ExpirationDate")]
        [Required(ErrorMessage = "The Field Expiration Date is required")]

        public DateTime? ExpirationDate { get; set; }


        [Display(Name = "Is Completed")]
        [Required(ErrorMessage = "The Field Is Completed is required")]

        public bool IsCompleted { get; set; }


        [Display(Name = "Effort")]
        [Required(ErrorMessage = "The Field Effort is required")]
        public int? Effort { get; set; }


        [Display(Name = "Remaining Work")]
        [Required(ErrorMessage = "The Field Remaning Work is required")]
        public int? RemainingWork { get; set; }


        //FOREING KEY

        [Display(Name = "State ")]
        [Required(ErrorMessage = "The Field State  is required")]
        public int? StateId { get; set; }


        [Display(Name = "Activity ")]
        [Required(ErrorMessage = "The Field Activity  is required")]
        public int? ActivityId { get; set; }


        [Display(Name = "Priority ")]
        [Required(ErrorMessage = "The Field Priority  is required")]
        public int? PriorityId { get; set; }

        public int? ProjectId { get; set; }




    }
}
