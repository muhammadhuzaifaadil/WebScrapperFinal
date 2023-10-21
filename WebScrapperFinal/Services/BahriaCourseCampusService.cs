using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebScrapperFinal.Data;
using WebScrapperFinal.Models;

namespace WebScrapperFinal.Services
{
    public class BahriaCourseCampusService
    {
        private readonly ApplicationDbContext _context;
   
        public BahriaCourseCampusService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public List<UniversityCourses> CampusCourse()
        {
            var courseNames = _context.UniversityCourses.ToList();

            if (courseNames.Count == 0)
            {
                // If the database is empty, perform web scraping
                var web = new HtmlWeb();
                var htmlDoc = web.Load("https://www.bahria.edu.pk/academics/under-graduate-programs/");
                var nodeElement = htmlDoc.DocumentNode.SelectNodes("//table[@class='table table-bordered table-striped']");

                if (nodeElement != null)
                {
                    foreach (var node in nodeElement)
                    {
                        var tbodynode = node.SelectSingleNode(".//tbody");
                        if (tbodynode != null)
                        {
                            var trnodes = tbodynode.SelectNodes(".//tr");
                            if (trnodes != null)
                            {
                                foreach (var trnode in trnodes)
                                {
                                    var tdnodes = trnode.SelectNodes(".//td");
                                    if (tdnodes != null)
                                    {
                                        string tdname = (tdnodes.Count > 3) ? tdnodes[3].InnerText.Trim() : (tdnodes.Count > 2) ? tdnodes[2].InnerText.Trim() : string.Empty;

                                        foreach (var tdnode in tdnodes)
                                        {
                                            var coursenode = tdnode.SelectSingleNode(".//a");
                                            if (coursenode != null)
                                            {
                                                var coursename = coursenode.InnerText?.Trim();
                                                if (!string.IsNullOrWhiteSpace(coursename))
                                                {
                                                    var universitycourse = new UniversityCourses
                                                    {
                                                        CourseName = coursename,
                                                        Campus = tdname
                                                    };
                                                    courseNames.Add(universitycourse);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the scraped data to the database
                    _context.UniversityCourses.AddRange(courseNames);
                    _context.SaveChanges();
                }
            }
            return courseNames;
        }


        public List<UniversityDocuments> Documents()
        {
            var impDocs = _context.UniversityDocument.ToList();
            //importantdocuments
            if (impDocs.Count == 0)
            {
                var web = new HtmlWeb();
                var htmlDoc = web.Load("https://www.bahria.edu.pk/documents-required-ug/");
                var nodeElement2 = htmlDoc.DocumentNode.SelectNodes("//div[@class='description']");

                if (nodeElement2 != null)
                {
                    foreach (var node in nodeElement2)
                    {
                        var ulNode = node.SelectSingleNode(".//ul");
                        if (ulNode != null)
                        {
                            var liNodes = ulNode.SelectNodes(".//li");
                            if (liNodes != null)
                            {
                                foreach (var liNode in liNodes)
                                {
                                    var liText = liNode.InnerText.Trim();
                                    var documents = new UniversityDocuments
                                    {
                                        Document = liText,
                                    };
                                    impDocs.Add(documents);
                                }
                            }
                        }
                    }
                    // Save the scraped data to the database
                    _context.UniversityDocument.AddRange(impDocs);
                    _context.SaveChanges();
                }
            }
            return impDocs;
        }
    }
       
}
