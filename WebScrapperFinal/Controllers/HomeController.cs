using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
using WebScrapperFinal.Data;
using WebScrapperFinal.Models;
using WebScrapperFinal.Services;

namespace WebScrapperFinal.Controllers
{
    public class HomeController : Controller { 
    //{
    //    private readonly ApplicationDbContext _context;
    //    private readonly BahriaCourseCampusService _bahriaService;
    //    public HomeController(ApplicationDbContext context,BahriaCourseCampusService bahriaService)
    //    {
    //        _context = context;
    //        _bahriaService = bahriaService;
    //    }

    //    public IActionResult Index()
    //    {
    //        return View();
    //    }

    //    //public IActionResult ScrapWebsite(string website)
    //    // {
    //    //     var blogDataList = new List<BlogData>();
    //    //     var web = new HtmlWeb();
    //    //     string bahriaUni = "https://www.bahria.edu.pk/academics/under-graduate-programs/";
    //    //     var htmlDoc = web.Load(website);
    //    //     var nodeElement = htmlDoc.DocumentNode.SelectNodes("//table[@class='table table-bordered table-striped']");//selecting all divs having specified class
    //    //  //   var nodeElement = htmlDoc.DocumentNode.SelectNodes("//table[@class='table-body']");
    //    //     //foreach(var node in nodeElement)
    //    //     //{
    //    //     //    var blogImage = node.ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x=>x.Name=="a")
    //    //     //        .ChildNodes.FirstOrDefault(x=>x.Name=="img").Attributes.FirstOrDefault(x=>x.Name=="src").Value;
    //    //     //    var title = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").InnerHtml.Trim();
    //    //     //    var author = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").ChildNodes.FirstOrDefault(x => x.Name == "span").InnerHtml;
    //    //     //    var publishDate = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.LastOrDefault(x => x.Name == "span").InnerHtml;
    //    //     //    var blogData = new BlogData
    //    //     //    {
    //    //     //        BlogImage = blogImage,
    //    //     //        Title = title,
    //    //     //        Author = author,
    //    //     //        PublishDate = publishDate,
    //    //     //    };
    //    //     //    blogDataList.Add(blogData);
    //    //     //}
    //    //     //foreach(var node in nodeElement) { 
    //    //     //var courseName = node.ChildNodes.FirstOrDefault(x=>x.Name=="tbody").ChildNodes.FirstOrDefault(x=>x.Name=="tr").ChildNodes.(x=>x.Name=="td").ChildNodes.FirstOrDefault(x=>x.Name=="a").InnerText;
    //    //     //        }
    //    //     var courseNames = new List<UniversityCourses>();
    //    //     //coursenamesandcampus
    //    //     foreach (var node in nodeElement)
    //    //     {
    //    //         var tbodynode = node.SelectSingleNode(".//tbody");
    //    //         if (tbodynode != null)
    //    //         {
    //    //             var trnodes = tbodynode.SelectNodes(".//tr");
    //    //             if (trnodes != null)
    //    //             {
    //    //                 foreach (var trnode in trnodes)
    //    //                 {
    //    //                     var tdnodes = trnode.SelectNodes(".//td");
    //    //                     if (tdnodes != null)
    //    //                     {
    //    //                         //  var tdname = tdnodes[3].innertext ?: tdnodes[2].innertext;
    //    //                       //  var tdname = (tdnodes.count > 3) ? tdnodes[3].innertext : (tdnodes.count > 2) ? tdnodes[2].innertext : string.empty;

    //    //                         foreach (var tdnode in tdnodes)
    //    //                         {
    //    //                             //   var tdname = tdnode.innertext.trim();
    //    //                             var coursenode = tdnode.SelectSingleNode(".//a");
    //    //                             if (coursenode != null)
    //    //                             {
    //    //                                 var coursename = coursenode.InnerText.Trim();
    //    //                                 var universitycourse = new UniversityCourses
    //    //                                 {
    //    //                                     CourseName = coursename,
    //    //                                //     campus = tdname
    //    //                                 };
    //    //                                 courseNames.Add(universitycourse);
    //    //                             }
    //    //                         }
    //    //                     }
    //    //                 }
    //    //             }
    //    //         }
    //    //     }
    //    //     //importantdocuments
    //    //     //var nodeElement2 = htmlDoc.DocumentNode.SelectNodes("//div[@class='description']");

    //    //     //if (nodeElement2 != null)
    //    //     //{
    //    //     //    foreach (var node in nodeElement2)
    //    //     //    {
    //    //     //        var ulNode = node.SelectSingleNode(".//ul");
    //    //     //        if (ulNode != null)
    //    //     //        {
    //    //     //            var liNodes = ulNode.SelectNodes(".//li");
    //    //     //            if (liNodes != null)
    //    //     //            {
    //    //     //                foreach (var liNode in liNodes)
    //    //     //                {
    //    //     //                    var liText = liNode.InnerText.Trim();

    //    //     //                }
    //    //     //            }
    //    //     //        }
    //    //     //    }
    //    //     //}
    //    //     return View("Index", courseNames);//kyun k at the end Index pe return hoga
    //    // }

    //    //public IActionResult ScrapWebsite(string website)
    //    //{
    //    //   var courseNames = _context.UniversityCourses?.ToList() ?? new List<UniversityCourses>();
    //    //    // Try to retrieve data from the database

