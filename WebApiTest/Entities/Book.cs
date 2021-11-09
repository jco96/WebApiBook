using System;

namespace WebApiTest.Entities{

    public record Book{
        public int id {get; init;}
        public string title{get; init;}
        
        public string description {get; init;}

        public int PageCount{get; init;}
        
        public string Excerpt {get; init;}

        public DateTime PublishDate {get; init;}


    }
}