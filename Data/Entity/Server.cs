﻿namespace ServersLifeTimeWebApp.Data.Entity;

public class Server
{
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? RemoveDate { get; set; }
}
