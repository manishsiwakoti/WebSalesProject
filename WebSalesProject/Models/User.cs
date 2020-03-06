﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebSalesProject.Models
    {
    public class User
        {
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }
     
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
       
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Request> Requests { get; set; }

        public User() { }
        }
    }
