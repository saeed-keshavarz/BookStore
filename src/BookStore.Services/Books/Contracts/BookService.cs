﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Books.Contracts
{
    public interface BookService
    {
        void Add(AddBookDto dto);
    }
}
