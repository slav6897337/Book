// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BookTask
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The sealed class Book.
    /// </summary>
    public sealed class Book
    {
        private bool published = false;
        private DateTime datePublished;
        private int totalPages;

        /// <summary>
        /// Gets Autor of Book.
        /// </summary>
        public string Autor { get; }

        /// <summary>
        /// Gets Title of Book.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets Publisher of Book.
        /// </summary>
        public string Publisher { get; }

        /// <summary>
        /// Gets ISBN of Book.
        /// </summary>
        public string ISBN { get; }

        /// <summary>
        /// Gets Price of Book.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets ISO of Book.
        /// </summary>
        public string ISO { get; private set; }

        /// <summary>
        /// Gets or sets pages of Book.
        /// </summary>
        public int Pages
        {
            get => totalPages;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException($"Count {value} pages must be more 0");
                }

                totalPages = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="publsher"></param>
        public Book(string author, string title, string publsher)
        {
            Autor = author;
            Title = title;
            Publisher = publsher;
            RegionInfo myReg = new RegionInfo("BY");
            ISO = myReg.ISOCurrencySymbol;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="publsher"></param>
        /// <param name="isbn"></param>
        public Book(string author, string title, string publsher, string isbn)
            : this(author, title, publsher)
        {
            ISBN = isbn;
        }

        /// <summary>
        ///  Method sets publication date.
        /// </summary>
        /// <param name="date"></param>
        public void Publish(DateTime date)
        {
            datePublished = date;
            published = true;
        }

        /// <summary>
        /// Method gets publication date.
        /// </summary>
        /// <returns>publication date.</returns>
        public string GetPublicationDate()
        {
            return published ? datePublished.ToString() : "NYP";
        }

        /// <summary>
        /// Method gets price of book.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="iso"></param>
        public void SetPrice(decimal price, string iso)
        {
            Price = price;
            ISO = iso;
        }

        /// <summary>
        /// Method gets name and autor of book.
        /// </summary>
        /// <returns>Name and autor of book.</returns>
        public override string ToString()
        {
            return Title + " by " + Autor;
        }
    }
}
