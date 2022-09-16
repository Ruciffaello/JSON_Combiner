using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<board> boardList = new List<board>();
            HashSet<string> vendor = new HashSet<string>();
            HashSet<string> boardsHashSet = new HashSet<string>();

            Console.WriteLine("Please input the first file address");

            //string jsonString = File.ReadAllText(@"D:\C# demo\20220916\ConsoleApp1\ConsoleApp1\example-boards\boards-1.json");

            string jsonString = File.ReadAllText(Console.ReadLine());

            var data = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);

            var boards = data["boards"].Values();

            



            List<string> list = new List<string>();

            foreach (var boardItem in boards)
            {
                list.Add((string)boardItem.First);
            }

            for(int i =0; i < list.Count; i+=4)
            {
                board board = new board();
                board.name = list[i];
                boardsHashSet.Add(board.name);
                board.vendor = list[i+1];
                vendor.Add(board.vendor);
                board.core = list[i+2];
                if (list[i + 3] == "True")
                {
                    board.has_wifi = true;
                }else
                {
                    board.has_wifi = false;
                }

                boardList.Add(board);
            }



            Console.WriteLine("Please input the second file");

            //string jsonString2 = File.ReadAllText(@"D:\C# demo\20220916\ConsoleApp1\ConsoleApp1\example-boards\boards-2.json");

            string jsonString2 = File.ReadAllText(Console.ReadLine());

            var data2 = (JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString2);

            var boards2 = data2["boards"].Values();

            list = new List<string>();

            foreach (var boardItem in boards2)
            {
                list.Add((string)boardItem.First);
            }

            for (int i = 0; i < list.Count; i += 4)
            {
                board board = new board();
                board.name = list[i];
                boardsHashSet.Add(board.name);
                board.vendor = list[i + 1];
                vendor.Add(board.vendor);
                board.core = list[i + 2];
                if (list[i + 3] == "True")
                {
                    board.has_wifi = true;
                }
                else
                {
                    board.has_wifi = false;
                }

                boardList.Add(board);
            }


            boards final_boards = new boards();


            boardList.Sort((a, b) => a.vendor.CompareTo(b.vendor));

            boardList.Sort((a, b) => a.name.CompareTo(b.name));


            final_boards.boardList= boardList;

            metadata _metadata = new metadata();

             _metadata.total_boards= boardsHashSet.Count;
            _metadata.total_vendors=vendor.Count;

            final_boards.metadata=_metadata;

            string answer_json = Newtonsoft.Json.JsonConvert.SerializeObject(final_boards);

            Console.WriteLine("Please input the export file address included file name");
            File.WriteAllText(Console.ReadLine(), answer_json);



            Console.WriteLine("Finish file combine");
        }




        //void listSort(List<board> boards)
        //{

        //    boards.Sort((a, b) => a.vendor.CompareTo(b.vendor));

        //    boards.Sort((a,b )=> a.name.CompareTo(b.name) );



        //}


    }





}
