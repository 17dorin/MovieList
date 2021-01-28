using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary to pull values from to initialize Movie objects
            Dictionary<string, string> movies = new Dictionary<string, string>();
            List<Movie> categorizedMovies = new List<Movie>();
            //Adding movies to the dictionary, not sure if there's a less tedious way to do this
            movies.Add("Star Wars", "Scifi");
            movies.Add("Spirited Away", "Animated");
            movies.Add("Interstellar", "Scifi");
            movies.Add("Akira", "Animated");
            movies.Add("Tron", "Scifi");
            movies.Add("Finding Nemo", "Animated");
            movies.Add("The Hateful Eight", "Drama");
            movies.Add("Baby Driver", "Drama");
            movies.Add("The Thing", "Horror");
            movies.Add("The Shining", "Horror");

            foreach(KeyValuePair<string, string> movie in movies)
            {
                Movie m = new Movie(movie.Key, movie.Value);
                categorizedMovies.Add(m);
            }

            Console.WriteLine("List intialized");

            //Outer loop will loop the entire program and break if user says so, inner loop will loop getting input until a valid entry is given
            while(true)
            {
                string goAgain;
                while(true)
                {
                    try
                    {
                        string input;

                        input = GetInput("What category are you interested in? (1: Scifi, 2: Animated, 3: Drama, 4: Horror)");
                        Console.Clear();
                        FindCategory(input, categorizedMovies);

                        break;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                goAgain = GetInput("Would you like to find more movies? (y/n)").Trim();
                if (goAgain.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
        }


        public static string GetInput(string display)
        {
            Console.WriteLine(display);
            return Console.ReadLine().Trim();
        }

        public static void FindCategory(string input, List<Movie> movies)
        {
            bool validCategory = false;
            int categoryNumber;
            int.TryParse(input, out categoryNumber);
            string lowerInput = input.ToLower().Trim();
            List<string> validMovies = new List<string>();

            //Check to make sure string isn't empty, throw exception otherwise
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                //Goes through each movie to check for a genre match, breaks out when it finds one
                foreach (Movie movie in movies)
                {
                    if (lowerInput.Equals(movie.Genre.ToLower()) ||  categoryNumber == movie.GenreNumber)
                    {
                        validCategory = true;
                        validMovies.Add(movie.Title);
                    }

                }

                if(!validCategory)
                {
                    throw new Exception($"The category {input} was not found.");
                }

                validMovies.Sort();

                foreach (string validMovie in validMovies)
                {
                    Console.WriteLine(validMovie);
                }

            }
            else
            {
                throw new Exception("Input cannot be empty");
            }
        }

    }
}
