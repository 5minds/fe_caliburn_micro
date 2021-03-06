﻿using System.Windows.Media;

namespace CaliburnMicroApp
{
  public class ColorEvent
  {
    public ColorEvent(SolidColorBrush color)
    {
      Color = color;
    }

    public SolidColorBrush Color { get; private set; }
  }
}
