using System.Collections.Generic;
using AutoMapper;
using Caching;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DbEntities;
using Models.ResponseModels;
using Services.Interfaces;
using WebApi.Attributes;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;
    private readonly IMapper _mapper;

    public NoteController(INoteService noteService, ICacheManager cacheManager, IMapper mapper)
    {
        _noteService = noteService;
        _mapper = mapper;
    }
    
    [Cached(2)]
    [HttpGet("allnotes")]
    public IActionResult GetAllNotes()
    {
        var notesList = _noteService.GetAllMyNotes();
        return Ok(new BaseResponse<IReadOnlyList<Note>>(notesList, "Notes retrieved successfully"));
    }
    
    [HttpPost("addnote")]
    public IActionResult AddNewNote([FromBody] Note note)
    {
        _noteService.InsertNote(note);
        return Ok(new BaseResponse<string>("Note added successfully"));
    }
    
    
}