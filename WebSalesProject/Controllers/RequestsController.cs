﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSalesProject.Data;
using WebSalesProject.Models;

namespace CapstoneFinalProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
        {

        //public static string StatusNew = "NEW";
        //public static string StatusReview = "REVIEW";
        //public static string StatusReject = "REJECTED";
        //public static string StatusApprove = "APPROVED";

            

        private readonly SalesDbContext _context;

        public RequestsController(SalesDbContext context)
            {
            _context = context;
            }
        //Get:api/Requests
        [HttpGet("review/{id}")]
        public async Task<ActionResult<IEnumerable<Request>>> GetReview( int id)
            {
           return await _context.Requests.Where(x => x.Status == ("REVIEW") && x.UserId != id).ToListAsync();
            
            
            }
       
        //Post:api/Requests
        [HttpPost("reject" )]
        public async Task<IActionResult> PostReject(Request request)
           {
            request.Status = "REJECTED";
            return await PutRequest(request.Id, request);

           }
       
        //post:api/Requests 
        [HttpPost("approve")]
        public async Task<IActionResult>PostApprove(Request request)
            {
            request.Status = "APPROVED";
            return await PutRequest(request.Id, request);
            }

        //post : api/Requests
        [HttpPost("review/{id}")]

        public async Task<IActionResult> PostReview(int id, Request request)
            {

            if (request.Total <= 50) 
                    {
                    request.Status = "APPROVED";
                    }
            else
                { 
                request.Status = "REVIEW"; 
                }

            return await PutRequest(id, request);
            
            
            }
           
         
      
     
        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Requests
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Request>> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return request;
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
