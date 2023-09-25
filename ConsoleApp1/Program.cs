using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace ConsoleApp1 {
    class MyWindow {
        private double leftCornerX;
        private double leftCornerY;
        private double rightCornerX;
        private double rightCornerY;
        private bool isHiden;
        private bool isFrame;

        public MyWindow() : this(0, 0, 0, 0) {
        }
        public MyWindow(double leftCornerX, double leftCornerY, double rightCornerX, double rightCornerY) {
            this.leftCornerX = leftCornerX;
            this.leftCornerY = leftCornerY;
            this.rightCornerX = rightCornerX;
            this.rightCornerY = rightCornerY;
        }
        public double LeftCornerX {
            get { return this.leftCornerX; }
            set { this.leftCornerX = value; }
        }
        public double LeftCornerY {
            get { return this.leftCornerY; }
            set { this.leftCornerY = value; }
        }
        public double RigthCorenrX {
            get { return this.rightCornerX; }
            set { this.leftCornerX = value; }
        }
        public double RightCornerY {
            get { return this.rightCornerY; }
            set { this.rightCornerY = value; }
        }

        public (double, double) calculateWidhHeight (){
            return (Math.Abs(rightCornerX - leftCornerX), Math.Abs(rightCornerY - leftCornerY));
        }
        public void changePosition(double delta) {
            this.leftCornerX += delta;
            this.leftCornerY += delta;  
            this.rightCornerX += delta; 
            this.rightCornerY += delta; 
        }
        public void changeVisible() {
            this.isHiden = (this.isHiden == true ? false : true);
        }
        public void changeFrame() {
            this.isFrame = (this.isFrame == true ? false : true);
        }
        
        public static bool isInOther(MyWindow w1, MyWindow w2) {
            if (w1.LeftCornerX <= w2.LeftCornerX && w1.rightCornerX >= w2.rightCornerX && w1.leftCornerY <= w2.leftCornerY && w1.RightCornerY >= w2.RightCornerY) {
                return true;
            } else {
                return false;
            }
        }

        public static double square(MyWindow w1, MyWindow w2) {
            double left = Math.Max(w1.leftCornerX, w2.leftCornerX);
            double top = Math.Max(w1.rightCornerY, w2.rightCornerY);
            double right = Math.Max(w1.rightCornerX, w2.rightCornerX);
            double bottom = Math.Max(w1.LeftCornerY, w2.LeftCornerY);
            double width = right - left, height = bottom - top; 
            if (width < 0 || height < 0) {
                return 0;
            } else {
                return width * height; 
            }
        }


    }

    class Program {

        static void Main(string[] args) {
            MyWindow window = new MyWindow(0, 0, 10, 10);
            window.RigthCorenrX = 20;
            Console.WriteLine(window.RigthCorenrX);
        }
    }
}
