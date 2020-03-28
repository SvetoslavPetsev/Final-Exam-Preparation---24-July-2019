using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    public class Status
    {
        public List<string> Members { get; set; }
        public int Time { get; set; }

        public Status(List<string> members, int time)
        {
            this.Members = members;
            this.Time = time;
        }
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, Status> bandMemberList = new Dictionary<string, Status>();
            int totalTime = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "start of concert")
                {
                    break;
                }

                string[] commandInfo = input.Split("; ");
                string cmd = commandInfo[0];
                string bandName = commandInfo[1];

                if (cmd == "Add")
                {
                    List<string> members = commandInfo[2].Split(", ").ToList();
                    List<string> membersToAdd = new List<string>();
                    foreach (var member in members)
                    {
                        if (!membersToAdd.Contains(member))
                        {
                            membersToAdd.Add(member);
                        }
                    }

                    if (!bandMemberList.ContainsKey(bandName))
                    {
                        bandMemberList.Add(bandName, new Status(membersToAdd, 0));
                    }
                    else
                    {
                        foreach (var member in members)
                        {
                            if (!bandMemberList[bandName].Members.Contains(member))
                            {
                                bandMemberList[bandName].Members.Add(member);
                            }
                        }
                    }
                }
                else if (cmd == "Play")
                {
                    int time = int.Parse(commandInfo[2]);
                    if (!bandMemberList.ContainsKey(bandName))
                    {
                        bandMemberList.Add(bandName, new Status(new List<string>(), time));
                    }
                    else
                    {
                        bandMemberList[bandName].Time += time;
                    }
                    totalTime += time;
                }
            }
            string inputBand = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");
            foreach (var band in bandMemberList.OrderByDescending(x => x.Value.Time).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value.Time}");
            }

            if (bandMemberList.ContainsKey(inputBand))
            {
                Console.WriteLine(inputBand);
                foreach (string member in bandMemberList[inputBand].Members)
                {
                    Console.WriteLine($"=> {member}");
                }
            }
        }
    }
}
