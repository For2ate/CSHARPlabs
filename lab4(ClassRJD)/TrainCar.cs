using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4_ClassRJD_ {
    internal class TrainCar {

        private int[] spaceInTrain;

        public TrainCar() : this(100) {
        }
        
        public TrainCar(int n) { 
            this.spaceInTrain = new int[n]; 
        }

        public int[] getFreeSpace() {
            List<int> result = new List<int>();
            for (int i = 0; i < this.spaceInTrain.Length; i++) {
                if (this.spaceInTrain[i] == 0) {
                    result.Add(this.spaceInTrain[i] + 1);
                }
            }
            return result.ToArray();
        }
        public void setSpace(int position) {
            this.spaceInTrain[position] = 1;
        }

    }
}
