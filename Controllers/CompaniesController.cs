﻿using DapperTest.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepo;

        public CompaniesController(ICompanyRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var companies = await _companyRepo.GetCompanies();
                return Ok(companies);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "CompanyById")]
        public async Task<IActionResult> GetCompany (int id)
        {
            try
            {
                var company = await _companyRepo.GetCompany(id);
                if(company == null)
                    return NotFound();

                return Ok(company);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
