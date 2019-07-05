//using NewsDataRepositoryNewsDataRepository.Concrete.EntityFramework;
//using NewsEntities.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace NewsDataRepository.Concrete.EntityFramework
//{
//    public static class DbInitializer
//    {
//        public static void Initialize(NContext context)
//        {

//            context.Database.EnsureCreated();
//            if (context.news.Any())
//            {
//                return;
//            }
//            var news = new News[]
//            {
//                new News{ CategoryId=1,  NewsName="asdfahhdfhsdfahsdfasf",NewsTitle="asdfasddfhhhhhghdfasdfa", NewsExpo="asdfasdgfhdfghfasfasdfasdfasdf", NewsContent="asdghdfhdfasdfasdf" },
//                new News{ CategoryId=2,  NewsName ="asdfhdfashhdfhasdfasf",NewsTitle="asdfasdfghdfhhghdfasdfa", NewsExpo="asdfasasdfasdddfhdfhdffasdfasf", NewsContent="asdfadfghdfhdfghhdfghdfsdfasdf" },
//                new News{ CategoryId=3,  NewsName ="asdfagdfhdfsdfasdfasf",NewsTitle="ahhdfadgfhdfhshhhdasdfa", NewsExpo="asdfasdafdshhhhhhhfasdfasdfasf", NewsContent="asddhdffasdfasdf" },
//                new News{ CategoryId=4,  NewsName ="asdhdhdfasdfashhdfasf",NewsTitle="asdfadhdfhdfhhhdsdasdfa", NewsExpo="asdfasdasdfadsfasdfdsfgasdfasf", NewsContent="asdfdfghdfhasdfasdf" },
//                new News{ CategoryId=5,  NewsName ="asdfasdhdfhfhhasdfasf",NewsTitle="asdfasdhdfdghhdfhdasdfa", NewsExpo="asdfasdfasdfasdasfasdfasdfasdf", NewsContent="asdghgdfgfasdfasdf" },
//            };
//            foreach(News n in news)
//            {
//                context.news.Add(n);
//            }
//            context.SaveChanges();

//            var Categories = new Category[]
//            {
//                new Category { CategoryId=1, CategoryName="Spor"},
//                new Category { CategoryId=2, CategoryName="Gündem"},
//                new Category { CategoryId=3, CategoryName="Ekonomi"},
//                new Category { CategoryId=4, CategoryName="Dış Basın"},
//                new Category { CategoryId=5, CategoryName="Spor"},
//            };
//            foreach (Category c in Categories)
//            {
//                context.categories.Add(c);
//            }
//            context.SaveChanges();
//        }
        
//    }
//}