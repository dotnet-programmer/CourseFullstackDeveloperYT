﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ConsoleApp.Factory;
public abstract class Shape
{
    public  int X { get; set; }
	public int Y { get; set; }

	public abstract void Render();
}
