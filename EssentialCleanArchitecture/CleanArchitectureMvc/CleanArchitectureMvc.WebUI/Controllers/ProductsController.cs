using System.Collections;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchitectureMvc.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public ProductsController(ICategoryService categoryService, IProductService productService)
    {
        _categoryService = categoryService;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<ProductDto> products = await _productService.GetAllProductsAsync();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto product)
    {
        if(ModelState.IsValid)
        {
            await _productService.CreateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if(id is null) return NotFound();
        if(id <= 0) return BadRequest();

        ProductDto productDto = await _productService.GetProductByIdAsync(id.Value);
        IEnumerable<CategoryDto> categories = await _categoryService.GetAllCategoriesAsync();

        ViewBag.CategoryId = new SelectList(categories, "Id", "Name", productDto.CategoryId);

        return View(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDto product)
    {
        if(ModelState.IsValid)
        {
            await _productService.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        return View(product);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if(id is null) return NotFound();
        if(id <= 0) return BadRequest();

        ProductDto productDto = await _productService.GetProductByIdAsync(id.Value);
        return View(productDto);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.RemoveProductAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int? id)
    {
        if(id is null) return NotFound();
        if(id <= 0) return BadRequest();

        ProductDto productDto = await _productService.GetProductByIdAsync(id.Value);

        return View(productDto);
    }
}