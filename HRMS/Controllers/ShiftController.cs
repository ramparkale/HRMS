//using HRMS.Models;
//using HRMS.Repository;
//using Microsoft.AspNetCore.Mvc;

//namespace HRMS.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class ShiftController : Controller
//    {
//        private readonly IShiftRepository _repository;

//        public ShiftController(IShiftRepository repository)
//        {
//            _repository = repository;
//        }

//        // Index

//        public async Task<IActionResult> Get()
//        {
//            var shifts = await _repository.GetAllAsync();
//            return View(shifts);
//        }

//        // Create

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(Shift shift)
//        {
//            if (ModelState.IsValid)
//            {
//                await _repository.AddAsync(shift);
//                return RedirectToAction(nameof(Index));
//            }

//            return View(shift);
//        }

//        // Edit

//        public async Task<IActionResult> Edit(int id)
//        {
//            var shift = await _repository.GetByIdAsync(id);

//            if (shift == null)
//                return NotFound();

//            return View(shift);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Edit(Shift shift)
//        {
//            if (ModelState.IsValid)
//            {
//                await _repository.UpdateAsync(shift);
//                return RedirectToAction(nameof(Index));
//            }

//            return View(shift);
//        }

//        // Delete

//        public async Task<IActionResult> Delete(int id)
//        {
//            await _repository.DeleteAsync(id);
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}