﻿using BookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Categories.Contracts
{
    public interface CategoryRepository
    {
        void Add(Category category);
    }
}
