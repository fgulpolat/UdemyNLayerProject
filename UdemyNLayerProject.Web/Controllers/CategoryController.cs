using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Web.ApiService;
using UdemyNLayerProject.Web.DTOs;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UdemyNLayerProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper, CategoryApiService categoryApiService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
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
           await _categoryApiService.AddAsync(categoryDto);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int Id)
        {
            var category = await _categoryApiService.GetByIdAsync(Id);
            return View(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public IActionResult Update(CategoryDto categoryDto)
        {
           var category= _mapper.Map<Category>(categoryDto);
            _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        }

        public  async  Task<IActionResult> Delete(int Id)
        {
           
            await _categoryApiService.Delete(Id);

            return RedirectToAction("Index");
        }
    }
}
