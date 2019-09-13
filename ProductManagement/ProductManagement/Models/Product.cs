using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    #region "enum"
    public enum Colour
    {
        [Display(Name ="Red")]
        Red = 1,
        [Display(Name = "Green")]
        Green = 2,
        [Display(Name = "Yellow")]
        Yellow = 3
    }
    #endregion

    #region "Product"
    public partial class Product
    {
        public short Id { get; set; }

        [Required(ErrorMessage = "Name can not be empty.")]
        [RegularExpression("^([a-zA-Z\\s]{2,})$", ErrorMessage = "Name contains only alphabets (Minimum 2 characters).")]
        [MaxLength(50, ErrorMessage = "Length must be less than 50 characters. ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price can not be empty.")]
        [RegularExpression("^([1-9]\\d{1,6})+(,\\d{1,6})*(\\d.\\d{1,2})?$", ErrorMessage = "Price must be valid (Minimum 2 digit Maximum 20 digit.)")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Description can not be empty.")]
        [RegularExpression("^([0-9a-zA-Z\\s\\.\\,]{3,})$", ErrorMessage = "Description contains only alphabets '.' and ',' (Minimum 3 characters).")]
        [MaxLength(200, ErrorMessage = "Length must be less than 200 characters. ")]
        public string Description { get; set; }

        [Display(Name ="Available")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage ="Category can not be empty.")]
        [Display(Name="Category")]
        public short CategoryId { get; set; }

        [Required(ErrorMessage = "Colour can not be empty.")]
        public Colour Colour { get; set; }

        [Required(ErrorMessage = "Status can not be empty.")]
        [Display(Name="Available status")]
        public string AvailableStatus { get; set; }

        public virtual Category Category { get; set; }
    }
    #endregion
}
