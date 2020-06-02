using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.CQRS.ViewModel
{
    public class AddBookViewModel
    {
        [DisplayName("书名")]
        [Required(ErrorMessage = "书名是必须的。")]
        [MaxLength(30, ErrorMessage = "书名最长不能超过30个字符")]
        [MinLength(2, ErrorMessage = "书名不能少于2个")]
        public string Title { get; set; }

        [DisplayName("作者名字")]
        [MinLength(2, ErrorMessage = "作者名长度不能少于2，不能大于30")]
        [MaxLength(30, ErrorMessage = "作者名长度不能少于2，不能大于30")]
        public string Name { get; set; }

        [DisplayName("发布时间")]
        public DateTime PublishTime { get; set; }

        [DisplayName("简述")]
        public string Description { get; set; }

        [DisplayName("出版社")]
        public string PublishingHouse { get; set; }

        [DisplayName("零售价")]
        public decimal Price { get; set; }
    }
}
