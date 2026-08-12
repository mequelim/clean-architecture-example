using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureMvc.WebUI.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;

    //* Methods...
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<CategoryDto> categoriesDto = await _categoryService.GetAllCategoriesAsync();
        return View(categoriesDto);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto category)
    {
        if(ModelState.IsValid)
        {
            await _categoryService.CreateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if(id is null) return NotFound();
        if(id <= 0) return NotFound();

        CategoryDto categoryDto = await _categoryService.GetCategoryByIdAsync(id.Value);
        return View(categoryDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDto category)
    {
        if(ModelState.IsValid)
        {
            await _categoryService.UpdateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        CategoryDto categoryDto = await _categoryService.GetCategoryByIdAsync(id);
        return View(categoryDto);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        if(id is null) return NotFound();
        if(id <= 0) return NotFound();

        CategoryDto categoryDto = await _categoryService.GetCategoryByIdAsync(id.Value);
        return View(categoryDto);
    }
}