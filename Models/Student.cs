using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudList.Models
{
    [Serializable]
    public class Student
    {
        private float mid_scores = 0;
        private ushort[] scrores = {0,0,0,0,0,0,0,0};
        private string name = String.Empty;

        public Student()
        {
            Name = String.Empty;
            VisualProgramming = 0;
            ComputerArchitecture = 0;
            ComputerNetworks = 0;
            ComputingMaths = 0;
            PhysicalEducation = 0;
            SpecialChaptersOfMaths = 0;
            Electronics = 0;
            TheoryOfVarieties = 0;
        }
        public Student(string name,ushort VP,ushort EVM,ushort NET,ushort VM,ushort PE,ushort M,ushort EEIS,ushort TVMS)
        {
            Name = name;
            VisualProgramming = VP;
            ComputerArchitecture = EVM;
            ComputerNetworks = NET;
            ComputingMaths = VM;
            PhysicalEducation = PE;
            SpecialChaptersOfMaths = M;
            Electronics = EEIS;
            TheoryOfVarieties = TVMS;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ushort VisualProgramming
        {
            get { return scrores[0]; }
            set { scrores[0] = value; }
        }
        public ushort ComputerArchitecture
        {
            get { return scrores[1]; }
            set { scrores[1] = value; }
        }
        public ushort ComputerNetworks
        {
            get { return scrores[2]; }
            set { scrores[2] = value; }
        }
        public ushort ComputingMaths
        {
            get { return scrores[3]; }
            set { scrores[3] = value; }
        }
        public ushort PhysicalEducation
        {
            get { return scrores[4]; }
            set
            {
                scrores[4] = value;
            }
        }
        public ushort SpecialChaptersOfMaths
        {
            get { return scrores[5]; }
            set
            {
                scrores[5] = value;
            }
        }
        public ushort Electronics
        {
            get { return scrores[6]; }
            set
            {
                scrores[6] = value;
            }
        }
        public ushort TheoryOfVarieties
        {
            get { return scrores[7]; }
            set
            {
                scrores[7] = value;
            }
        }
        public float Average_Score
        {
            get
            {
                mid_scores = 0;
                foreach (var num in scrores)
                {
                    mid_scores += num;
                }
                return mid_scores /= 8;
            }
        }

    }
}
