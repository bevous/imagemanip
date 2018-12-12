using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace image_magic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //opens image for edditing
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private void Label1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG|*.JPG";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image myImage = Bitmap.FromFile(openFileDialog1.FileName);
                picture1.Image = myImage;
                picture2.Image = myImage;
            }
        }


        //saves the modified image
        SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog1.Filter = "JPG|*.JPG";
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picture2.Image.Save(SaveFileDialog1.FileName);
            }
        }
        
        //apply changes
        private void Button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker1 = new BackgroundWorker();
            worker1.DoWork += (obj,ea) => SortImage();
            worker1.RunWorkerAsync();
            
        }
        public class ColorCompare : IComparer<Color>
        {
            public int Compare(Color x, Color y)
            {
                if (x.B.CompareTo(y.B) != 0)
                {
                    return x.B.CompareTo(y.B);
                }
                else if (x.R.CompareTo(y.R) != 0)
                {
                    return x.R.CompareTo(y.R);
                }
                else if (x.G.CompareTo(y.G) != 0)
                {
                    return x.G.CompareTo(y.G);
                }
                else
                {
                    return 0;
                }
            }
        }
        public void SortImage()
        {
            //grab the image from box 2
            Image ModImage = picture2.Image;
            //save the image into a bitmap for editing
            Bitmap ImagePix = new Bitmap(ModImage);
            //set the dimentions
            int height = ImagePix.Height;
            int width = ImagePix.Width;
            //number of times the loop needs to complete
            List<Color> pixel = new List<Color>();
            

            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    
                    if (x + 1 < width && y + 1 < height)
                    {
                        pixel.Add(ImagePix.GetPixel(x, y));
                    }
                }
            }
            ColorCompare Cc = new ColorCompare();
            //pixel.Sort(Cc);
            
            int L = 0;
            int a = -1;


            List<Color> design = new List<Color>();
            design.Capacity = pixel.Capacity;
            foreach(Color bleh in pixel)
            {
                design.Add(Color.Beige);
            }
            //change this for different looks
            int counter = 0;
            int IndexA = 0;
            //int IndexB = (design.Count - 1) / 2;
            foreach (Color color in pixel)
            {
                for (int x = 0; x < width; x++)
                {
                    for (int y = counter; y < height; y++)
                    {

                    }
                }
            }
            /////////////
            for (int x = 0; x < pixel.Count; x++)
            {
             
                a++;
                ImagePix.SetPixel(a, L, design[x]);
                if ((x % (width - 1)) == 0)
                {
                    L++;
                    a = -1;
                }
            }

            
            //update the image
            picture2.Image = ImagePix;
            //update the box2

            Console.WriteLine("done");
        }

       
    }
}
