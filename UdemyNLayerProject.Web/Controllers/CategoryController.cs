using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return View(categoryDtos);
        }

        public IActionResult Create()
        {
            return View();
        }


       [HttpPost]
       public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
           var category = _mapper.Map<Category>(categoryDto);
           await _categoryService.AddAsync(category);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int Id)
        {
            var category = await _categoryService.GetByIdAsync(Id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
           var category= _mapper.Map<Category>(categoryDto);
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var category =  _categoryService.GetByIdAsync(Id).Result;
            _categoryService.Remove(category);
            return RedirectToAction("Index");
        }
    }
}
