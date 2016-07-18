namespace BookRepository.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите наименование книги!")]
        [StringLength(100, ErrorMessage = "Максимальная длина 100 букв!")]
        [DisplayName("Название")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Введите автора!")]
        [StringLength(100, ErrorMessage ="Максимальная длина 100 букв!")]
        [DisplayName("Автор")]
        public string Author { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
