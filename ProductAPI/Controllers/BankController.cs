﻿using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankContext _context;
        public BankController(BankContext bankContext)
        {
            _context = bankContext;
        }



        [HttpGet]
        public List<BankBranchResponse> GetAll()
        {
            return _context.BankBranches.Select(b=> new BankBranchResponse
            {
                LocationName = b.LocationName,
                LocationURL = b.LocationURL,
                BranchManager = b.BranchManager,
                BranchName = b.BranchName,
                EmployeeCount = b.EmployeeCount,

            }).ToList();

        }
        [HttpGet ("{id}")]
        public IActionResult Details(int id) 
        {
            var bank = _context.BankBranches.Find(id);
            if (bank == null)
            {
                return NotFound();
            } 
            var response =  new BankBranchResponse
            {
                LocationName = bank.LocationName,
                LocationURL = bank.LocationURL,
                BranchManager = bank.BranchManager,
                BranchName = bank.BranchName,
                EmployeeCount = bank.EmployeeCount,
                Employees = bank.Employees.Select(r=> new EmployeeResponse 
                {
                    Name = r.Name,
                    CivilId = r.CivilId,
                    Position = r.Position,
                    
                }).ToList(),

            }; 
            return Ok(response);
        }
        [HttpPost]
        public IActionResult AddBranch(AddBankBranch req)
        {
            var newBank = new BankBranch()
            {
                LocationName = req.LocationName,
                LocationURL = req.LocationURL,
                BranchManager = req.BranchManager,
                BranchName = req.BranchName,
                EmployeeCount = req.EmployeeCount,
            };
            _context.BankBranches.Add(newBank);
            _context.SaveChanges();

            return Created(nameof(Details), new { Id = newBank.Id });
        }
        [HttpPatch("{id}")]
        public IActionResult EditBranch(int id, AddBankBranch req)
        {
            var bank = _context.BankBranches.Find(id);
            bank.LocationName = req.LocationName;
            bank.LocationURL = req.LocationURL;
            bank.BranchManager = req.BranchManager;
            bank.BranchName = req.BranchName;
            bank.EmployeeCount = req.EmployeeCount;
  
            _context.SaveChanges();

            return Created(nameof(Details), new { Id = bank.Id});
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBranch(int id)
        {
            var bank = _context.BankBranches.Find(id);
            _context.BankBranches.Remove(bank);  
            _context.SaveChanges();

            return Ok();
        }

       
       

    } 

}
