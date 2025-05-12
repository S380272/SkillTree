using System.ComponentModel.DataAnnotations;

namespace Homework_SkillTree.Models
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "請選擇類別")]
        [Display(Name = "類別")]
        public string Category { get; set; } = null!;

        [Required(ErrorMessage = "請輸入金額")]
        [Range(0.01, double.MaxValue, ErrorMessage = "金額必須大於 0")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "金額")]
        public decimal Money { get; set; }

        [Required(ErrorMessage = "請選擇日期")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(HomeViewModel), nameof(ValidateDate))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "日期")]
        public DateTime CreateDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "請輸入備註")]
        [StringLength(100, ErrorMessage = "備註不可超過 100 個字")]
        [Display(Name = "備註")]
        public string? Description { get; set; }

        public static ValidationResult ValidateDate(DateTime date, ValidationContext context)
        {
            if (date > DateTime.Today)
            {
                return new ValidationResult("日期不得大於今天");
            }
            return ValidationResult.Success;
        }
    }
}