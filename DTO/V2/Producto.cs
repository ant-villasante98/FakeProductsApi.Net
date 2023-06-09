﻿namespace FakestoreApi.DTO.V2;
public class Producto
{
    public Guid InternalId { get; set; } = Guid.NewGuid();
    public int id { get; set; }
    public string? title { get; set; }
    public float price { get; set; }
    public string? description { get; set; }
    public string? category { get; set; }
    public string? image { get; set; }
}
