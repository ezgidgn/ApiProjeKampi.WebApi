using System;

namespace ApiProjeKampi.WebApi.Entites;

public class Testimonial
{
    public int TestimonialId { get; set; }
    public string? AuthorName { get; set; }
    public string? Content { get; set; }
    public string? AuthorImageUrl { get; set; }
}
