using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace MergeImage
{
	public class ImageHelper
	{
		public void MergeImage()
		{
			var bgImg = Image.FromFile("../../img/background.png");
			var logo = Image.FromFile("../../img/Usagi.png");

			var graphics = Graphics.FromImage(bgImg);

			using (var target = Graphics.FromImage(logo))
			{
				target.DrawImage(logo, new Rectangle(0, 0, logo.Width, logo.Height), 0, 0, logo.Width, logo.Height, GraphicsUnit.Pixel);
				target.Dispose();
			}

			var logoX = bgImg.Width - logo.Width + 50;
			var logoY = 5;
			graphics.DrawImage(logo, logoX, logoY);
			graphics.Dispose();
			var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			var filePath = $"{path}/../../ResultImg/Result{DateTime.Now:MMddhhmmss}.jpg";
			bgImg.Save(filePath, ImageFormat.Jpeg);
		}
	}
}