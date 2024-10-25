﻿using LibraryData.Models;

namespace LibraryAPI.Services
{
    public interface IAuthorService
    {
        List<Author> getAll();
        Author getById(Guid id);
        bool createAuthor(Author author);
        bool updateAuthor(Guid id, Author author);
        bool deleteAuthor(Guid id);
    }
}
