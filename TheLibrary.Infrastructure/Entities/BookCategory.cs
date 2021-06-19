﻿using System.ComponentModel;
using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Infrastructure.Entities
{
    public class BookCategory : EntityBase, IODataEntity
    {
        public string Title { get; set; }
    }
}