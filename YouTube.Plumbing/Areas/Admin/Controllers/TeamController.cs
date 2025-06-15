using EntityLayer.WebApplication.ViewModels.TeamVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IValidator<TeamAddVM> _addValidator;
        private readonly IValidator<TeamUpdateVM> _updateValidator;

        public TeamController(ITeamService teamService, IValidator<TeamAddVM> addValidator, IValidator<TeamUpdateVM> updateValidator)
        {
            _teamService = teamService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
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
            var validator = await _addValidator.ValidateAsync(teamAddVM);
            if (validator.IsValid)
            {
                await _teamService.AddTeamAsync(teamAddVM);
                return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
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
            var validator = await _updateValidator.ValidateAsync(teamUpdateVM);
            if (validator.IsValid)
            {
                await _teamService.UpdateTeamAsync(teamUpdateVM);
                return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }
    }
}
