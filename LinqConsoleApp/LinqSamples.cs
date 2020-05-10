using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
            Console.WriteLine("TASK 1");
            Task1();
            Console.WriteLine("TASK 2");
            Task2();
            Console.WriteLine("TASK 3");
            Task3();
            Console.WriteLine("TASK 4");
            Task4();
            Console.WriteLine("TASK 5");
            Task5();
            Console.WriteLine("TASK 6");
            Task6();
            Console.WriteLine("TASK 7");
            Task7();
            Console.WriteLine("TASK 8");
            Task8();
            Console.WriteLine("TASK 9");
            Task9();
            Console.WriteLine("TASK 10");
            Task10();
            Console.WriteLine("TASK 11");
            Task11();
            Console.WriteLine("TASK 12");
            Task12();

        }

        public void LoadData()
        {
            var empsCol = new List<emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }

        /*
            The purpose of the exercise is to implement the following methods.
            Each method should contain C# code, which with the help of LINQ will perform queries described using SQL.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        /// 
        
        public void Task1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };

            res.ToList().ForEach(Console.WriteLine);



            //2. Lambda and Extension methods

            var res2 = Emps.Where(emp => emp.Job == "Backend programmer").ToList();
            res2.ForEach(Console.WriteLine);

        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Task2()
        {
            var res = Emps.Where(emp => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                .OrderByDescending(emp => emp.Ename)
                .ToList();

            var res2 = from emp in Emps
                       where emp.Job == "Frontend programmer" && emp.Salary > 1000
                       orderby emp.Ename descending
                       select emp;

            res.ForEach(Console.WriteLine);
            res2.ToList().ForEach(Console.WriteLine);

        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Task3()
        {
            var res = Emps.Max(emp => emp.Salary);
            Console.WriteLine(res);
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Task4()
        {
            var res = Emps.Where(emp => emp.Salary == Emps.Max(emp => emp.Salary)).ToList();
            res.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// SELECT ename AS FirstName, job AS EmployeeJob FROM Emps;
        /// </summary>
        public void Task5()
        {
            var res = Emps.Select(emp => new { FirstName = emp.Ename, EmployeeJob = emp.Job }).ToList();
            res.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Result: Joining collections Emps and Depts.
        /// </summary>
        public void Task6()
        {
            var res = from e in Emps
                      join d in Depts on e.Deptno equals d.Deptno
                      select new
                      {
                          Ename = e.Ename,
                          Job = e.Job,
                          Dept = d.Dname
                      };
            res.ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// SELECT Job AS EmployeeJob, COUNT(1) EmployeeNuber FROM Emps GROUP BY Job;
        /// </summary>
        public void Task7()
        {
            var res = from e in Emps
                      group e by e.Job into grp
                      where grp.Count() > 1
                      select grp.Key;

            res.ToList().ForEach(Console.WriteLine);

        }

        /// <summary>
        /// Return value "true" if at least one of 
        /// the elements of collection works as "Backend programmer".
        /// </summary>
        public void Task8()
        {
            var res = Emps.Any(emp => {
                if (emp.Job == "Backend programmer") return true;
                else return false;
        });

            Console.WriteLine();
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Task9()
        {
            var res = (from e in Emps
                       where e.Job == "Frontend programmer"
                       orderby e.HireDate descending
                       select e).Take(1);
            res.ToList().ForEach(Console.WriteLine);

        }
        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "No value", null, null;
        /// </summary>
        public void Task10()
        {
            var emptyEmp = new emp()
            {
                Ename = "No value",
                Job = null,
                HireDate = null
            };

            var listEmpty = new List<emp>();
            listEmpty.Add(emptyEmp);


            var res = Emps.Select(emp => new { emp.Ename, emp.Job, emp.HireDate }).ToList().Union(listEmpty.Select(emp => new { emp.Ename, emp.Job, emp.HireDate }).ToList());
            res.ToList().ForEach(Console.WriteLine);
        }


        //Find the employee with the highest salary using the Aggregate () method
        public void Task11()
        {
            var res = Emps.Aggregate(0, (max, salary) =>
              {
                  if (max < salary.Salary) return salary.Salary;
                  else return max;
              },
              max => max);
            Console.WriteLine(res);
        }

        //Using the LINQ language and the SelectMany method, 
        //perform a CROSS JOIN join between collections Emps and Depts
        public void Task12()
        {
            var res = Emps.SelectMany(emp => Depts, (emp, dept) => { return new { emp, dept}; }).ToList();
            Console.WriteLine(res);
        }
    }
}
