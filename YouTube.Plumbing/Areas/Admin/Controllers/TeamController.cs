﻿using EntityLayer.WebApplication.ViewModels.TeamVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
       private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<IActionResult> GetTeamList()
        {
            var teamList = await _teamService.GetAllListAsync();
            return View(teamList);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamAddVM teamAddVM)
        {
            await _teamService.AddTeamAsync(teamAddVM);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var team = await _teamService.GetTeamById(id);
            return View(team);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(TeamUpdateVM teamUpdateVM)
        {
            await _teamService.UpdateTeamAsync(teamUpdateVM);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }
    }
}
