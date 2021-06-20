using InterviewManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewManagementPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IConfiguration Configuration { get; }

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Participants = this.GetAllParticipants();
            ViewBag.Interviews = this.GetAllInterviews();
            return View();
        }

        private List<Participant> GetAllParticipants()
        {
            List<Participant> participants = new List<Participant>();
            string queryString = "SELECT * FROM [dbo].[Participants]";

            using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("DatabaseConnectionString")))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        participants.Add(new Participant
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Name = reader[1].ToString(),
                            EmailAddress = reader[2].ToString()
                        });
                    }
                }
            }

            return participants;
        }

        private List<Interview> GetAllInterviews()
        {
            List<Interview> interviews = new List<Interview>();
            string queryString = "SELECT * FROM [dbo].[Interviews]";

            using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("DatabaseConnectionString")))
            {
                SqlCommand command = new SqlCommand(queryString, sqlConnection);
                command.Connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        interviews.Add(new Interview
                        {
                            Id = Convert.ToInt32(reader[0]),
                            Participants = new List<Participant>(),
                            StartTime = DateTime.Parse(reader[1].ToString()),
                            EndTime = DateTime.Parse(reader[2].ToString())
                        });
                    }
                }
            }

            queryString = "SELECT P.Id, P.Name, P.EmailAddress FROM [dbo].[Participants] P INNER JOIN [dbo].[InterviewParticipants] IP ON P.Id = IP.ParticipantId WHERE IP.InterviewId = @interviewId";
            foreach(Interview interview in interviews)
            {
                using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("DatabaseConnectionString")))
                {
                    SqlCommand command = new SqlCommand(queryString, sqlConnection);
                    command.Parameters.AddWithValue("@interviewId", interview.Id);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            interview.Participants.Add(new Participant
                            {
                                Id = Convert.ToInt32(reader[0]),
                                Name = reader[1].ToString(),
                                EmailAddress = reader[2].ToString()
                            });
                        }
                    }
                }
            }

            return interviews;
        }
    }
}
