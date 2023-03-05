using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using StudList.Models;
using System.Xml.Serialization;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
namespace StudList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string text;
        private List<Student> students = new List<Student>();
        private SolidColorBrush checkColor(float num)
        {
            if (num < 1) return new SolidColorBrush(Colors.Red);
            if (num < 1.5) return new SolidColorBrush(Colors.Yellow);
            else return new SolidColorBrush(Colors.Green);
        }
        private void CheckAverage(List<Student> students)
        {
            for (int i = 0; i < 9; i++)
            {
                sc_scores[i] = 0;
            }
            for (int i = 0; i < students.Count; i++)
            {
                ScoreVisualSr += students[i].VisualProgramming;
                ScoreArchitectureSr += students[i].ComputerArchitecture;
                ScoreNetworksSr += students[i].ComputerNetworks;
                ScoreCalculate_MathSr += students[i].ComputingMaths;
                ScorePISr += students[i].PhysicalEducation;
                ScoreMathSr += students[i].SpecialChaptersOfMaths;
                ScoreElectricSr += students[i].Electronics;
                ScoreAverageSr += students[i].Average_Score;
            }
            ScoreVisualSr /= students.Count;
            ColorVisualSr = checkColor(ScoreVisualSr);
            ScoreArchitectureSr /= students.Count;
            ColorArchitectureSr = checkColor(ScoreArchitectureSr);
            ScoreNetworksSr /= students.Count;
            ColorNetworksSr = checkColor(ScoreNetworksSr);
            ScoreCalculate_MathSr /= students.Count;
            ColorCalculate_MathSr = checkColor(ScoreCalculate_MathSr);
            ScorePISr /= students.Count;
            ColorPISr = checkColor(ScorePISr);
            ScoreMathSr /= students.Count;
            ColorMathSr = checkColor(ScoreMathSr);
            ScoreElectricSr /= students.Count;
            ColorElectricSr = checkColor(ScoreElectricSr);
            ScoreAverageSr /= students.Count;
            ColorAverageSr = checkColor(ScoreAverageSr);
        }
        public MainWindowViewModel()
        {
            AddChar = ReactiveCommand.Create<string>(str => Text += str);

            AddStudent = ReactiveCommand.Create(() =>
            {
                Students.Add(new Student(NewName, scores[0], scores[1], scores[2], scores[3], scores[4], scores[5], scores[6], scores[7]));
                NewName = "";
                ScoreVisual = 0;
                ScoreArchitecture = 0;
                ScoreNetworks = 0;
                ScoreCalculate_Math = 0;
                ScorePI = 0;
                ScoreMath = 0;
                ScoreElectric = 0;
                ScoreTerVer = 0;
                CheckAverage(Students);
            }
            );
            DeleteStudent = ReactiveCommand.Create(() =>
            {
                if (index < students.Count)
                {
                    students.RemoveRange(index,1);
                    Index = 5000;
                    CheckAverage(Students);
                }
            });
            Save = ReactiveCommand.Create(() =>
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));

                using (var stream = new FileStream("data.xml",FileMode.Create,FileAccess.Write,FileShare.Write))
                {
                    xmlSerializer.Serialize(stream, students);
                }
            });
            Load = ReactiveCommand.Create(() =>
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

                using (var stream = new FileStream("data.xml",FileMode.Open,FileAccess.Read,FileShare.Read))
                {
                    Students = (List<Student>)serializer.Deserialize(stream);
                }
            });
        }

        public string Text
        {
            get { return text; }
            set
            {
                this.RaiseAndSetIfChanged(ref text, value);
            }
        }
        public List<Student> Students
        {
            get => students;
            set => this.RaiseAndSetIfChanged(ref students, value);
        }
        public ReactiveCommand<string, Unit> AddChar { get; }
        public ReactiveCommand<Unit, Unit> AddStudent { get; }
        public ReactiveCommand<Unit,Unit> DeleteStudent { get; }
        public ReactiveCommand<Unit, Unit> Save { get; }
        public ReactiveCommand<Unit, Unit> Load { get; }

        private ushort[] scores = { 0, 0, 0, 0, 0, 0, 0,0 };
        private string newName = "";
        private ushort index = 5000;
        private float[] sc_scores = { 0, 0, 0, 0, 0, 0, 0, 0,0 };
        private SolidColorBrush[] colorBrush = new SolidColorBrush[];
        public ushort Index { get => index; set => this.RaiseAndSetIfChanged(ref index, value); }
        public string NewName { get => newName; set => this.RaiseAndSetIfChanged(ref newName, value); }
        public ushort ScoreVisual { get => scores[0]; set => this.RaiseAndSetIfChanged(ref scores[0], value); }
        public ushort ScoreArchitecture { get => scores[1]; set => this.RaiseAndSetIfChanged(ref scores[1], value); }
        public ushort ScoreNetworks { get => scores[2]; set => this.RaiseAndSetIfChanged(ref scores[2], value); }
        public ushort ScoreCalculate_Math { get => scores[3]; set => this.RaiseAndSetIfChanged(ref scores[3], value); }
        public ushort ScorePI { get => scores[4]; set => this.RaiseAndSetIfChanged(ref scores[4], value); }
        public ushort ScoreMath { get => scores[5]; set => this.RaiseAndSetIfChanged(ref scores[5], value); }
        public ushort ScoreTerVer { get => scores[6]; set => this.RaiseAndSetIfChanged(ref scores[6], value); }
        public ushort ScoreElectric { get => scores[7]; set => this.RaiseAndSetIfChanged(ref scores[7], value); }
        public ushort Average_Score { get => scores[8]; set => this.RaiseAndSetIfChanged(ref scores[8], value); }

        public float ScoreVisualSr { get => sc_scores[0]; set => this.RaiseAndSetIfChanged(ref sc_scores[0], value); }
        public float ScoreArchitectureSr { get => sc_scores[1]; set => this.RaiseAndSetIfChanged(ref sc_scores[1], value); }
        public float ScoreNetworksSr { get => sc_scores[2]; set => this.RaiseAndSetIfChanged(ref sc_scores[2], value); }
        public float ScoreCalculate_MathSr { get => sc_scores[3]; set => this.RaiseAndSetIfChanged(ref sc_scores[3], value); }
        public float ScorePISr { get => sc_scores[4]; set => this.RaiseAndSetIfChanged(ref sc_scores[4], value); }
        public float ScoreMathSr { get => sc_scores[5]; set => this.RaiseAndSetIfChanged(ref sc_scores[5], value); }
        public float ScoreElectricSr { get => sc_scores[6]; set => this.RaiseAndSetIfChanged(ref sc_scores[6], value); }
        public float ScoreTerVerSr { get => sc_scores[7]; set => this.RaiseAndSetIfChanged(ref sc_scores[7], value); }
        public float ScoreAverageSr { get => sc_scores[8]; set => this.RaiseAndSetIfChanged(ref sc_scores[8], value); }

        public SolidColorBrush ColorVisualSr { get => colorBrush[0]; set => this.RaiseAndSetIfChanged(ref colorBrush[0], value); }
        public SolidColorBrush ColorArchitectureSr { get => colorBrush[1]; set => this.RaiseAndSetIfChanged(ref colorBrush[1], value); }
        public SolidColorBrush ColorNetworksSr { get => colorBrush[2]; set => this.RaiseAndSetIfChanged(ref colorBrush[2], value); }
        public SolidColorBrush ColorCalculate_MathSr { get => colorBrush[3]; set => this.RaiseAndSetIfChanged(ref colorBrush[3], value); }
        public SolidColorBrush ColorPISr { get => colorBrush[4]; set => this.RaiseAndSetIfChanged(ref colorBrush[4], value); }
        public SolidColorBrush ColorMathSr { get => colorBrush[5]; set => this.RaiseAndSetIfChanged(ref colorBrush[5], value); }
        public SolidColorBrush ColorElectricSr { get => colorBrush[6]; set => this.RaiseAndSetIfChanged(ref colorBrush[6], value); }
        public SolidColorBrush ColorTerVerSr { get => colorBrush[7]; set => this.RaiseAndSetIfChanged(ref colorBrush[7], value); }
        public SolidColorBrush ColorAverageSr { get => colorBrush[8]; set => this.RaiseAndSetIfChanged(ref colorBrush[8], value); }
    }
}