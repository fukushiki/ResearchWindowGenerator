using System;
using System.IO;
using System.Text;

namespace ResearchWindowGenerator
{
    internal class Logger
    {
        static String fileName;
        static String filePass = @"../../../LogFolder/";
        static Encoding enCording = Encoding.UTF8;
        static String subjectName;
        static String subjectBelong;
        static String subjectGrade;

        /// <summary>
        /// ユーザーの情報を保存
        /// </summary>
        /// <param name="_subject_name">名前</param>
        /// <param name="_subject_belong">所属</param>
        /// <param name="_subject_grade">学年</param>
        internal static void SaveUserData(string _subject_name, string _subject_belong, string _subject_grade)
        {
            subjectName = _subject_name;
            subjectBelong = _subject_belong;
            subjectGrade = _subject_grade;
        }

        /// <summary>
        /// Logファイルの作成
        /// </summary>
        /// <param name="_v">Windowの名前</param>
        internal static void LoggerInitialize(string _v)
        {
            DateTime date = DateTime.Now;
            
            //File名生成
            String start_time = date.Year + "." + date.Month + "." + date.Day + "." + date.Hour + "." + date.Minute + "." + date.Second;
            if (subjectName.Equals("")) subjectName = "YURIKONANAO";
            fileName = subjectName + "_" + _v + "_" + start_time;
            //Console.WriteLine();
            //ログファイルの生成
            filePass = filePass + fileName + ".csv";
            System.IO.File.Create(filePass).Close();
            Console.WriteLine("LogFile: " + filePass + " 生成");
            //System.IO.File.Create(filePass);
        }

        /// <summary>
        /// マウスカーソルの座標をCSVに保存する
        /// </summary>
        /// <param name="_time">250ms毎</param>
        /// <param name="_x">マウスカーソルの座標x</param>
        /// <param name="_y">マウスカーソルの座標y</param>
        internal static void SaveMouseCursorPosition(double _time, double _x, double _y)
        {
            String write_data = _time + "," + _x + "," + _y;
            //Console.WriteLine(write_data);
            StreamWriter w = new StreamWriter(filePass, true, Encoding.UTF8);
            w.Write(write_data + "\n");
            w.Close();
        }

        
    }
}