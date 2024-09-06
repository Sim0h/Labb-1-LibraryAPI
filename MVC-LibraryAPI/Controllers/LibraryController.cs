using LibraryAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using MVC_LibraryAPI.Models;
using MVC_LibraryAPI.Services;
using Newtonsoft.Json;

namespace MVC_LibraryAPI.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }


        public async Task<IActionResult> LibraryIndex()
        {
            List<LibraryDTO> List = new List<LibraryDTO>();
            var response = await _libraryService.GetAllBooks<ResponseDto>();
            if (response != null && response.IsSuccess)
            {
                List = JsonConvert.DeserializeObject<List<LibraryDTO>>(Convert.ToString(response.Result));
            }
            return View(List);
        }

        public async Task<IActionResult> Details(int id)
        {
            LibraryDTO libraryDTO = new LibraryDTO();
            var response = await _libraryService.GetBookById<ResponseDto>(id);

            if(response != null && response.IsSuccess)
            {
                LibraryDTO model = JsonConvert.DeserializeObject<LibraryDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return View();
        }

        public async Task<IActionResult> CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(LibraryDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _libraryService.CreateBookAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(LibraryIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBook(int bookId)
        {
            var response = await _libraryService.GetBookById<ResponseDto>(bookId);

            if (response != null && response.IsSuccess)
            {
                LibraryDTO model = JsonConvert.DeserializeObject<LibraryDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(LibraryDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _libraryService.UpdateBookAsync<ResponseDto>(model);
                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(LibraryIndex));
                }
            }
            return View(model);
        }

        //public async Task<IActionResult> DeleteBook(int bookId)
        //{
        //    var response = await _libraryService.GetBookById<ResponseDto>(bookId);
        //    if(response != null && response.IsSuccess)
        //    {
        //        LibraryDTO model = JsonConvert.DeserializeObject<LibraryDTO>(Convert.ToString(response.Result));
        //        return View(model);
        //    }
        //    return NotFound();
        //}
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var response = await _libraryService.GetBookById<ResponseDto>(bookId);
            if (response != null && response.IsSuccess)
            {
                LibraryDeleteDTO model = JsonConvert.DeserializeObject<LibraryDeleteDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        //[HttpPost]
        //public async Task<IActionResult> DeleteBook(LibraryDTO model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _libraryService.DeleteBookAsync<ResponseDto>(model.Id);
        //        if (response != null && response.IsSuccess)
        //        {
        //            return RedirectToAction(nameof(LibraryIndex));
        //        }
        //    }
        //    return NotFound();
        //}

        [HttpPost]
        public async Task<IActionResult> DeleteBook(LibraryDeleteDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _libraryService.DeleteBookAsync<ResponseDto>(model.Id);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(LibraryIndex));
                }
            }
            return NotFound();
        }



    }
}
