﻿namespace MVC_LibraryAPI
{
    public class StaticDetails
    {
        public static string LibraryApiBase { get; set; }


        public enum ApiType
        {
            GET, POST, PUT, DELETE
        }
    }
}
