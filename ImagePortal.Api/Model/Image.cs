using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ImagePortal.Api.Model;

public class Entity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column(Order = 0)]
    public int Key {get; set;}
    public Guid Uid { get; set; }
    public string Name { get; set; }

}

public class Image : Entity
{

    public string Path { get; set; }
}