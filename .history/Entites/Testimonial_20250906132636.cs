using System;

namespace ApiProjeKampi.WebApi.Entites;

public class Testimonial
{
    public int TestimonialId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? AuthorImageUrl { get; set; }
}
