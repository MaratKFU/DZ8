using Homework;
using System;
namespace DZ8
{
    class Task_manager
    {
        public static void Main(string[] args)
        {
            Random r = new Random();

            Console.WriteLine("Введите имя заказчика:");
            string customer = Console.ReadLine();

            Console.WriteLine("Введите имя тимлида:");
            string teamlead = Console.ReadLine();

            Console.WriteLine("Введите название проекта:");
            string name = Console.ReadLine();
            
            Console.WriteLine("Введите количество дней на выполнение проекта:");
            int.TryParse(Console.ReadLine(), out var projectDays);
            Project project = new Project(customer, teamlead, name, DateTime.Now.AddDays(projectDays));

            Console.WriteLine("Введите количество исполнителей, которые будут заниматься данным проектом:");
            int.TryParse(Console.ReadLine(), out var numOfExecutors);

            List<string> listOfExecutors = new List<string>();
            for (int i = 0; i < numOfExecutors; i++)
            {
                Console.WriteLine($"Введите имя {i+1}-го исполнителя");
                listOfExecutors.Add(Console.ReadLine());
            }

            int numOfTasks = r.Next(numOfExecutors, numOfExecutors+10);
            Console.WriteLine($"Количество задач, назначенных тимлидом:{numOfTasks}");
            for (int i = 0; i < numOfTasks; i++) 
            {
                int taskDeadline = r.Next(1, projectDays);
                ProjectTask task = new ProjectTask(teamlead, DateTime.Now.AddDays(taskDeadline));
                project.tasks.Add(task);
            }

            Console.WriteLine("Нажмите любую клавишу для перехода к следующему этапу проекта:");
            Console.ReadKey(true);
            project.status = ProjectStatus.Execution;

            for (int i = 0;i < numOfTasks; i++)
            {
                
                int decision = r.Next(1, 3);
                switch (decision)
                {
                    case 1://принимает
                        project.tasks[i].executor = listOfExecutors[i % numOfExecutors];
                        project.tasks[i].status = TaskStatus_.Working;

                        break;
                    case 2://делегирует
                        int tempRand0 = 0;
                        int tempRand1 = 0;
                        while (decision == 2)
                        {
                            decision = r.Next(1, 3);
                            while (tempRand0 % numOfExecutors == 0)
                            {
                                tempRand0 = tempRand1;
                                tempRand1 += r.Next(1, 1000);
                            }
                            Console.WriteLine($"{listOfExecutors[(i + tempRand0) % numOfExecutors]} делегировал задачу исполнителю {listOfExecutors[(i + tempRand1) % numOfExecutors]}");
                        }
                        if (decision == 3)
                        {
                            project.tasks[i].status = TaskStatus_.Deleted;
                            Console.WriteLine($"Задача была удалена исполнителем {listOfExecutors[i % numOfExecutors]}");
                        }
                        else
                        {
                            project.tasks[i].executor = listOfExecutors[(i + tempRand0) % numOfExecutors];
                            project.tasks[i].status = TaskStatus_.Working;
                            Console.WriteLine($"Исполнитель {listOfExecutors[(i + tempRand0) % numOfExecutors]} принял задачу");
                        }
                        break;
                    case 3://удаляет
                        project.tasks[i].status = TaskStatus_.Deleted;
                        Console.WriteLine($"Задача была удалена исполнителем{listOfExecutors[(i) % numOfTasks]}");
                        break;
                }
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы исполнители начали работу:");
            Console.ReadKey(true);
            for (int i = 0; i < numOfTasks; i++) 
            {
                if (!(project.tasks[i].status == TaskStatus_.Deleted)) 
                {
                    project.tasks[i].status = TaskStatus_.Reviewing;
                    int reportStatus = r.Next(1, 2);
                    Report rep;
                    if (reportStatus == 1)
                    {
                        rep = new Report("Хороший отчёт", project.tasks[i].deadline, project.tasks[i].executor);
                    }
                    else
                    {
                        rep = new Report("Плохой отчёт", project.tasks[i].deadline, project.tasks[i].executor);
                    }
                    project.tasks[i].reports.Add(rep);
                }
            }

            Console.WriteLine("Нажмите любую клавишу, чтобы тимлид проверил отчёты:");
            Console.ReadKey(true);

            for (int i = 0; i < numOfTasks; i++)
            {
                if (!(project.tasks[i].status == TaskStatus_.Deleted))
                {
                    if (project.tasks[i].reports[0].reportText == "Хороший отчёт")
                    {
                        project.tasks[i].status = TaskStatus_.Completed;
                    }
                    else
                    {
                        while (project.tasks[i].reports[project.tasks[i].reports.Count].reportText != "Хороший отчёт")
                        {
                            Console.WriteLine($"Тимлид {teamlead} отправил исполнителя {project.tasks[i].executor} переделывать отчёт");
                            int reportStatus = r.Next(1, 2);
                            Report rep;
                            if (reportStatus == 1)
                            {
                                rep = new Report("Хороший отчёт", project.tasks[i].deadline, project.tasks[i].executor);
                            }
                            else
                            {
                                rep = new Report("Плохой отчёт", project.tasks[i].deadline, project.tasks[i].executor);
                            }
                            project.tasks[i].reports.Add(rep);
                        }
                        project.tasks[i].status = TaskStatus_.Completed;
                    }
                }
            }

            Console.WriteLine("Нажмите любую клавишу для завершения проекта:");
            Console.ReadKey(true);
            project.status = ProjectStatus.Closed;
            Console.WriteLine("Проект завершён");
        }
    }
}