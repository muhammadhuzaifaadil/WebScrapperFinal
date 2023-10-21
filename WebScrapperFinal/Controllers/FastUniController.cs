//using HtmlAgilityPack;
//using Microsoft.AspNetCore.Mvc;
//using WebScrapperFinal.Models;

//namespace WebScrapperFinal.Controllers
//{
//    public class FastUniController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult ScrapWebsite(string website)
//        {
//            var blogDataList = new List<BlogData>();
//            var web = new HtmlWeb();
//            string bahriaUni = "https://www.bahria.edu.pk/academics/under-graduate-programs/";
//            var htmlDoc = web.Load(website);
//            var nodeElement = htmlDoc.DocumentNode.SelectNodes("//table[@class='table-body']");//selecting all divs having specified class
//            //foreach(var node in nodeElement)
//            //{
//            //    var blogImage = node.ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x=>x.Name=="a")
//            //        .ChildNodes.FirstOrDefault(x=>x.Name=="img").Attributes.FirstOrDefault(x=>x.Name=="src").Value;
//            //    var title = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").InnerHtml.Trim();
//            //    var author = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").ChildNodes.FirstOrDefault(x => x.Name == "span").InnerHtml;
//            //    var publishDate = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.LastOrDefault(x => x.Name == "span").InnerHtml;
//            //    var blogData = new BlogData
//            //    {
//            //        BlogImage = blogImage,
//            //        Title = title,
//            //        Author = author,
//            //        PublishDate = publishDate,
//            //    };
//            //    blogDataList.Add(blogData);
//            //}
//            //foreach(var node in nodeElement) { 
//            //var courseName = node.ChildNodes.FirstOrDefault(x=>x.Name=="tbody").ChildNodes.FirstOrDefault(x=>x.Name=="tr").ChildNodes.(x=>x.Name=="td").ChildNodes.FirstOrDefault(x=>x.Name=="a").InnerText;
//            //        }
//            var courseNames = new List<UniversityCourses>();
//            //coursenamesandcampus
//            foreach (var node in nodeElement)
//            {
//                var tbodyNode = node.SelectSingleNode(".//tbody");
//                if (tbodyNode != null)
//                {
//                    var trNodes = tbodyNode.SelectNodes(".//tr");
//                    if (trNodes != null)
//                    {
//                        foreach (var trNode in trNodes)
//                        {
//                            var tdNodes = trNode.SelectNodes(".//td");
//                            if (tdNodes != null)
//                            {
//                                //  var tdName = tdNodes[3].InnerText ?: tdNodes[2].InnerText;
//                             //   var tdName = (tdNodes.Count > 3) ? tdNodes[3].InnerText : (tdNodes.Count > 2) ? tdNodes[2].InnerText : string.Empty;

//                                foreach (var tdNode in tdNodes)
//                                {
//                                    //   var tdName = tdNode.InnerText.Trim();
//                                    var courseNode = tdNode.SelectSingleNode(".//a");
//                                    if (courseNode != null)
//                                    {
//                                        var courseName = courseNode.InnerText.Trim();
//                                        var universityCourse = new UniversityCourses
//                                        {
//                                            CourseName = courseName,
//                                        //    Campus = tdName
//                                        };
//                                        courseNames.Add(universityCourse);
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            //importantdocuments
//            //var nodeElement2 = htmlDoc.DocumentNode.SelectNodes("//div[@class='description']");

//            //if (nodeElement2 != null)
//            //{
//            //    foreach (var node in nodeElement2)
//            //    {
//            //        var ulNode = node.SelectSingleNode(".//ul");
//            //        if (ulNode != null)
//            //        {
//            //            var liNodes = ulNode.SelectNodes(".//li");
//            //            if (liNodes != null)
//            //            {
//            //                foreach (var liNode in liNodes)
//            //                {
//            //                    var liText = liNode.InnerText.Trim();

//            //                }
//            //            }
//            //        }
//            //    }
//            //}
//            return View("Index", courseNames);//kyun k at the end Index pe return hoga
//        }
//    }
//}
