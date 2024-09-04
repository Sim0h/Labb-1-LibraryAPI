using AutoMapper;
using LibraryAPI.Models;
using LibraryAPI.Models.DTO;
using LibraryAPI.Repository;
using System.Runtime.CompilerServices;

namespace LibraryAPI.EndPoints
{
    public static class LibraryEndPoints
    {
        public static void ConfigurationLibraryEndPoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).WithName("GetAllBooks").Produces<APIResponse>();
            app.MapGet("/api/title/", GetTitle).WithName("Title").Produces<APIResponse>();
            app.MapGet("/api/author/", GetAuthor).WithName("Author").Produces<APIResponse>();
            app.MapGet("/api/book/{id:int}", GetBookId).WithName("BookByID").Produces<APIResponse>();
            app.MapPost("/api/createbook", CreateBook).WithName("CreateBook").Accepts<LibraryCreateDTO>("application/json").Produces(201).Produces(400);
            app.MapPut("/api/updatebook", UpdateBook).WithName("UpdateBook").Accepts<LibraryUpdateDTO>("application/json").Produces<LibraryUpdateDTO>(200).Produces(400);
            app.MapDelete("/api/deletebook/{id:int}", DeleteBook).WithName("DeleteBook");
        }


        private async static Task<IResult> GetAllBooks(ILibraryRepo _libraryRepo)
        {
            APIResponse response = new APIResponse();
            response.Result = await _libraryRepo.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> GetTitle(ILibraryRepo _libraryRepo, string title)
        {
            APIResponse response = new APIResponse();
            response.Result = await _libraryRepo.GetAsyncTitle(title);
            response.IsSuccess = true;
            response.StatusCode= System.Net.HttpStatusCode.OK;
            return Results.Ok(response);
        }
        private async static Task<IResult> GetBookId(ILibraryRepo _libraryRepo, int id)
        {
            APIResponse response = new APIResponse();
            response.Result = await _libraryRepo.GetAsync(id);
            response.IsSuccess = true;
            response.StatusCode= System.Net.HttpStatusCode.OK;
            return Results.Ok(response);
        }
        private async static Task<IResult> GetAuthor(ILibraryRepo _libraryRepo, string author)
        {
            APIResponse response = new APIResponse();
            response.Result = await _libraryRepo.GetAsyncAuthor(author);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return Results.Ok(response);

        }

        private async static Task<IResult> CreateBook(ILibraryRepo _libraryRepo, IMapper _mapper, LibraryCreateDTO library_c_DTO)
        {
            APIResponse response = new() { IsSuccess = true , StatusCode = System.Net.HttpStatusCode.BadRequest};

            if(_libraryRepo.GetAsyncTitle(library_c_DTO.Title).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("Title Already Exists.");
                return Results.BadRequest(response);
            }

            Library library = _mapper.Map<Library>(library_c_DTO);
            await _libraryRepo.CreateAsync(library);
            await _libraryRepo.SaveAsync();
            LibraryCreateDTO libraryCreateDTO = _mapper.Map<LibraryCreateDTO>(library_c_DTO);

            response.Result = library;
            response.IsSuccess= true;
            response.StatusCode= System.Net.HttpStatusCode.Created;

            return Results.Ok(response);
        }

        private async static Task<IResult> DeleteBook(ILibraryRepo _libraryRepo, int id)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            Library library = await _libraryRepo.GetAsync(id);

            if (library != null)
            {
                await _libraryRepo.RemoveAsync(library);
                await _libraryRepo.SaveAsync();
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.NoContent;
                return Results.Ok(response);
            }
            else
            {
                response.ErrorMessages.Add("Invalid Book ID");
                return Results.BadRequest(response);
            }
        }

        private async static Task<IResult> UpdateBook(ILibraryRepo _libraryRepo, IMapper _mapper, LibraryUpdateDTO library_u_DTO)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            await _libraryRepo.UpdateAsync(_mapper.Map<Library>(library_u_DTO));
            await _libraryRepo.SaveAsync();

            response.Result = _mapper.Map<LibraryUpdateDTO>(await _libraryRepo.GetAsync(library_u_DTO.Id));
            response.IsSuccess=true;
            response.StatusCode=System.Net.HttpStatusCode.OK;
            return Results.Ok(response);
        }





    }
}
