using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceLayer.I_R;
using System.Data;
using WebLayer.Pages.Shared.Helpers.Files;

namespace WebLayer.Pages.Products;

public class UpdateProductModel : PageModel
{
    private readonly IProduct _productService;

    private readonly IFileHelper _fileHelper;

    public UpdateProductModel(IProduct service, IFileHelper fileHelper)
    {
        _productService = service;
        _fileHelper = fileHelper;
    }
    [BindProperty(SupportsGet = true)]
    public int ProductId { get; set; }
    [BindProperty]
    public Product Product  { get; set; }
    [BindProperty]
    public List<SelectListItem>? Catagories { get; set; }
    [BindProperty]
    public List<SelectListItem>? Brands { get; set; }
    //[BindProperty]
    //public List<SelectListItem>? Sets { get; set; }
    [BindProperty]
    public IFormFile? UploadImage { get; set; }
    public SelectList Sets { get; set; }
    public async Task<IActionResult> OnGetAsync()
    {
        if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userAdmin")))
        {
            Product = await _productService.GetProductByIdAsync(ProductId);
            List<Category> catagoriesTypeModels = await _productService.GetAllCategories();
            List<Brand> brandTypeModels = await _productService.GetAllBrandsAsync();
            List<Set> setTypeModels = await _productService.GetAllSetsAsync();
            Catagories = catagoriesTypeModels.Select(ctm => new SelectListItem
            {
                Value = ctm.CategoryId.ToString(),
                Text = ctm.Name.ToString()
            }).ToList();
            Brands = brandTypeModels.Select(b => new SelectListItem
            {
                Value = b.BrandId.ToString(),
                Text = b.Name.ToString()
            }).ToList();
            //Sets = setTypeModels.Select(s => new SelectListItem
            //{
            //    Value = s.SetId.ToString(),
            //    Text = s.SetName.ToString()
            //}).ToList();
            Sets = new SelectList(await _productService.GetAllSetsAsync(), "SetId", "SetName");

            return Page();
        }
        return RedirectToPage("/Index");
    }
    public async Task<IActionResult> OnPostUpdate()
    {
        if (UploadImage != null)
        {
            _fileHelper.DeleteFile(Product.Image.Path);
            string checkImage = UploadImage.FileName.Split('.').Last().ToUpper();
        
            if (checkImage == "JPG" | checkImage == "JPEG" | checkImage == "PNG")
            {
                await _fileHelper.UploadFileAsync(UploadImage);
                Product.Image = new();
                Product.Image.Path = $"\\Image\\Card\\{UploadImage.FileName}";      
            }
        }
        if (Product.Price == decimal.Zero) 
        {
            
        }
        if (ModelState.IsValid)
        {
            await _productService.UpdateItemAsync(Product);
            await _productService.CommitAsync();
            return RedirectToPage("/Users/Admin");
        }
        else
        {
            //Sets = new SelectList(await _productService.GetAllSetsAsync(), "SetId", "SetName");
            //return RedirectToPagePermanent("/Products/UpdateProduct");

            return Page();
        }
    }
}
