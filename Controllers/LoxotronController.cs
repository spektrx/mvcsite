using Microsoft.AspNetCore.Mvc;

using System.Text.Encodings.Web;

namespace Loxotron.Controllers;

public class LoxotronController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index(string name)
    {
        ViewData["Message"] = "Hello " + name;
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Play(int first, float second)
    {

        Random random = new Random();
        int coins = 10000;  //θη αδ
        float[] story = new float[10];



        int win = 0;
        Console.WriteLine(string.Join(", ", story));
        Console.WriteLine("Your real money: " + coins);
        Console.Write("Bet: ");
        int bet = first;
        Console.Write("Choose the coefficient: ");
        float a = second;


        if (bet > coins)
        {
            return View();
        }

        coins -= bet;
        float cef = 1;
        int crush = 0;
        int ran = random.Next(20);
        float freez = 2;
        int count = 0;

        while (crush == 0)
        {
            Console.WriteLine(Math.Round(cef, 4));
            //System.Threading.Thread.Sleep((int)(freez * 1000));

            if (ran == 0)
            {
                crush = 1;

                if (a <= cef)
                {
                    win = 1;
                }

                break;
            }

            cef *= 1.01f;
            freez *= 0.9f;
            count += 1;
            
            ran = random.Next(50);
        }

        if (win == 1)
        {
            coins += (int)(bet * a);
        }

        Array.Copy(story, 0, story, 1, 9);
        story[0] = (float)Math.Round(cef, 4);

        ViewData["Data"] = new { cef = cef, Count = count};
        return View();
    }
    //http://localhost:5272/helloworld/welcome?first=18&second=34
}

