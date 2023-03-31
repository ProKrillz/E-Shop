﻿using DataLayer.Entities;

namespace ServiceLayer.DTO;

public class ProductDTO
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? Brand { get; set; }
    public string? ImagePath { get; set; }
    public List<Category>? Categorys { get; set; }
}