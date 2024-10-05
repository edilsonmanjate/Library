﻿namespace Library.API.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public Book Book { get; set; }
    }
}
