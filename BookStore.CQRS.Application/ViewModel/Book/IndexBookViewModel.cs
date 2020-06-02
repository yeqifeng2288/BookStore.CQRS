using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.CQRS.ViewModel
{
    public class IndexBookViewModel
    {
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [Display(Name = "书名")]
        public string Title { get; set; }

        [Display(Name = "价格")]
        public decimal Price { get; set; }
    }
}
