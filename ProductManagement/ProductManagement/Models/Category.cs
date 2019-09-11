using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Models
{
    public partial class Category
    {
        #region "Constructor"
        public Category() => Product = new HashSet<Product>();
        #endregion

        #region "Category's property"
        public short Id { get; set; }

        [Required(ErrorMessage ="Name can not be empty.")]
        [RegularExpression("^([a-zA-Z\\s]{2,})$", ErrorMessage = "Name contains only alphabets (Minimum 2 characters).")]
        [MaxLength(50,ErrorMessage = "Length must be less than 50 characters. ")]
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        #endregion
    }
}
