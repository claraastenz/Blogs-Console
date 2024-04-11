﻿using NLog;
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string path = Directory.GetCurrentDirectory() + "\\nlog.config";
        var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
        logger.Info("Program started");

        try
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Display all blogs");
                Console.WriteLine("2. Add Blog");
                Console.WriteLine("3. Create Post");
                Console.WriteLine("4. Display Posts");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllBlogs();
                        break;
                    case "2":
                        AddBlog();
                        break;
                    case "3":
                        CreatePost();
                        break;
                    case "4":
                        DisplayPosts();
                        break;
                    case "5":
                        logger.Info("Program ended");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }

    static void DisplayAllBlogs()
    {
        using (var db = new BloggingContext())
        {
            var query = db.Blogs.OrderBy(b => b.Name);
            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    static void AddBlog()
    {
        try
    {
        Console.Write("Enter a name for a new Blog: ");
        string name = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Blog name cannot be empty.");
        }

        using (var db = new BloggingContext())
        {
            var blog = new Blog { Name = name };
            db.AddBlog(blog);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while adding the blog.");
        throw ex;
    }
    }

    static void CreatePost()
    {
        Console.WriteLine("Create Post option selected.");
        // Implement logic to create a post
    }

    static void DisplayPosts()
    {
        Console.WriteLine("Display Posts option selected.");
        // Implement logic to display posts
    }
    

}