    //    //   if (courseNames.Count == 0)
    //    //    {
    //    //        // If the database is empty, perform web scraping
    //    //        var web = new HtmlWeb();
    //    //        var htmlDoc = web.Load(website);
    //    //        var nodeElement = htmlDoc.DocumentNode.SelectNodes("//table[@class='table table-bordered table-striped']");

    //    //    // Scraping logic remains the same
    //    //   // var courseNames = new List<UniversityCourses>();
    //    //    foreach (var node in nodeElement)
    //    //        {
    //    //            var tbodynode = node.SelectSingleNode(".//tbody");
    //    //            if (tbodynode != null)
    //    //            {
    //    //                var trnodes = tbodynode.SelectNodes(".//tr");
    //    //                if (trnodes != null)
    //    //                {
    //    //                    foreach (var trnode in trnodes)
    //    //                    {
    //    //                        var tdnodes = trnode.SelectNodes(".//td");
    //    //                        if (tdnodes != null)
    //    //                        {
    //    //                            //  var tdname = tdnodes[3].innertext ?: tdnodes[2].innertext;
    //    //                              var tdname = (tdnodes.Count > 3) ? tdnodes[3].InnerText : (tdnodes.Count > 2) ? tdnodes[2].InnerText : string.Empty;

    //    //                            foreach (var tdnode in tdnodes)
    //    //                            {
    //    //                                //   var tdname = tdnode.innertext.trim();
    //    //                                var coursenode = tdnode.SelectSingleNode(".//a");
    //    //                                if (coursenode != null)
    //    //                                {
    //    //                                    var coursename = coursenode.InnerText.Trim();
    //    //                                    var universitycourse = new UniversityCourses
    //    //                                    {
    //    //                                        CourseName = coursename,
    //    //                                        //     campus = tdname
    //    //                                    };
    //    //                                    courseNames.Add(universitycourse);
    //    //                                }
    //    //                            }
    //    //                        }
    //    //                    }
    //    //                }
    //    //                // Save the scraped data to the database
    //    //                _context.UniversityCourses.AddRange(courseNames);
    //    //                _context.SaveChanges();
    //    //            }

    //    //           // return View("Index", courseNames);
    //    //        }
    //    //    }
    //    //    return View("Index", courseNames);
    //    //}
    //    // var courseNames = _context.UniversityCourses?.ToList() ?? new List<UniversityCourses>();
    //    //public IActionResult ScrapWebsite(string website)
    //    //{

    //    //    var courseNames = new List<UniversityCourses>();
    //    //    if (courseNames.Count == 0)
    //    //    {
    //    //        // If the database is empty, perform web scraping
    //    //        var web = new HtmlWeb();
    //    //        var htmlDoc = web.Load(website);
    //    //        var nodeElement = htmlDoc.DocumentNode.SelectNodes("//table[@class='table table-bordered table-striped']");

    //    //        if (nodeElement != null)
    //    //        {
    //    //            foreach (var node in nodeElement)
    //    //            {
    //    //                var tbodynode = node.SelectSingleNode(".//tbody");
    //    //                if (tbodynode != null)
    //    //                {
    //    //                    var trnodes = tbodynode.SelectNodes(".//tr");
    //    //                    if (trnodes != null)
    //    //                    {
    //    //                        foreach (var trnode in trnodes)
    //    //                        {
    //    //                            var tdnodes = trnode.SelectNodes(".//td");
    //    //                            if (tdnodes != null)
    //    //                            {
    //    //                                string tdname = (tdnodes.Count > 3) ? tdnodes[3].InnerText.Trim() : (tdnodes.Count > 2) ? tdnodes[2].InnerText.Trim() : string.Empty;

    //    //                                foreach (var tdnode in tdnodes)
    //    //                                {
    //    //                                    var coursenode = tdnode.SelectSingleNode(".//a");
    //    //                                    if (coursenode != null)
    //    //                                    {
    //    //                                        var coursename = coursenode.InnerText.Trim();
    //    //                                        var universitycourse = new UniversityCourses
    //    //                                        {
    //    //                                            CourseName = coursename,
    //    //                                            Campus = tdname // Assuming you want to store the "tdname" as the campus
    //    //                                        };
    //    //                                        courseNames.Add(universitycourse);
    //    //                                    }
    //    //                                }
    //    //                            }
    //    //                        }
    //    //                    }
    //    //                }
    //    //            }

    //    //            // Save the scraped data to the database
    //    //            _context.UniversityCourses.AddRange(courseNames);
    //    //            _context.SaveChanges();
    //    //        }
    //    //    }

    //    //    return View("Index", courseNames);
    //    //}
    //    public IActionResult ScrapWebsite()
    //    {
    //       var courseNames = _bahriaService.CampusCourse();

    //        return View("Index", courseNames);
    //    }

         private readonly BahriaCourseCampusService _bahriaService;

    public HomeController(BahriaCourseCampusService bahriaService)
    {
        _bahriaService = bahriaService;
    }

    //public IActionResult Index()
    //{
    //    // Fetch data from the service
    //    var courseNames = _bahriaService.CampusCourse();

    //    // Return the data to the view
    //    return View(courseNames);
    //}
    public IActionResult Index()
        {
            var impDocs = _bahriaService.Documents();

            return View(impDocs);
        }
}
}