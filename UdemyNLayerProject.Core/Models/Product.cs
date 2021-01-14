using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UdemyNLayerProject.Core.Models
{
   public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} alanı zorunludur.")]
        public string Name { get; set; }

       [Range(1,int.MaxValue,ErrorMessage ="{0} alanı 1 den büyük olmalıdır.")]
        public int Stock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} alanı 1 den büyük olmalıdır.")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
    }
}
