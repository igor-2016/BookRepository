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

        [Required(ErrorMessage = "������� ������������ �����!")]
        [StringLength(100, ErrorMessage = "������������ ����� 100 ����!")]
        [DisplayName("��������")]
        public string Name { get; set; }

        [Required(ErrorMessage ="������� ������!")]
        [StringLength(100, ErrorMessage ="������������ ����� 100 ����!")]
        [DisplayName("�����")]
        public string Author { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
