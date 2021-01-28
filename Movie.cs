using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList
{
    class Movie
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int GenreNumber { get; set; }

        public Movie(string Title, string Genre)
        {
            this.Title = Title;
            this.Genre = Genre;

            if(this.Genre == "Scifi")
            {
                this.GenreNumber = 1;
            }
            else if (this.Genre == "Animated")
            {
                this.GenreNumber = 2;
            }
            else if (this.Genre == "Drama")
            {
                this.GenreNumber = 3;
            }
            else if (this.Genre == "Horror")
            {
                this.GenreNumber = 4;
            }
        }

    }
}
